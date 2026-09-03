namespace kosci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kontynuowanie_gry = true;

            int liczba_kosci = 0;
            while (liczba_kosci < 3 || liczba_kosci > 10)
            {
                Console.WriteLine("Ile kostek chcesz rzucić?(3 - 10)");
                string wybrana_ilosc = Console.ReadLine();
                liczba_kosci = int.Parse(wybrana_ilosc);
            }

            while (kontynuowanie_gry)
            {
                

                int[] kosci = rzut(liczba_kosci);
                for (int i = 0; i < liczba_kosci; i++)
                {
                    Console.WriteLine($"Kostka {i + 1}: {kosci[i]}");
                }
                Console.WriteLine($"Liczba uzyskanych punktów: {zliczenie_punktow(kosci)}");

                Console.WriteLine("Jeszcze raz? (t/n)");
                string input = Console.ReadLine();
                if(input == "n")
                {
                    kontynuowanie_gry = false;
                }
            }
            
        }

        static int[] rzut(int ilosc)
        {
            int[] kosci = new int[ilosc];
            for (int i = 0; i<ilosc; i++)
            {
                kosci[i] = Random.Shared.Next(1, 7);
            }
            
            return kosci;
        }

        static int zliczenie_punktow(int[] kosci)
        {
            int wynik = 0;
            int[] ilosc_danych_kosci = { 0, 0, 0, 0, 0, 0 };
            foreach (int kosc in kosci)
            {
                switch (kosc)
                {
                    case 1:
                        ilosc_danych_kosci[0]++;
                        break;
                    case 2:
                        ilosc_danych_kosci[1]++;
                        break;
                    case 3:
                        ilosc_danych_kosci[2]++;
                        break;
                    case 4:
                        ilosc_danych_kosci[3]++;
                        break;
                    case 5:
                        ilosc_danych_kosci[4]++;
                        break;
                    case 6:
                        ilosc_danych_kosci[5]++;
                        break;
                }
            }
            for(int i = 0; i < 6; i++)
            {
                if (ilosc_danych_kosci[i] > 1)
                {
                    wynik += ilosc_danych_kosci[i] * (i + 1);
                }
            }
            return wynik;
        }
    }
}
