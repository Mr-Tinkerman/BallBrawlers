namespace TinkerLib.DataStructures
{
    public class CircularQueue<T> : GenericCircularBuffer<T>
    {
        public CircularQueue(int size = 0) : base(size) { }

        int _index;

        public void Enqueue(T value)
        {
            // If Enqueue() is called when the queue
            // is full, the tail is moved and that tail
            // item in the queue can be considered lost
            _tail = (_tail + (isFull() ? 1 : 0)) % _bufferObjects.Length;
            _head = (_head + 1) % _bufferObjects.Length;

            _bufferObjects[_head] = value;
        }

        public T Dequeue()
        {
            if (isEmpty())
                return default;

            _tail = (_tail + 1) % _bufferObjects.Length;

            return _bufferObjects[_tail];
        }

        public T Peek()
        {
            _index = (_tail + (isEmpty() ? 0 : 1)) % _bufferObjects.Length;

            return _bufferObjects[_index];
        }
    }
}