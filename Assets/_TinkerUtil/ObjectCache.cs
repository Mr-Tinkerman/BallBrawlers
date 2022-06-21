using System;

namespace TinkerUtil.DataStructures
{
    public class ObjectCache<T> : GenericCircularBuffer<T>
    {
        int _count;

        public ObjectCache(int size) : base(size)
        {
            _count = 0;
        }

        /// <summary>
        /// Attempts to get an object to the pool. 
        ///
        /// <returns>
        /// Returns the object if pull suceeded.
        /// Returns the default value if failed.
        /// </returns>
        /// </summary>
        public virtual T GetNextInactive()
        {
            if (isEmpty())
                return default;

            _tail = _tail % _count;
            _head--;
            return this[_tail++];
        }

        /// <summary>
        /// Reuses the oldest object
        /// and adds it to the pool.
        ///
        /// <returns>
        /// Returns the next active object.
        /// </returns>
        /// </summary>
        public virtual T GetNextActive()
        {
            if (isFull())
                return default;

            return this[_tail + _head++];
        }

        /// <summary>
        /// Adds an object to the cache.
        /// Resizes the internal buffer
        /// if necessary.  Added objects
        /// are inactive by default.
        /// </summary>
        public virtual void Add(T obj)
        {
            if (isBufferFull())
            {
                int oldSize = _bufferObjects.Length;
                int newSize = Math.Max(_bufferObjects.Length * 2, 8);
                var temp = new T[newSize];

                Array.Copy(_bufferObjects, 0, temp, 0, _tail);
                Array.Copy(_bufferObjects, _tail, temp, _tail + oldSize, oldSize - _tail);

                _bufferObjects = temp;
            }

            _count++;

            this[_tail + _head++] = obj;
        }

        public override bool isEmpty()
        {
            return _head == 0;
        }

        public override bool isFull()
        {
            return _head == _count;
        }

        public bool isBufferFull()
        {
            return _head == _bufferObjects.Length;
        }

        public override T this[int key]
        {
            get => _bufferObjects[key % _count];
            protected set => _bufferObjects[key % _count] = value;
        }
    }
}
