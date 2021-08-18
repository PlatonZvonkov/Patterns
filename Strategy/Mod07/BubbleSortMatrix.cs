using System;


namespace Mod07
{
    public class BubbleSortMatrix
    {
        public BubbleSortMatrix() { }
        //
        //алгоритм сортировки пузырьком с аргументами - массив, метод фильтрации, направление сортировки
        public static int[][] SortTheMatrix(int[][] matrix, Strategy strategy, Direction direction = Direction.Asc)
        {            
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException($"{nameof(matrix)} is null");
            }            
            //Сортировка пузырьком строк между собой
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix.Length-1; ++j)
                {                   
                    if (direction == Direction.Asc) //если направление на возрастание значений строк то
                    {
                        if (strategy.Invoke(matrix[i],matrix[j]) == 0)// Вызов стратегии
                        {
                            Swap(matrix, i, j);
                        }
                    }
                    else //если по убыванию то
                    {
                        if (strategy.Invoke(matrix[i],matrix[j]) == 1)// Вызов стратегии
                        {
                             Swap(matrix, i, j);
                        }
                    }
                }
            }

            return matrix;
        }
        public static void Swap(int[][]matrix, int row,int row2)
        {
            var temp = matrix[row];
            matrix[row] = matrix[row2];
            matrix[row2] = temp;

        }
    }
}