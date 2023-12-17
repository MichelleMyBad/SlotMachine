using SlotMachine;
using System.Security.Cryptography.X509Certificates;

namespace SlotMachineConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Slot slot = new Slot();
            bool gaming = true;
            bool started = false;
            int limit = 1;
            string lettereMantenute = "";
            while (gaming) 
            {
                lettereMantenute = "";
                if (slot.Hold1) { lettereMantenute += Enum.GetName(typeof(Lettere), slot.Let1) + " "; }
                if (slot.Hold2) { lettereMantenute += Enum.GetName(typeof(Lettere), slot.Let2) + " "; }
                if (slot.Hold3) { lettereMantenute += Enum.GetName(typeof(Lettere), slot.Let3) + " "; }
                Console.WriteLine("SLOT MACHINE");
                Console.WriteLine("Scegliere cosa si desidera fare : ");
                Console.WriteLine($"{Enum.GetName(typeof(Lettere), slot.Let1)}  {Enum.GetName(typeof(Lettere), slot.Let2)}  {Enum.GetName(typeof(Lettere), slot.Let3)}");
                Console.WriteLine($"Ultima vincita: {slot.Win}     Saldo: {slot.Monete}     Roll rimasti: {slot.Counter}");
                Console.WriteLine($"Lettere mantenute: {lettereMantenute}");
                Console.WriteLine("1. Aggiungi credito");
                if (started)
                {
                    limit = 5;
                    Console.WriteLine("2. Mantieni/libera lettera (hold)");
                    Console.WriteLine("3. Accetta risultato corrente");
                    Console.WriteLine("4. Roll");
                    Console.WriteLine("5. Cash out");
                }
                int choice;
                int.TryParse( Console.ReadLine(), out choice);
                if(choice > limit) { choice = 0; }
                switch (choice) { 
                    case 0 : Console.WriteLine("Errore, inserire una scelta valida"); break;
                    case 1 : AddingTime(); started = true; break;
                    case 2 : HoldingTime(); break;
                    case 3 : slot.Rinuncia(); break;
                    case 4 : slot.Roll(); break;
                    case 5 : CashingOut(); gaming = false; break;
                    default : Console.WriteLine("Errore, inserire una scelta valida"); break;
                }
                Console.WriteLine();
            }

            void HoldingTime()
            {
                if (slot.Counter == 3)
                {
                    Console.WriteLine("Errore, Impossibile bloccare lettere al momento.");
                }
                Console.Write("Scegliere quale lettera si vuole mantenere/liberare (inserire un numero) : ");
                int scelta=0;
                int.TryParse(Console.ReadLine(), out scelta);
                bool holdin = true;
                switch (scelta)
                {
                    case 0 : Console.WriteLine("Errore, inserire un opzione valida"); break;
                    case 1 : holdin = slot.Hold(Holders.Hold1); break;
                    case 2 : holdin = slot.Hold(Holders.Hold2); break;
                    case 3 : holdin = slot.Hold(Holders.Hold3); break;
                    default : Console.WriteLine("Errore, inserire un opzione valida"); break;
                }
                if(holdin == false)
                {
                    Console.WriteLine("Errore, Impossibile bloccare lettere al momento.");
                }
            }
            void AddingTime()
            {
                Console.Write("Scrivere il numero di monete che si desidera inserire : ");
                int monete = 0;
                int.TryParse(Console.ReadLine(), out monete);   
                slot.Inserisci(monete);
            }
            void CashingOut() 
            {
                Console.WriteLine($"La sua vincita è di {slot.Monete}");
                slot.Ritira();
            }
        }
    }
}