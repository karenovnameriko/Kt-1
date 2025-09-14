using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class MyArr
    {
        int[] arr;
        public int Length;
        private static Random random = new Random();

        public MyArr(int Size)
        {
            arr = new int[Size];
            Length = Size;
            for (int i = 0; i < Size; i++)
            {
                arr[i] = random.Next(0, 100);
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива [0, {Length - 1}]");
                return arr[index];
            }

            set
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива [0, {Length - 1}]");
                arr[index] = value;
            }
        }

        // Перегружаем индексатор для дробных значений
        public int this[double index]
        {
            get
            {
                int intIndex = (int)Math.Round(index);
                if (intIndex < 0 || intIndex >= Length)
                    throw new IndexOutOfRangeException($"Индекс {intIndex} выходит за границы массива [0, {Length - 1}]");
                return arr[intIndex];
            }

            set
            {
                int intIndex = (int)Math.Round(index);
                if (intIndex < 0 || intIndex >= Length)
                    throw new IndexOutOfRangeException($"Индекс {intIndex} выходит за границы массива [0, {Length - 1}]");
                arr[intIndex] = value;
            }
        }

        public void PrintArray()
        {
            Console.Write("Массив: [");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(arr[i]);
                if (i < Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    // 1. Предлагаем пользователю задать количество элементов
                    Console.Write("Введите количество элементов массива: ");
                    int size = int.Parse(Console.ReadLine());

                    if (size <= 0)
                    {
                        Console.WriteLine("Размер массива должен быть положительным числом!");
                        Console.WriteLine();
                        continue;
                    }

                    // 2. Создаем и заполняем массив случайными числами
                    MyArr arr = new MyArr(size);
                    Console.WriteLine("Массив создан и заполнен случайными числами:");
                    arr.PrintArray();

                    // 3. Запрашиваем дробный индекс у пользователя
                    Console.Write("Введите индекс элемента (дробное число): ");
                    double index = double.Parse(Console.ReadLine());

                    // 4. Округляем и проверяем индекс
                    int roundedIndex = (int)Math.Round(index);
                    Console.WriteLine($"Округленный индекс: {roundedIndex}");

                    // 5. Проверка индекса и вывод значения
                    int value = arr[index]; // Используем дробный индексатор
                    Console.WriteLine($"Значение = {value}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}