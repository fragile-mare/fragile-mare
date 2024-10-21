using System.Collections.Generic;
using System.Linq;
using _Project.Code.Common.Services.StaticData;
using _Project.Code.Gameplay.Input.Controls.Actions;
using _Project.Code.Gameplay.Input.Controls.Keys;
using _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses;
using _Project.Code.Infrastructure;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Controls.Services
{
    public class DefaultControlsProvider : IDefaultControlsProvider
    {
        private readonly IStaticDataService _staticData;
        
        private readonly Cached<List<Control>> _defaultControls;

        public DefaultControlsProvider(IStaticDataService staticData)
        {
            _staticData = staticData;
            _defaultControls = new Cached<List<Control>>(GetDefaultControlsCopy);
        }
        
        public Control GetDefaultControl(GameAction action)
        {
            foreach (var control in _defaultControls.Value)
            {
                if (control.Action != action) continue;
                
                var hotkeys = control.HotKeys.Select(hotKey => hotKey.Clone() as HotKey).ToList();
                return new Control
                {
                    Action = action,
                    HotKeys = hotkeys
                };
            }

            Debug.LogError($"Game action {action} not found.");
            return null;
        }

        public List<Control> GetDefaultControlsCopy()
        {
            Dictionary<GameAction, List<HotKey>> controlsDict = new();
            foreach (var controlCfg in _staticData.InputConfig.controls)
            {
                foreach(var hotKeyCfg in controlCfg.hotKeys)
                {
                    var keyPressCfg = hotKeyCfg.keyPress;
                
                    var action = controlCfg.action;
                    var hotkey = new HotKey(hotKeyCfg.mainKey, hotKeyCfg.modifiers,
                        keyPressCfg.keyPress.Current.Clone() as IKeyPress, hotKeyCfg.type);
                
                    if (controlsDict.ContainsKey(action))
                    {
                        controlsDict[action].Add(hotkey);
                    }
                    else
                    {
                        controlsDict[action] = new List<HotKey> { hotkey };
                    }
                }

            }

            List<Control> controls = new();
            foreach (var (action, hotkeys) in controlsDict)
            {
                controls.Add(new Control
                {
                    Action = action,
                    HotKeys = hotkeys
                });
            }
            
            return controls;
        }
    }
}