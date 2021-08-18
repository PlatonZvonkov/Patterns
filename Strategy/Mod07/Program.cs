using System;
using System.Linq;

namespace Mod07
{
    //делегат для передачи методов сравнения как аргументы в BubbleSortMatrix класс
    public delegate int Strategy(int[] row1, int[] row2);    
    public class Program
    {        
        int[][] matrix = new int[4][];

        private const string WELCOME_MSG = "You are given matrix: ";
        private const string WELCOME_OPTIONS = "\nYou Can:\n1 - Find Min numbers in each row and sort by them" +
            "\n 2 - Find Max numbers in each row and sort by them\n 3 - Find SUMM of each row and sort by it\n 0 - Exit";
        private const string SORTING_OPTIONS = "\nWhat Direction?\n 1 - Ascending\n2 - Discending\n 0 - Exit";
        //
        //сравнение строк по максимальных значениям
        public int EachRowMax(int[] row1, int[] row2)
        {           
            var max1 = row1.Max();
            var max2 = row2.Max();
            if (max1 < max2)
            { return 0; }
            return 1;
        }
        //
        //сравнение строк по минимальным значениям
        public int EachRowMin(int[] row1, int[] row2)
        {
            var min1 = row1.Min();
            var min2 = row2.Min();
            if (min1 < min2)
            { return 0; }
            return 1;
        }
        //
        //сравнение сумм значений в строках матрицы
        public int EachRowSum(int[] row1, int[] row2)
        {
            var sum1 = row1.Sum();
            var sum2 = row2.Sum();            
            if (sum1 > sum2)
            { return 0; }
            return 1;
        }
        //
        //метод вывода матрицы на экран
        private void PrintMatrix(int[][] matrix)
        {
            Console.WriteLine("");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine("");
            }
        }
        //
        //точка входа
        private static void Main(string[] args)
        {
            
            Program p = new Program();
            p.Init();
        }
        //
        //инициализация
        private void Init()
        {
            matrix[0] = new int[] { 2, 5, -3, 4 };
            matrix[1] = new int[] { 7, 10, 8, 1 };
            matrix[2] = new int[] { -2, 11, 6, 20 };
            matrix[3] = new int[] { 6, 9, 7, 3 };
            Console.WriteLine(WELCOME_MSG);                      
           
            while (true)
            {
                PrintMatrix(matrix); 
                Console.WriteLine(WELCOME_OPTIONS);
                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);
                    if (option == 1) { Min(); }
                    else if (option == 2) { Max(); }
                    else if (option == 3) { Sum(); }
                    else if (option == 0) { break; }
                }
                catch (Exception e)
                {
                    throw new Exception($"Wrong {nameof(input)}! " + e.Message);
                }
            }             
        }
        
        //
        //опции сортировки минимальных значений
        private void Min()
        {
            while (true)
            {
                Console.WriteLine(SORTING_OPTIONS);
                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);                    
                    if (option == 1)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowMin, Direction.Asc);
                        PrintMatrix(p);
                    }
                    else if (option == 2)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowMin, Direction.Desc);
                        PrintMatrix(p);
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Wrong {nameof(input)}!" + e.Message);
                }
            }
        }
        //
        //опции сортировки максимальных значений
        private void Max()
        {
            while (true)
            {
                Console.WriteLine(SORTING_OPTIONS);
                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);                    
                    if (option == 1)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowMax, Direction.Asc);
                        PrintMatrix(p);
                    }
                    else if (option == 2)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowMax, Direction.Desc);
                        PrintMatrix(p);
                    }
                    else if (option == 0)
                    {
                       break;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Wrong {nameof(input)}!" + e.Message);
                }
            }
        }
        //
        //опции сортировки сумм строк матрицы
        private void Sum()
        {
            while (true)
            {
                Console.WriteLine(SORTING_OPTIONS);
                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);                    
                    if (option == 1)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowSum, Direction.Asc);
                        PrintMatrix(p);
                    }
                    else if (option == 2)
                    {
                        var p = BubbleSortMatrix.SortTheMatrix(matrix, EachRowSum, Direction.Desc);
                        PrintMatrix(p);
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Wrong {nameof(input)}!" + e.Message);
                }
            }
        }
      
    }
}