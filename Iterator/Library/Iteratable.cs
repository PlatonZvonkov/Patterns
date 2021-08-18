
namespace ClassLibrary
{  
        public interface Iteratable<T>
        {
            T Current { get; }
            bool MoveNext();
        }
    
}
