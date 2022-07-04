namespace TinkerLib.DataStructures
{
    public abstract class GenericCircularBuffer<T>
    {
        protected T[] _bufferObjects;
        protected int _head = 0;
        protected int _tail = 0;

        protected GenericCircularBuffer(int size)
        {
            _bufferObjects = new T[size];
            _head = 0;
            _tail = 0;
        }

        public virtual bool isEmpty()
        {
            return _head == _tail;
        }

        public virtual bool isFull()
        {
            return (_head + 1) % _bufferObjects.Length == _tail;
        }

        public virtual T this[int key]
        {
            get => _bufferObjects[key % _bufferObjects.Length];
            protected set => _bufferObjects[key % _bufferObjects.Length] = value;
        }
    }
}
