using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(200);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    pb1.Dispatcher.Invoke(() => pb1.Value = i); // worker warte auf UI
                    Thread.Sleep(20);
                }

                pb1.Dispatcher.Invoke(() => ((Button)(sender)).IsEnabled = true);
            });
        }

        private void StartTaskMitTS(object sender, RoutedEventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            ((Button)(sender)).IsEnabled = false;
            cts = new CancellationTokenSource();

            var t1 = Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Task.Factory.StartNew(() => { pb1.Value = i; }, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(20);

                    if (i > 79)
                        throw new ArgumentOutOfRangeException();

                    if (cts.IsCancellationRequested)
                    {
                        //cleanup
                        //break;
                        cts.Token.ThrowIfCancellationRequested();
                    }
                }
            }, cts.Token);

            t1.ContinueWith(t => { ((Button)(sender)).IsEnabled = true; }, CancellationToken.None, TaskContinuationOptions.None, ts);
            t1.ContinueWith(t => { MessageBox.Show("OK"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.ContinueWith(t => { MessageBox.Show("Abbgebrochen"); }, TaskContinuationOptions.OnlyOnCanceled);
            t1.ContinueWith(t => { MessageBox.Show($"ERROR: {t.Exception.InnerException.Message}"); }, TaskContinuationOptions.OnlyOnFaulted);
        }
        CancellationTokenSource cts = null;
        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartTaskAA(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;
                await Task.Delay(20);
            }
            ((Button)(sender)).IsEnabled = true;
        }

        private async void StartTaskAlt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((await AlteUndLangsameFunktionAsync(100)).ToString());
        }

        long AlteUndLangsameFunktion(int zahl)
        {
            Thread.Sleep(5000);
            return zahl * 17;
        }

        Task<long> AlteUndLangsameFunktionAsync(int zahl)
        {
            return Task.Run(() => AlteUndLangsameFunktion(zahl));
        }

    }
}