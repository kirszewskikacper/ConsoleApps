namespace Sortowanie_przez_wstawianie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] array = GetArray(ArrayLenght());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTablica przed sortowaniem:\n");
            Console.ResetColor();
            DispalyArray(array);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTablica po sortowaniu:\n");
            Console.ResetColor();
            InsertionSort(array);
            DispalyArray(array);
        }

        static float[] InsertionSort(float[] array)
        {
            for(int i = 1; i<array.Length; i++)
            {
                float key = array[i];
                for(int j = i-1; j>=0; j--)
                {
                    if (array[j] > key)
                    {
                        array[j+1] = array[j];
                    }
                    else
                    {
                        break;
                    }
                    array[j] = key;
                       
                }
            }


            return array;
        }

        static int ArrayLenght()
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
                num = ArrayLenght();
            }
            return num;
        }

        static void DispalyArray(float[] array)
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
