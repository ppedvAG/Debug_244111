#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
Console.WriteLine("Hello TPL");

Task t1 = new Task(() =>
{
    Console.WriteLine("T1 gestartet");
    Thread.Sleep(1000);
    throw new FileNotFoundException();
    Console.WriteLine("T1 fertig");
});

t1.ContinueWith(t =>
{
    Console.WriteLine("T1 continue");
});

t1.ContinueWith(t =>
{
    Console.WriteLine("T1 OK");
},TaskContinuationOptions.OnlyOnRanToCompletion);

t1.ContinueWith(t =>
{
    Console.WriteLine($"T1 Error: {t1.Exception.InnerException.Message}");
}, TaskContinuationOptions.OnlyOnFaulted);

Task t2 = new Task(() =>
{
    Console.WriteLine("T2 gestartet");
    Thread.Sleep(2000);
    Console.WriteLine("T2 fertig");
});

t1.Start();
t2.Start();

#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
//Task.WaitAll(t1, t2);

Console.WriteLine("Ende");
Console.ReadLine();


//Parallel.For(0, 1_000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));
//Parallel.Invoke(ZeigeZahlen, ZeigeZahlen, ZeigeZahlen, ZeigeZahlen);

static void ZeigeZahlen()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
    }
}

