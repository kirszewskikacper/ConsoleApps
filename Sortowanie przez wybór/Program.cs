namespace Sortowanie_przez_wybór
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] array = GetArray(ArrayLength());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTablica przed sortowaniem:\n");
            Console.ResetColor();
            DisplayArray(array);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTablica po sortowaniu:\n");
            Console.ResetColor();
            SelectionSort(array);
            DisplayArray(array);
        }

        static float[] SelectionSort(float[] array)
        {
            
            for (int i = 0; i < array.Length; i++)
            {
                int min_place = i;
                for (int j = i; j< array.Length; j++)
                {
                    if (array[min_place] > array[j])
                    {
                        min_place = j;
                    }
                }
                (array[i], array[min_place]) = (array[min_place], array[i]);
            }
            return array;
        }

        static int ArrayLength()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Podaj długoś tablicy");
            Console.ResetColor();
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num < 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPodano błędne dane!");
                Console.ResetColor();
                Console.WriteLine("Podaj dowolną liczbę naturalną dodatnią\n");
                num = ArrayLength();
            }
            return num;
        }

        static void DisplayArray(float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1}. element: {array[i]}");
            }
        }

        static float[] GetArray(int lenght)
        {
            float[] array = new float[lenght];
            for (int i = 0; i < lenght; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nPodaj element numer {i + 1}");
                Console.ResetColor();
                if (float.TryParse(Console.ReadLine(), out float number))
                {
                    array[i] = number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodano błędne dane!");
                    Console.ResetColor();
                    Console.WriteLine("Podaj dowolną liczbę zmiennoprzecinkową\n");
                    i--;
                }
            }
            return array;
        }
    }
}
