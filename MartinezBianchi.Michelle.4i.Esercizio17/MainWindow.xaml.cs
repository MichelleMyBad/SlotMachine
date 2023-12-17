using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SlotMachine;

namespace MartinezBianchi.Michelle._4i.Esercizio17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {

        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            InizzializzaTimer();
        }

        Slot slot = new Slot();

        void InizzializzaTimer() {
        
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += Timer_Tick; // += aggiunge a tick il metodo TimerTick. Tick è una lista.

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            SlotButton.Content = FindResource("Play");

            slot.Roll();
            tentativi.Text = slot.Counter.ToString();
            if (slot.Counter == 3)
            {
                let1.IsEnabled = true;
                let2.IsEnabled = true;
                let3.IsEnabled = true;
            }
            let1.Text = Enum.GetName(typeof(Lettere), slot.Let1);
            let2.Text = Enum.GetName(typeof(Lettere), slot.Let2);
            let3.Text = Enum.GetName(typeof(Lettere), slot.Let3);
            vinti.Text = slot.Win.ToString();
            saldo.Text = slot.Monete.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (saldo.Text != "0")
            {
                if (SlotButton.Content == FindResource("Play"))
                {
                    SlotButton.Content = FindResource("Stop");
                    timer.Start();
                }
                else
                {
                    SlotButton.Content = FindResource("Play");
                }



            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Monete = 0;
            int tot = Convert.ToInt32( saldo.Text);
            int.TryParse(MonAdd.Text, out Monete);
            slot.Inserisci(Monete);
            tot += Monete;
            saldo.Text = tot.ToString();
            MonAdd.Text = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int vincita = Convert.ToInt32(saldo.Text);

            if(vincita > 0)
            {
                slot.Ritira();
                MessageBox.Show($"Complimenti! La sua vincita è di {vincita}€");
                saldo.Text= "0";
                let1.IsEnabled = true;
                let2.IsEnabled = true;
                let3.IsEnabled = true;
                slot.Counter = 3;
                tentativi.Text = "3";

            }
        }

        //hold1
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(slot.Hold(Holders.Hold1))
            let1.IsEnabled = !let1.IsEnabled;
        }

        //hold2
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(slot.Hold(Holders.Hold2))
            let2.IsEnabled = !let2.IsEnabled;
        }

        //hold3
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(slot.Hold(Holders.Hold3))
            let3.IsEnabled = !let3.IsEnabled;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            slot.Rinuncia();
            vinti.Text = slot.Win.ToString();
            tentativi.Text = slot.Counter.ToString();
            let1.IsEnabled = true;
            let2.IsEnabled = true;
            let3.IsEnabled = true;
            saldo.Text= slot.Monete.ToString();
        }
    }
}
