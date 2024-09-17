// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Diagnostics.Tracing;

AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    
    Console.WriteLine($"FATAL {e.ExceptionObject}");
}

Trace.Listeners.Clear();

Trace.Listeners.Add(new EventLogTraceListener("Application"));
Trace.Listeners.Add(new TextWriterTraceListener("log.txt") );
Trace.AutoFlush = true;

Console.WriteLine("Hello, World!");
Trace.WriteLine("App läuft");

for (int i = 0; i < 10; i++)
{
    var txt = $"{i:0000}";
    Console.WriteLine(txt);
    Trace.WriteLine($"Trace: {txt}");
    if (i > 5)
        throw new ExecutionEngineException();
}