using System;

namespace ClassLibrary
{
    public class MyStack<T> 
    {
        private int size;
        private T[] array;
        private int top;
        public MyStack() { }
        
        public int Count { get {
                if (array == null)
                {
                    return 0;
                }
                return array.Length;
            }
        }
     
        public void Push(T Element)
        {
            if (array == null)
            {
                T[] newArray = new T[size+1];
                array = newArray;
            }
            Array.Resize<T>(ref array, size + 1);
            array[array.Length - 1] = Element;
            top = array.Length;
            size++;
        }
        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("InvalidOperation_EmptyStack");
            }

            if (array == null)
            {
                throw new NullReferenceException("InvalidOperation_EmptyStack");
            }

            object obj = array[size-1];
            Array.Resize<T>(ref array, size -1);
            size--;
            top--;
            return (T)obj;
        }
        public T Peek()
        {
            if (array == null)
            {
                throw new NullReferenceException("InvalidOperation_EmptyStack");
            }

            return array[top-1];           
        }
        public virtual void Clear()
        {
            Array.Clear(array, 0, size);
            size = 0;
            top = 0;
            Array.Resize<T>(ref array, size);
        }
        public T[] ToArray()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            }

            T[] objArray = new T[size];
            int i = 0;
            while (i < size)
            {
                objArray[i] = array[size - i - 1];
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
