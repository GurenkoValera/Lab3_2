using System;

class Program
{
    static void Main()
    {
        // Создание и заполнение двумерного массива 7x7
        int[,] array = new int[7, 7];
        Random random = new Random();

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                array[i, j] = random.Next(1, 10); // Заполнение массива случайными числами от 1 до 9
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Поворот массива на 90 градусов вправо
        RotateArray(array);

        Console.WriteLine("\nПовернутый массив на 90 градусов вправо:");
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void RotateArray(int[,] array)
    {
        int n = array.GetLength(0); // Получаем размерность массива

        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - layer - 1;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;
                // Сохраняем верхний элемент
                int top = array[first, i];

                // Перемещаем левый элемент в верхний
                array[first, i] = array[last - offset, first];

                // Перемещаем нижний элемент в левый
                array[last - offset, first] = array[last, last - offset];

                // Перемещаем правый элемент в нижний
                array[last, last - offset] = array[i, last];

                // Сохраняем верхний элемент в правый
                array[i, last] = top;
            }
        }
    }
}