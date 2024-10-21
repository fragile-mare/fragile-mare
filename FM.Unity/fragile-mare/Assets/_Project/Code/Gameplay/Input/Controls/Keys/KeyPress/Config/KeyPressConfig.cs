using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses;
using _Project.Code.Infrastructure.CustomUnity;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Config
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/KeyPress", fileName = "KeyPressConfig")]
    public class KeyPressConfig : ScriptableObject
    {
        public CustomUnityEnum<IKeyPress> keyPress = new()
        {
            values = new List<IKeyPress>
            {
                new InstantKeyPress(),
                new HoldKeyPress(),
                new IntervalKeyPress(),
                new TurnKeyPress()
            }
        };
    }
}