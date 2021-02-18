using System;

namespace Felhantering
{
    internal class Program
    {
        /**
         * Felhantering & undantag
         *
         * Materialet hämtat från csharpskolan.se
         *
         **/

        private static void Main(string[] args)
        {
            //Skriv ut menyalternativ
            Console.WriteLine("Felhantering och undantag");
            Console.WriteLine("*************************");
            Console.WriteLine("1. Exempel 1 - Utan felhantering med metoden Parse.");
            Console.WriteLine("2. Exempel 2 - Planera för fel med metoden TryParse.");
            Console.WriteLine("3. Exempel 3 - Felhantering med undantag.");
            Console.WriteLine("4. Övning 7");

            Console.WriteLine();

            //Läs in menyval
            Console.Write("Ange siffra för vad du vill göra: ");
            string val = Console.ReadLine();

            //Ett par tomma rader
            Console.WriteLine();
            Console.WriteLine();

            //Använd en switch-sats för att anropa den metod som hör ihop med menyvalet.
            switch (val)
            {
                case "1":
                    Exempel1();
                    break;

                case "2":
                    Exempel2();
                    break;

                case "3":
                    Exempel3();
                    break;

                case "4":
                    Ovning7();
                    break;
            }

            Console.ReadKey();
        }

        private static void Exempel1()
        {
            /*
             * Exempel 1.
             * Beräkning av timlön.
             * Utan felhantering
             */
            int inkomst, timmar;

            while (true)
            {
                try
                {
                    Console.Write("Ange din inkomst: ");
                    inkomst = int.Parse(Console.ReadLine());
                    Console.Write("Ange antal timmar: ");
                    timmar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void Exempel2()
        {
            /*
             * Exempel 2.
             * Beräkning av timlön.
             * Planera för fel med metoden TryParse.
             */

            int inkomst = 0;
            int timmar = 0;

            inkomst = ErrorHandling("inkomst: ");
            timmar = ErrorHandling("antal timmar: ");
            //Nollställ variabeln

            Console.WriteLine("Din timlön blev: " + (inkomst / timmar) + " kr/h.");
        }

        private static void Exempel3()
        {
            /*
             * Exempel 3.
             * De viktigaste ingredienserna i undantagshantering
             */
            while (true)
            {
                try
                {
                    Console.Write("Ange ett heltal: ");
                    int heltal = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Format " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Programmet har stött på ett fel.");
                }
            }

            Console.WriteLine("Programmet avslutades korrekt.");
        }

        private static int ErrorHandling(string question)
        {
            bool inmatat = false;
            int value = 0;

            while (!inmatat)
            {
                Console.Write(question);
                inmatat = int.TryParse(Console.ReadLine(), out value);
                if (!inmatat)
                {
                    Console.WriteLine("Försök igen\n");
                }
            }

            return value;
        }

        private static int ErrorHandling2(string question)
        {
            int value = 0;

            while (true)
            {
                try
                {
                    Console.Write(question);
                    value = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return value;
        }

        private static void Ovning7()
        {
            int start = ErrorHandling2("Mata in start: ");

            int stopp = ErrorHandling2("\nMata in stopp: ");

            int steg = ErrorHandling2("\nMata in steg: ");

            Console.WriteLine(); // finare i konsollen
            for (int i = start; i <= stopp; i += steg)
            {
                Console.Write(i + " ");
            }
        }
    }
}