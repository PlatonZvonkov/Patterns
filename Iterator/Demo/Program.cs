using System;
using System.Threading.Tasks;
using ClassLibrary;

namespace Demo
{
    class Program
    {
        
        public const string WELCOME_MSG = "Welcome To Demo of ClassLibrary";
        public const string WELCOME_OPTIONS = "Choose Methods to Demonstrate:" +
            "\n1 - BinarySearch\n2 - Fibonacci's numbers\n3 - Queue Methods\n4 - Stack Methods\n(type:...)"; 
        static void Main(string[] args)
        {            
            Program p = new Program();
            p.Start();            
        }
        public void Start()
        {            
            Console.WriteLine(WELCOME_MSG);            
            while (true)
            {
                Console.WriteLine(WELCOME_OPTIONS);
                var input = Console.ReadLine();
                
                if (input == "binary"|| input == "search"|| input == "binarysearch" || input == "1")
                {
                    BinarySearchLogic();
                }
                else if (input == "fibonacci" || input == "Fibonacci's" || input == "Fibonacci's numbers" || input == "2")
                {
                    FibonacciLogic();
                }
                else if(input == "queue"|| input == "Queue" || input == "3")
                {
                    QueueLogic();
                }
                else if (input == "stack"|| input == "stack"||input == "4")
                {
                    StackLogic();
                }
                else
                {
                    Console.WriteLine("I dont understand you, try again");
                }
            }
        }
        
        private void QueueLogic()
        {            
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(23);
            queue.Enqueue(32);
            queue.Enqueue(54);            
            queue.Enqueue(46);

            //Iterate throwgh Collection with ForEach
            Console.WriteLine("Created Queue:");
            foreach (var x in queue)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Total number of items is " + queue.Count);
        }
        private void StackLogic()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(23);
            stack.Push(32);
            stack.Push(54);            
            stack.Push(44);

            //Iterate throwgh Collection with While
            Console.WriteLine("Created Stack:");
            var iterator = stack.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            Console.WriteLine("Total number of items is " + stack.Count);
        }

        async private void FibonacciLogic()
        {
            Console.Write("Enter length of Fibonacci sequence: ");
            int length;
            string input = Console.ReadLine();
            
            if (Int32.TryParse(input, out length))
            {
                var fibonacciSequence = Algorithms.Fibonacci();
                //Draw numbers biutifully
                foreach (int f in fibonacciSequence)
                {
                    await Task.Delay(100);  Console.WriteLine($"{f} ");                
                }
            }
            else
            {
                Console.WriteLine("I dont understand you, try again");
            }
        }

        public void BinarySearchLogic()
        {           
            char[] array = new char[7] {'a','b','c','d','e','f','j'};
            foreach (var x in array)
            {
                Console.WriteLine(x);
            }

            Console.Write("Enter value to search: ");
            var searchvalue = Console.ReadLine();
            
            if (searchvalue != null)
            {
                if (Algorithms.BinarySearch(array, Char.Parse(searchvalue)) != -1)
                {
                    Console.WriteLine("Value found at position: "
                 + Algorithms.BinarySearch(array, Char.Parse(searchvalue)));
                }
                else
                {
                    Console.WriteLine($"value you entered is not there");
                }
            }
            else
            {
                Console.WriteLine("I dont understand you, try again");
            }   
        }
    }
}
