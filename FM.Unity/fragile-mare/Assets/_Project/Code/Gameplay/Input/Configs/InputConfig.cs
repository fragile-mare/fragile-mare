using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Input", fileName = "InputConfig")]
    public class InputConfig : ScriptableObject
    {
        public float mouseSens;
        public float zoom;
        public float minZoom;
        public float maxZoom;
        public float rotationYLimit;
        
        public List<ControlConfig> controls;
    }
}