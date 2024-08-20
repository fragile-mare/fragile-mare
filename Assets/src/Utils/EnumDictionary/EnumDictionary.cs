using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace src.Utils.EnumDictionary
{
    // WARNING: Profiler shows, that this implementation isn't give more speed. So it becomes irrelevant
    // Maybe improve it in future.
    //
    // Old description:
    // Enhanced complexity: get - O(1); set - O(1); clear - O(1).
    // For enhancement was applied sentinel trick:
    // https://purplesyringa.moe/blog/the-sentinel-trick/
    // Default Dictionary.Clear complexity is O(n), see:
    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.clear?view=net-8.0)
    [Obsolete("Read WARNING above.")]
    public class EnumDictionary<TEnum, TValue> : IEnumerable where TEnum : Enum
    {
        private readonly List<(TValue item, ulong version)> _list;
        private readonly Dictionary<TEnum, (TValue item, ulong version)> _dict = new();

        private ulong _currVersion = 1;
        private TValue _default;

        public TValue this[TEnum key]
        {
            get
            {
                var (item, version) = _dict[key];
                if (version != _currVersion)
                {
                    return _default;
                }

                return item;
            }

            set => _dict[key] = (value, _currVersion);
        }

        public void Clear()
        {
            _currVersion++;
        }
        
        public void SetDefault(TValue value)
        {
            _default = value;
        }

        public bool ContainsKey(TEnum key)
        {
            if (!_dict.ContainsKey(key)) return false;
            
            var (_, version) = _dict[key];
            return version == _currVersion;
        }

        public IEnumerator<KeyValuePair<TEnum, TValue>> GetEnumerator()
        {
            foreach (var (key, (item, version)) in _dict)
            {
                if(version != _currVersion) continue;
                
                yield return new KeyValuePair<TEnum, TValue>(key, item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}