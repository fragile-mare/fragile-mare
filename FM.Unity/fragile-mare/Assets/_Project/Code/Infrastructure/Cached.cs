using System;

namespace _Project.Code.Infrastructure
{
    public class Cached<T>
    {
        private readonly Func<T> _resolver;
        private T _cache;
        private bool _cached;

        public Cached(Func<T> resolver)
        {
            _resolver = resolver;
        }

        public T Value
        {
            get
            {
                if (!_cached)
                {
                    _cache = _resolver();
                    _cached = true;
                }

                return _cache;
            }
        }

        public void Invalidate()
        {
            _cached = false;
        }
    }
}