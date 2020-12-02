using System;

namespace One
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
        //Функция, выводящая минимальный элемент массива
        static void ShowMin(double[] mas)
        {
            double min = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            Console.WriteLine($"Минимальный элемент: {min}");
        }
        //Функция, выводящая сумму элементов массива, расположенных между первым и последним положительным элементом
        static void FindSum(double[] mas)
        {
            double sum = 0;
            int first = -1, last = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    first = i;
                    break;
                }
            }
            if (first != -1)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] > 0)
                    {
                        last = i;
                    }
                }
                if (first == last)
                {
                    last = mas.Length;
                }
                for (int i = first + 1; i < last; i++)
                {
                    sum += mas[i];
                }
                sum = Math.Round(sum, 2);
            }
            Console.WriteLine($"Искомая сумма: {sum}");
        }
        //Функция, преобразующая массив таким образом, чтобы сначала располагались элементы, равные нулю, а потом остальные
        static void ConvertMas(double[] mas)
        {
            int k = 0;
            double boo;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 0)
                {
                    for (int j = i; j > k; j--)
                    {
                        boo = mas[j - 1];
                        mas[j - 1] = mas[j];
                        mas[j] = boo;
                    }
                    k++;
                }
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Введите размер массива n(n > 0): ");
            int n = CheckPosNumber(CheckNumber(Console.ReadLine()));
            double[] mas = new double[n];
            Console.Write("Массив:\r\n[ ");
            for (int i = 0; i < n; i++)
            {
                mas[i] = Math.Round(rand.NextDouble() * 10 - 5, 2);
                Console.Write($"{mas[i]} ");
            }
            Console.Write("]\r\n");
            ShowMin(mas);
            FindSum(mas);
            ConvertMas(mas);
            Console.Write("Преобразованный массив:\r\n[ ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]} ");
            }
            Console.Write("]\r\n");
        }
    }
}
