using System;
using System.Collections.Generic;
using System.Threading;


internal class Program
{
    class Pizza
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        System.Diagnostics.Debug.WriteLine("DEBUGGER");
        System.Diagnostics.Debugger.Break();

        //if(!System.Diagnostics.Debugger.IsAttached)
        //    System.Diagnostics.Debugger.Launch();

        FüllePizza();

#if DEBUG
        Console.WriteLine("DEBUG");
#endif

        try
        {

            for (int i = 0; i < 10; i++)
            {
                ZeigeZahl(i);
            }
        }
        catch (Exception)
        {

            Console.WriteLine("PANIK!!!!");
            Console.ReadLine();
        }
    }

    private static void FüllePizza()
    {
        List<Pizza> list = new List<Pizza>();
        long p = 0;
        while (true)
        {
            list.Add(new Pizza() { Name = $"Pizza #{p}", Price = 12.50m });
            p++;
            if (p > 10_000_000)
                break;
        }
    }

    private static void ZeigeZahl(int i)
    {
        ZeigeZahlMitDatum(i);
    }

    private static void ZeigeZahlMitDatum(int i)
    {
        Console.WriteLine($"[{DateTime.Now:g}] {i}");
        if (i > 6)
        {
            int zahl = 12 / int.Parse("0");
        }

        Thread.Sleep(1000);
    }
}