using System;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            #region двумерный массив m*n случайными вещественными числами
            int m = printInputInt("----------------------------------------\nВведите количество столбцов матрицы"),
                n = printInputInt("\nВведите количество строк матрицы");
            double[,] arrDouble = CreateRandomDoubleMatrix(m, n, -99, 99, 2);
            print($"\nСозданная матрица вещественных чисел: {DoubleMatrixToString(arrDouble)}");
            #endregion
            #region есть ли заданные позиции в двумерном массиве

            int i = printInputInt("\n----------------------------------------\nВведите интересующий вас столбец в выведенном двумерном массиве"),
                j = printInputInt("\nВведите интересующую вас строку в выведенном двумерном массиве");
            print($"\nВыбранное значение = {CheckPosistionOnDoubleMatrix(arrDouble, i - 1, j - 1)}\n");
            #endregion
            #region среднее арифметическоев каждом столбце двумерного массива с целыми числами
            int[,] arrInt = CreateRandomIntMatrix(m, n, -99, 99);
            print($"----------------------------------------\nСозданная матрица целых чисел:\n{IntMatrixToString(arrInt)}");
            print($"\nСреднее арифметическое столбцов:\n{MeanOfColumns(arrInt, 2)}");
            #endregion
        }

        /// <summary>
        /// удобство вывода без лишнего текста
        /// </summary>
        /// <param name="mes">текст для вывода в консоль</param>
        static void print(string mes)
        {
            Console.WriteLine(mes);
        }

        /// </summary>
        /// отображение сообщения, прием из консоли значения, перевод полученного значения в число
        /// <param name="mes">сообщение перед запросом числа</param>
        /// <returns>число, введенное пользователем в консоли</returns>
        static int printInputInt(string mes)
        {
            Console.WriteLine(mes);
            int.TryParse(Console.ReadLine(), out int userNumber);
            return userNumber;
        }

        /// <summary>
        /// Создание матрицы случайных вещественных чисел
        /// </summary>
        /// <param name="sizeM">количество столбцов</param>
        /// <param name="sizeN">количество строк</param>
        /// <param name="min">минимально возможное значение</param>
        /// <param name="max">максимально возможное значение</param>
        /// <param name="round">округление знаков после запятой</param>
        /// <returns>матрица случайных вещественных чисел</returns>
        static double[,] CreateRandomDoubleMatrix(int m, int n, double min, double max, int round)
        {
            double[,] arr = new double[m, n];
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] += Math.Round(new Random().NextDouble() * (max - min) + min, round);
                }
            }
            return arr;
        }

        /// <summary>
        /// Создание матрицы случайных целых чисел
        /// </summary>
        /// <param name="sizeM">количество столбцов</param>
        /// <param name="sizeN">количество строк</param>
        /// <param name="min">минимально возможное значение</param>
        /// <param name="max">максимально возможное значение</param>
        /// <returns>матрица случайных целых чисел</returns>
        static int[,] CreateRandomIntMatrix(int m, int n, int min, int max)
        {
            int[,] arr = new int[m, n];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] += new Random().Next(min, max + 1);
                }
            }
            return arr;
        }

        /// <summary>
        /// Перевод матрицы вещественных чисел в форматированную строку
        /// </summary>
        /// <param name="arr">матрица вещественных чисел</param>
        /// <returns>форматированная строка вещественных чисел</returns>
        static string DoubleMatrixToString(double[,] arr)
        {
            string z = "";
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                z += "\n";
                for (int i = 0; i < arr.GetLength(0); i++)
            {
                    z+= ($"{arr[i, j]}\t");
                }
            }
            return z;
        }

        /// <summary>
        /// Перевод матрицы целых чисел в форматированную строку
        /// </summary>
        /// <param name="arr">матрица целых чисел</param>
        /// <returns>форматированная строка целых чисел</returns>
        static string IntMatrixToString(int[,] arr)
        {
            string z = "";
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                z += "\n";
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    z += ($"{arr[i, j]}\t");
                }
            }
            return z;
        }

        /// <summary>
        /// Проверка заданной позиции в матрице на существование и ее вывод
        /// </summary>
        /// <param name="arr">матрица вещественных чисел</param>
        /// <param name="m">номер стобца</param>
        /// <param name="n">номер строки</param>
        /// <returns>строка с выводом значения, либо сообщения об ошибке</returns>
        static string CheckPosistionOnDoubleMatrix(double[,] arr, int m, int n)
        {
            if (arr.GetLength(0) < m || arr.GetLength(1) < n || m < 0 || n < 0)
            {
                return "Заданные значения не существуют в заданном массиве";
            }
            return arr[m,n].ToString();
        }

        /// <summary>
        /// Рассчет средних значений в столбце матрицы и перевод их в форматированную строку
        /// </summary>
        /// <param name="arr">матрица целых чисел</param>
        /// <param name="round">округление знаков после запятой</param>
        /// <returns>форматированная строка средних значений в столбце матрицы</returns>
        static string MeanOfColumns(int [,] arr, int round)
        {
            int[] tempArr = new int[arr.GetLength(0)];
            string z = "";

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    tempArr[i] += arr[i, j];
                }
            }

            for (int i = 0; i < tempArr.Length; i++)
            {
                z += $"{Math.Round((double)tempArr[i] / arr.GetLength(1), round)}\t";
            }
            return z;
        }
    }
}