using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class MyQueue<T> 
    { 
        private T[] array;
        private int size;
        private int head = 0; // First valid element in the queue
        private int tail;
        public MyQueue() {  }

        public int Count{get{
                if (array == null)
                {
                    return 0;
                }
           return array.Length; }
        }
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            T removed = array[head];
            array[head] = default(T);
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize<T>(ref array, size -1);            
            size--;
            tail--;
            return removed;
        }
        public void Enqueue(T item)
        {            
            if (array == null)
            {
                T[] newArray = new T[size + 1];
                array = newArray;
            }            
            Array.Resize<T>(ref array, size + 1);
            array[array.Length -1] = item;
            tail = array.Length;
            size++;
        }
        public void Clear()
        {
            if (head < tail)
            {
                Array.Clear(array, head, size);
            }
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, tail);
            }            
            tail = 0;
            size = 0;
            Array.Resize<T>(ref array, size);
        }
    
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            return array[head];
        }
        public virtual T[] ToArray()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            T[] objArray = new T[size];
            int i = 0;
            while (i < size)
            {
                objArray[i] = array[i];
                i++;
            }
            return objArray;
        }
       
        public Iteratable<T> GetEnumerator()
        {
            return new Iterator<T>(array);
        }
    }
}
