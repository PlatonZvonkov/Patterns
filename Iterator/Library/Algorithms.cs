using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Algorithms
    {
        public Algorithms() { }
        public static int BinarySearch<T>(T[] array, T searchValue) where T : IComparable<T>
        {            
            int mid;
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                mid = left + ((right - left) / 2);
                if (array[mid].CompareTo(searchValue) == 0)
                {
                    return mid;
                }
                else
                {
                    if (array[mid].CompareTo(searchValue) > 0)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
            return -1;
        }
        public static IEnumerable<int> Fibonacci() 
        {
            int prev = 0; int current = 1;
            
            for (;;)
            {
                yield return prev;
                int sum = prev + current;
                prev = current;
                current = sum;
            }
        }
    }
}
