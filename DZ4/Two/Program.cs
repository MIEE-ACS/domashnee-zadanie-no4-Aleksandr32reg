using System;

namespace Two
{
    class Program
    {
        //Функция, проверяющая ввод на целое число
        static int CheckNumber(string input)
        {
            int num;
            if (int.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                Console.Write("Некорректный ввод. Вы ввели строку\r\nВвод: ");
                return CheckNumber(Console.ReadLine());
            }
        }
        //Функция, проверяющая ввод на положительное число
        static int CheckPosNumber(int input)
        {
            if (input > 0)
            {
                return input;
            }
            else
            {
                Console.Write("Некорректный ввод. Вы ввели отрицательное число или 0.\r\nВвод: ");
                return CheckPosNumber(CheckNumber(Console.ReadLine()));
            }
        }
        //Функция, проверяющая содержит ли указанная строка отрицаетльные элементы
        static bool NegInStr(int[,] mas, int n, int m)
        {
            for (int j = 0; j < m; j++)
            {
                if (mas[n, j] < 0)
                {
                    return true;
                }
            }
            return false;
        }
        //Функция, возвращающая суммы элементов в строках, которые содержат хотя бы одно отрицательное число
        static void FindSums(int[,] mas, int n, int m)
        {
            int sum;
            Console.WriteLine("Список сумм элементов в строках, которые содержат хотя бы одно отрицательное число:");
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                if (NegInStr(mas, i, m))
                {
                    for (int j = 0; j < m; j++)
                    {
                        sum += mas[i, j];
                    }
                    Console.WriteLine("Строка №{0,2}: {1}", i + 1, sum);
                }
            }
        }
        //Функция, находящая седловые точки матрицы и возвращающая её номер строки и столбца
        static void FindSaddlePoints(int[,] mas, int n, int m)
        {
            int min, minIndex = 0, max, maxIndex;
            int[] minStr = new int[n];
            for (int i = 0; i < n; i++)
            {
                min = mas[i, 0];
                minIndex = 0;
                for (int j = 1; j < m; j++)
                {
                    if (mas[i, j] < min)
                    {
                        min = mas[i, j];
                        minIndex = j;
                    }
                }
                minStr[i] = minIndex;
            }
            Console.WriteLine("Седловые точки:");
            for (int j = 0; j < m; j++)
            {
                max = mas[0, j];
                maxIndex = 0;
                for (int i = 1; i < n; i++)
                {
                    if (mas[i, j] > max)
                    {
                        max = mas[i, j];
                        maxIndex = i;
                    }
                }
                if (minStr[maxIndex] == j)
                {
                    Console.WriteLine("Значение: {0}; Строка: {1}; Столбец: {2}", mas[maxIndex, minIndex], maxIndex + 1, minIndex + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Укажите количество строк матрицы n(n > 0): ");
            int n = CheckPosNumber(CheckNumber(Console.ReadLine()));
            Console.Write("Укажите количество столбцов матрицы m(m > 0): ");
            int m = CheckPosNumber(CheckNumber(Console.ReadLine()));
            int[,] mas = new int[n, m];
            Console.Write("\r\nМатрица:\r\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("[");
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rand.Next(-10,10);
                    Console.Write("{0,3} ", mas[i, j]);
                }
                Console.Write("]\r\n");
            }
            FindSums(mas, n, m);
            FindSaddlePoints(mas, n, m);
        }
    }
}