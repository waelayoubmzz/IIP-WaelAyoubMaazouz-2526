using System;
using System.Text;

namespace ConsoleSnoepmachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double saldo = 0;
            bool bezig = true;

            while (bezig)
            {
                Console.Clear();
                Console.WriteLine("SNOEPMACHINE 🍭🥤");
                Console.WriteLine(@$"
a. Geld inwerpen
b. Drank kopen (2,00 euro)
c. Snoep kopen (1,50 euro)
d. Stoppen

Huidig saldo: {saldo:0.0} euro 🪙
");
                Console.Write("Maak je keuze: ");
                string keuze = Console.ReadLine()?.ToLower();

                switch (keuze)
                {
                    case "a":
                        Console.Write("Inworp: ");
                        if (double.TryParse(Console.ReadLine(), out double bedrag) && bedrag > 0)
                        {
                            saldo += bedrag;
                            Console.WriteLine($"Je hebt {bedrag:0.0} euro toegevoegd.");
                        }
                        else
                        {
                            Console.WriteLine("Alleen muntstukken van 0,50 euro of veelvouden daarvan zijn toegelaten.");
                        }
                        break;

                    case "b":
                        if (saldo >= 2.00)
                        {
                            saldo -= 2.00;
                            Console.WriteLine("Je drankje komt eraan!");
                        }
                        else
                        {
                            Console.WriteLine("Je saldo is te laag; gelieve nog geld in te werpen.");
                        }
                        break;

                    case "c":
                        if (saldo >= 1.50)
                        {
                            saldo -= 1.50;
                            Console.WriteLine("Je snoepje komt eraan!");
                        }
                        else
                        {
                            Console.WriteLine("Je saldo is te laag; gelieve nog geld in te werpen.");
                        }
                        break;

                    case "d":
                        bezig = false;
                        Console.WriteLine($"Je krijgt {saldo:0.0} euro terug.");
                        break;

                    default:
                        Console.WriteLine($"'{keuze}' is geen geldige keuze, druk op een toets on verder te gaan...");
                        break;
                }

                if (bezig)
                {
                    Console.WriteLine("\nTerug");
                    Console.ReadKey();
                }
            }
        }
    }
}
