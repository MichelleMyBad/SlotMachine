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
using SlotMachineLib;

namespace SlotMachineProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        int indice1 = 0;
        int indice2 = 0;
        int indice3 = 0;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            InizzializzaTimer();
            Random rnd= new Random();

            let1.Background = Slicing(rnd.Next(0,9));
            let2.Background = Slicing(rnd.Next(0, 9));
            let3.Background = Slicing(rnd.Next(0, 9));
        }

         SlotMachine slot = new SlotMachine();

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
            int winVecchia = slot.Win;
            Alter();
            tentativi.Text = slot.Counter.ToString();
            if (slot.Counter == 3)
            {
                slot.Monete -= winVecchia;
                slot.Check();
                let1.IsEnabled = true;
                let2.IsEnabled = true;
                let3.IsEnabled = true;
            }
            ImageChoice();
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
            Alter();
            slot.Rinuncia();
            vinti.Text = slot.Win.ToString();
            tentativi.Text = slot.Counter.ToString();
            let1.IsEnabled = true;
            let2.IsEnabled = true;
            let3.IsEnabled = true;
            saldo.Text= slot.Monete.ToString();
        }

        private void Alter()
        {
            switch (indice1)
            {
                case 0: slot.Let1 = 24; break;
                case 1: slot.Let1 = 1; break;
                case 2: slot.Let1 = 20; break;
                case 3: slot.Let1 = 4; break;
                case 4: slot.Let1 = 14; break;
                case 5: slot.Let1 = 10; break;
                case 6: slot.Let1 = 7; break;
                case 7: slot.Let1 = 26; break;
                case 8: slot.Let1 = 17; break;
            }
            switch (indice2)
            {
                case 0: slot.Let2 = 24; break;
                case 1: slot.Let2 = 1; break;
                case 2: slot.Let2 = 20; break;
                case 3: slot.Let2 = 4; break;
                case 4: slot.Let2 = 14; break;
                case 5: slot.Let2 = 10; break;
                case 6: slot.Let2 = 7; break;
                case 7: slot.Let2 = 26; break;
                case 8: slot.Let2 = 17; break;
            }
            switch (indice3)
            {
                case 0: slot.Let3 = 24; break;
                case 1: slot.Let3 = 1; break;
                case 2: slot.Let3 = 20; break;
                case 3: slot.Let3 = 4; break;
                case 4: slot.Let3 = 14; break;
                case 5: slot.Let3 = 10; break;
                case 6: slot.Let3 = 7; break;
                case 7: slot.Let3 = 26; break;
                case 8: slot.Let3 = 17; break;
            }
        }

        private const int larghezzaSlice = 70;
        private const int altezzaSlice = 70;

        private void ImageChoice()//devo cambiare l'indice per scegliere l'immagine 
        {
            if (slot.Let1 >= 1 && slot.Let1 < 4) { indice1 = 1; }
            else if (slot.Let1 >= 4 && slot.Let1 < 7) { indice1 = 3; }
            else if (slot.Let1 >= 7 && slot.Let1 < 10) { indice1 = 6; }
            else if (slot.Let1 >= 10 && slot.Let1 < 14) { indice1 = 5; }
            else if (slot.Let1 >= 14 && slot.Let1 < 17) { indice1 = 4; }
            else if (slot.Let1 >= 17 && slot.Let1 < 20) { indice1 = 8; }
            else if (slot.Let1 >= 20 && slot.Let1 < 24) { indice1 = 2; }
            else if (slot.Let1 >= 24 && slot.Let1 <= 25) { indice1 = 0; }
            else if (slot.Let1 == 26) { indice1 = 7; }

            if (slot.Let2 >= 1 && slot.Let2 < 4) { indice2 = 1; }
            else if (slot.Let2 >= 4 && slot.Let2 < 7) { indice2 = 3; }
            else if (slot.Let2 >= 7 && slot.Let2 < 10) { indice2 = 6; }
            else if (slot.Let2 >= 10 && slot.Let2 < 14) { indice2 = 5; }
            else if (slot.Let2 >= 14 && slot.Let2 < 17) { indice2 = 4; }
            else if (slot.Let2 >= 17 && slot.Let2 < 20) { indice2 = 8; }
            else if (slot.Let2 >= 20 && slot.Let2 < 24) { indice2 = 2; }
            else if (slot.Let2 >= 24 && slot.Let2 <= 25) { indice2 = 0; }
            else if (slot.Let2 == 26) { indice2 = 7; }

            if (slot.Let3 >= 1 && slot.Let3 < 4) { indice3 = 1; }
            else if (slot.Let3 >= 4 && slot.Let3 < 7) { indice3 = 3; }
            else if (slot.Let3 >= 7 && slot.Let3 < 10) { indice3 = 6; }
            else if (slot.Let3 >= 10 && slot.Let3 < 14) { indice3 = 5; }
            else if (slot.Let3 >= 14 && slot.Let3 < 17) { indice3 = 4; }
            else if (slot.Let3 >= 17 && slot.Let3 < 20) { indice3 = 8; }
            else if (slot.Let3 >= 20 && slot.Let3 < 24) { indice3 = 2; }
            else if (slot.Let3 >= 24 && slot.Let3 <= 25) { indice3 = 0; }
            else if (slot.Let3 == 26) { indice3 = 7; }

            Alter();
            if (slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3 && slot.Let3 == 100)
            {
                indice1 = indice2 = indice3 = 7;
            }else if (slot.Let1 == slot.Let2 || slot.Let2 == slot.Let3 || slot.Let1 == slot.Let3)
            {
                Random esclusoGen = new Random();
                int escluso = esclusoGen.Next(0, 3);
                Random diverso = new Random();
                Random uguali = new Random();

                switch (escluso)
                {
                    case 0:
                        indice2 = indice3 = diverso.Next(0, 9);
                        do { indice1 = diverso.Next(0, 9); } while (indice1 == indice2);
                        break;
                    case 1:
                        indice1 = indice3 = diverso.Next(0, 9);
                        do { indice2 = diverso.Next(0, 9); } while (indice2 == indice1);
                        break;
                    case 2:
                        indice1 = indice2 = diverso.Next(0, 9);
                        do { indice3 = diverso.Next(0, 9); } while (indice3 == indice1);
                        break;
                }
                
            }else if (slot.Let1 + 1 == slot.Let2 && slot.Let2 + 1 == slot.Let3) 
            { 
                Random coloreGen = new Random();
                int colore = coloreGen.Next(0,3);
                List<int> simboli = new List<int>();
                switch (colore){
                    case 0://2,3,6
                        simboli.Add(2);
                        simboli.Add(3);
                        simboli.Add(6);
                        break;
                    case 1://0,1,5
                        simboli.Add(0);
                        simboli.Add(1);
                        simboli.Add(5);
                        break;
                    case 2://4,7,8
                        simboli.Add(4);
                        simboli.Add(7);
                        simboli.Add(8);
                        break;
                }

                indice1 = RandomChoices(simboli);
                simboli.Remove(indice1);
                indice1 = RandomChoices(simboli);
                simboli.Remove(indice2);
                indice3 = RandomChoices(simboli);
            }
            else
            {
                if ((slot.Let1 > 1 && slot.Let1 < 4) && slot.Let1==slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 1; slot.Win = 1; }
                else if((slot.Let1 >= 4 && slot.Let1 < 7) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 3; slot.Win = 2; }
                else if((slot.Let1 >= 7 && slot.Let1 < 10) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 6; slot.Win = 3; }
                else if((slot.Let1 >= 10 && slot.Let1 < 14) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 5; slot.Win = 4; }
                else if((slot.Let1 >= 14 && slot.Let1 < 17) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 4; slot.Win = 5; }
                else if((slot.Let1 >= 17 && slot.Let1 < 20) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 8; slot.Win = 6; }
                else if((slot.Let1 >= 20 && slot.Let1 < 24) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 2; slot.Win = 7; }
                else if((slot.Let1 >= 24 && slot.Let1 <= 25) && slot.Let1 == slot.Let2 && slot.Let2 == slot.Let3) 
                    { indice1 = indice2 = indice3 = 0; slot.Win = 8; }

            }


            let1.Background = Slicing(indice1);
            let2.Background = Slicing(indice2);
            let3.Background = Slicing(indice3);

        }

        private int RandomChoices(List<int> choices)
        {
            if (choices.Count == 0)
            {
                throw new ArgumentException("La lista inserita è vuota");
            }
            Random num = new Random();
            int indiceRnd = num.Next(0, choices.Count());
            int generated = choices[indiceRnd];

            return generated;
        }


        private ImageBrush Slicing(int indiceCartaCorrente)
        {
            string percorsoImmagine = @".\Carte\Carte.png";
            BitmapImage simboli = new BitmapImage(new Uri(percorsoImmagine, UriKind.Relative));


            //Coordinate di slicing
            int colonna = indiceCartaCorrente % (simboli.PixelWidth / larghezzaSlice);
            int riga = indiceCartaCorrente / (simboli.PixelWidth / larghezzaSlice);
            //slicing
            CroppedBitmap simboloSingolo = new CroppedBitmap(simboli, new Int32Rect(colonna * larghezzaSlice, riga * altezzaSlice, larghezzaSlice, altezzaSlice));

            //immagine a schermo
            ImageBrush brush = new ImageBrush(simboloSingolo);
            brush.Stretch = Stretch.None;
            return brush;
        }
    }
}
