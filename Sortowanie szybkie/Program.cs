namespace Sortowanie_szybkie
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
            QuickSort(array, 0, array.Length-1);
            DisplayArray(array);
        }

        static float[] QuickSort(float[] array, int left, int right)
        {
            if(left >= right)
            {
                return array;
            }
            float pivot = Median(array[left], array[(left + right)/2], array[right]);
            int pivotIndex;
            if (pivot == array[left])
            {
                pivotIndex = left;
            }
            else if (pivot == array[(left + right)/2])
            {
                pivotIndex = (left+right)/2;
            }
            else
            {
                pivotIndex = right;
            }
            (array[pivotIndex], array[right]) = (array[right], array[pivotIndex]);
            int storeIndex = left;
            for (int i = left; i<right; i++)
            {
                if (array[i] < pivot)
                {
                    (array[storeIndex], array[i]) = (array[i], array[storeIndex]);
                    storeIndex++;
                }
            }
            (array[right], array[storeIndex]) = (array[storeIndex], array[right]);
            QuickSort(array, left, storeIndex-1);
            QuickSort(array, storeIndex + 1, right);
            return array;
        }

        static float Median(float first, float secound, float third)
        {
            if ((first >= secound && secound >= third) || (first <= secound && secound <= third))
            {
                return secound;
            }
            else if((secound >= first && first >= third) || (secound <= first && first <= third))
            {
                return first;
            }
            else
            {
                return third;
            }
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

        static float[] GetArray(int length)
        {
            float[] array = new float[length];
            for (int i = 0; i < length; i++)
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

