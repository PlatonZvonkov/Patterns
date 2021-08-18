
namespace ClassLibrary
{
    public class Iterator<T> : Iteratable<T>
    {
        private readonly T[] array;

        private int position;

        public Iterator(T[] array)
        {
            this.array = array;
            this.position = -1;
        }               

        T Iteratable<T>.Current => array[position];

        public bool MoveNext()
        {
            if (++position == array.Length) return false;
            return true;
        }
    }
}
