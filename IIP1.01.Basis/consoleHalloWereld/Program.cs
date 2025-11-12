using System;

class Program
{
    static void Main()
    {
        const int MAX_AFHALING = 200;
        double saldo = 500.0;
        char keuze;

        do
        {
            Console.WriteLine("Bankautomaat");
            Console.WriteLine("============");
            Console.WriteLine();
            Console.WriteLine($"huidig saldo: € {saldo:0.000,00}");
            Console.WriteLine();
            Console.WriteLine("a. afhaling");
            Console.WriteLine("b. storting");
            Console.WriteLine("c. stoppen");
            Console.WriteLine();
            Console.Write("je keuze: ");
            keuze = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (keuze)
            {
                case 'a':
                    Console.Write("welk bedrag wil je afhalen: ");
                    if (double.TryParse(Console.ReadLine(), out double bedrag))
                    {
                        if (bedrag <= 0)
                            Console.WriteLine("\nfout: bedrag moet positief zijn");
                        else if (bedrag > Math.Min(MAX_AFHALING, saldo))
                            Console.WriteLine($"\nfout: je kan maximaal {Math.Min(MAX_AFHALING, saldo)} afhalen");
                        else if (bedrag % 10 != 0 || bedrag == 10 || bedrag == 30)
                            Console.WriteLine("\nfout: enkel briefjes van 20 en 50 zijn mogelijk");
                        else
                        {
                            saldo -= bedrag;
                            Console.WriteLine($"\nnieuw saldo: € {saldo:0.000,00}");
                        }
                    }
                    break;

                case 'b':
                    Console.Write("welk bedrag wil je storten: ");
                    if (double.TryParse(Console.ReadLine(), out double storting))
                    {
                        if (storting <= 0)
                            Console.WriteLine("\nfout: bedrag moet positief zijn");
                        else
                        {
                            saldo += storting;
                            Console.WriteLine($"\nnieuw saldo: € {saldo:0.000,00}");
                        }
                    }
                    break;

                case 'c':
                    Console.WriteLine("\nprogramma beëindigd");
                    break;

                default:
                    Console.WriteLine("\nonbekende keuze");
                    break;
            }

            Console.WriteLine();

        } while (keuze != 'c');
    }
}
