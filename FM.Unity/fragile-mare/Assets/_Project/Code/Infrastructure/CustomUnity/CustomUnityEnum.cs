using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Infrastructure.CustomUnity
{
    [Serializable]
    public class CustomUnityEnum<T>
    {
        
        [SerializeReference]
        public List<T> values;

        public int chosenValueIndex;
        public string chosenValue; // do not delete. it is using in property drawer.
        
        public T Current => values[chosenValueIndex];
        
    }
}