using System;
using System.Collections.Generic;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GameUnused;
using _Project.Code.Unused.TopicsUnused.PlayerUnused.Input;
using _Project.Code.Unused.UtilsUnused.GameContextUnused;
using _Project.Code.Unused.UtilsUnused.HotKeyUnused;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Code.Unused.ScriptsUnused.InputUnused
{
    [Obsolete("Unused.")]
    public class PlayerInput : MonoBehaviour
    {
        // todo: превратить в конфиг.
        [FormerlySerializedAs("actionInputsByContexts")] [SerializeField] 
        private List<ContextualActionConfigs> configs;

        private UtilsUnused.GameContextUnused.GameContext _currContext = UtilsUnused.GameContextUnused.GameContext.Game;
        private Subscription _contextSub;

        // при изменении игрового контекста - обновлять
        private List<ActionConfig> _currActionConfigs;

        private readonly Dictionary<KeyCode, (ActionConfig actionConfig, int priority)> _activatedConfigs = new();
        private readonly Dictionary<InputAction, bool> _published = new();

        private void Start()
        {
            _currActionConfigs = GetActionConfigs(_currContext);
            
            ContextTopic.Subscribe(@params =>
            {
                _currContext = @params.Context;
                _currActionConfigs = GetActionConfigs(_currContext);
            }, out _contextSub);
        }

        void Update()
        {
            ProcessInput();
        }

        // todo: нужны ли идентификаторы начала и конца действия, чтобы не спамить действием Move?
        // todo: скорее всего нет, ведь мы и так спамим поворотом мышки.
        private void ProcessInput()
        {
            _activatedConfigs.Clear();
            _published.Clear();
            
            foreach (var actionInput in GetCurrentActionConfigs())
            {
                foreach (var hotkey in actionInput.hotKeys)
                {
                    if (!hotkey.IsPressed()) continue;
                    
                    var key = hotkey.key;
                    var priority = hotkey.GetPriority();
                    
                    // Выбираем нужное сочетание клавиш по приоритету (подробнее - в комментариях к
                    // методу Hotkey.GetPriority; он находится выше).
                    if (_activatedConfigs.ContainsKey(key) && _activatedConfigs[key].priority > priority)
                    {
                        continue;
                    }
                    
                    _activatedConfigs[hotkey.key] = (actionConfig: actionInput, priority);
                }
            }
            
            foreach (var (_, (actionInput, _)) in _activatedConfigs)
            {
                var action = actionInput.inputAction;
                // убираем дубликаты действий.
                // todo: сделать так, чтобы не возникало одновременно Move и Sprint. При этом приоритет Sprint выше.
                if(_published.ContainsKey(action)) continue; 
                
                actionInput.Execute();
                _published[action] = true; // помечаем, что уже выполнили действие.
            }
        }

        /// Выбираем правила сочетаний клавиш в зависимости от игрового контекста (игра, меню, инвентарь и т.д.)
        public List<ActionConfig> GetActionConfigs(UtilsUnused.GameContextUnused.GameContext context)
        {
            return configs.
                Find(x => x.context == context).configs;
        }

        /// Правила сочетаний клавиш текущего игрового контекста. См. на функцию выше <see cref="GetActionConfigs"/>.
        /// WARNING: при изменении контекста нужно менять <see cref="_currActionConfigs"/>.
        public List<ActionConfig> GetCurrentActionConfigs()
        {
            return _currActionConfigs;
        }

        private void OnDestroy()
        {
            _contextSub.Unsubscribe();
        }
    }

    /// <summary>
    /// Список хоткеев и действие, которое активирается от них
    /// </summary>
    [Serializable]
    [Obsolete("Unused.")]
    public class ActionConfig
    {
        [FormerlySerializedAs("playerAction")] [FormerlySerializedAs("action")] public InputAction inputAction;
        // public bool canOverride; todo
        public List<HotKey> hotKeys;

        public void Execute()
        {
            InputActionsTopic.Publish(new InputActionParams{InputAction = inputAction});
        }
    }

    [Serializable]
    [Obsolete("Unused.")]
    public class ContextualActionConfigs
    {
        public UtilsUnused.GameContextUnused.GameContext context;
        [FormerlySerializedAs("actionInputs")] public List<ActionConfig> configs;
    }
}
