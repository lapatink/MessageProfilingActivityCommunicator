using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
    class RingBuffer<T>
    {
        private int size;
        private Queue<T> buffer;

        public RingBuffer(int size = 1000)
        {
            this.size = size;
            buffer = new Queue<T>();
        }

        public void putData(T data)
        {
            if (buffer.Count < size)
                buffer.Enqueue(data);
            else
            {
                buffer.Dequeue();
                buffer.Enqueue(data);
            }
        }

        public void putData(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
                putData(data[i]);
        }

        public T getData()
        {
            return buffer.Dequeue();
        }

        public T[] getAllData()
        {
            T[] ret = buffer.ToArray();
            Empty();
            return ret;
        }

        public T peek()
        {
            return buffer.Peek();
        }

        public T[] peekAll()
        {
            return buffer.ToArray();
        }

        public bool isEmpty()
        {
            return (buffer.Count == 0);
        }

        public void Empty()
        {
            buffer = new Queue<T>();
        }

        public int Size
        {
            get { return buffer.Count; }
        }

        public override string ToString()
        {
            string s = string.Empty;
            T[] d = buffer.ToArray();
            for (int i = 0; i < d.Length; i++)
                s += d[i].ToString() + ((i < (d.Length - 1)) ? ", " : string.Empty);
            return s;
        }

    }
}
