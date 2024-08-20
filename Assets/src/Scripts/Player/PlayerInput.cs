using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using src.pubsub;
using src.Topics.Game;
using src.Topics.Player;
using src.Topics.Player.InputActions;
using src.Utils.EnumDictionary;
using src.Utils.GameContext;
using src.Utils.HotKey;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Serialization;

namespace src.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        // todo: превратить в конфиг.
        [SerializeField] 
        private List<ActionInputsByContext> actionInputsByContexts;

        private GameContext _currContext = GameContext.Game;
        private Subscription _contextSub;

        // при изменении игрового контекста - обновлять
        private List<ActionInput> _currActionInputs;

        private readonly Dictionary<KeyCode, (ActionInput actionInput, int priority)> _currentHotkeys = new();
        private readonly Dictionary<PlayerAction, bool> _published = new();

        private void Start()
        {
            _currActionInputs = GetActionInputs(_currContext);
            
            ContextTopic.Subscribe(@params =>
            {
                _currContext = @params.Context;
                _currActionInputs = GetActionInputs(_currContext);
            }, out _contextSub);
        }

        void Update()
        {
            ProcessActionInput();
        }

        // todo: нужны ли идентификаторы начала и конца действия, чтобы не спамить действием Move?
        // todo: скорее всего нет, ведь мы и так спамим поворотом мышки.
        private void ProcessActionInput()
        {
            Profiler.BeginSample("ProcessActionInput");
            _currentHotkeys.Clear();
            _published.Clear();
            
            foreach (var actionInput in GetCurrentActionInputs())
            {
                foreach (var hotkey in actionInput.hotKeys)
                {
                    if (!hotkey.IsPressed()) continue;
                    
                    var key = hotkey.key;
                    var priority = hotkey.GetPriority();
                    
                    // Выбираем нужное сочетание клавиш по приоритету (подробнее - в комментариях к
                    // методу Hotkey.GetPriority; он находится выше).
                    if (_currentHotkeys.ContainsKey(key) && _currentHotkeys[key].priority > priority)
                    {
                        continue;
                    }
                    
                    _currentHotkeys[hotkey.key] = (actionInput, priority);
                }
            }
            
            foreach (var (_, (actionInput, _)) in _currentHotkeys)
            {
                var action = actionInput.playerAction;
                // убираем дубликаты действий.
                // todo: сделать так, чтобы не возникало одновременно Move и Sprint. При этом приоритет Sprint выше.
                if(_published.ContainsKey(action)) continue; 
                
                actionInput.Execute();
                _published[action] = true; // помечаем, что уже выполнили действие.
            }
            
            Profiler.EndSample();
        }

        /// Выбираем правила сочетаний клавиш в зависимости от игрового контекста (игра, меню, инвентарь и т.д.)
        public List<ActionInput> GetActionInputs(GameContext context)
        {
            return actionInputsByContexts.
                Find(x => x.context == context).actionInputs;
        }

        /// Правила сочетаний клавиш текущего игрового контекста. См. на функцию выше <see cref="GetActionInputs"/>.
        /// WARNING: при изменении контекста нужно менять <see cref="_currActionInputs"/>.
        public List<ActionInput> GetCurrentActionInputs()
        {
            return _currActionInputs;
        }

        private void OnDestroy()
        {
            _contextSub.Unsubscribe();
        }
    }

    [Serializable]
    public class ActionInput
    {
        [FormerlySerializedAs("action")] public PlayerAction playerAction;
        // public bool canOverride; todo
        public List<HotKey> hotKeys;

        public ActionInput(PlayerAction playerAction, List<HotKey> keys=null)
        {
            this.playerAction = playerAction;
            hotKeys = keys ?? new List<HotKey>();
        }

        public void AddKey(HotKey key)
        {
            hotKeys.Add(key);
        }

        // todo: переделать
        [Obsolete("Переделать.")]
        public void RemoveKey(HotKey key)
        {
            hotKeys.RemoveAll(x => x == key);
        }

        // todo: зачем
        public bool IsActivated()
        {
            return hotKeys.Any(key => key.IsPressed());
        }

        public void Execute()
        {
            PlayerActions.Publish(new PlayerActionsParams{PlayerAction = playerAction});
        }
    }

    [Serializable]
    public class ActionInputsByContext
    {
        public GameContext context;
        public List<ActionInput> actionInputs;
    }
}
