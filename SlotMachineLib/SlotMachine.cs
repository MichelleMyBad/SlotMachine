
namespace SlotMachineLib
{
    public class SlotMachine
    {
        public int Monete { get; set; }
        public int Let1 { get; set; }
        public int Let2 { get; set; }
        public int Let3 { get; set; }

        public bool Hold1 { get; set; }
        public bool Hold2 { get; set; }
        public bool Hold3 { get; set; }

        public int Win { get; set; }
        public int Counter { get; set; }
        public bool Started { get; set; }

        public SlotMachine()
        {
            Monete = 0;
            Win = 0;
            Hold1 = false;
            Hold2 = false;
            Hold3 = false;
            Counter = 3;
            Started = false;
        }

        public void Roll()
        {
            Started = true;
            Random l1 = new Random();
            Random l2 = new Random();
            Random l3 = new Random();
            if (Hold1 == false)
                Let1 = l1.Next(1, 27);

            if (Hold2 == false)
                Let2 = l2.Next(1, 27);

            if (Hold3 == false)
                Let3 = l3.Next(1, 27);

            Counter--;


            if (Counter == 0)
            {
                Check();
                Started = false;
                Hold1 = false;
                Hold2 = false;
                Hold3 = false;
                Monete--;
                Counter = 3;
            }
        }

        public bool Hold(Holders num)
        {
            if (Counter < 3)
                switch ((int)num)
                {
                    case 1:
                        if (Hold2 == false || Hold3 == false)
                        {
                            Hold1 = !Hold1;
                            return true;
                        }
                        return false;

                    case 2:
                        if (Hold1 == false || Hold3 == false)
                        {
                            Hold2 = !Hold2;
                            return true;
                        }
                        return false;

                    case 3:
                        if (Hold2 == false || Hold1 == false)
                        {
                            Hold3 = !Hold3;
                            return true;
                        }
                        return false;
                }
            return false;
        }

        public void Rinuncia()
        {
            if (Counter > 0 && Started == true)
            {
                Started = false;
                Counter = 3;
                Check();
                Hold1 = false;
                Hold2 = false;
                Hold3 = false;
                Monete--;
            }
        }

        public void Check()
        {

            if (Let1 == Let2 && Let2 == Let3)
            {
                if (Let1 == 26)
                { Win = 100; Monete += 100; return; }

                Win = Let1;
                Monete += Let1;
            }
            else if (Let1 == Let2 ||
            Let3 == Let1 ||
            Let3 == Let2
            ) { Win = 1; Monete += 1; }
            else if (Let1 + 1 == Let2 && Let2 + 1 == Let3)
            {
                Win = 50;
                Monete += 50;
            }
            else { Win = 0; Monete += 0; }
        }

        public void Inserisci(int Monete) { this.Monete = Monete; }

        public void Ritira() { Win = 0; }
    }

}