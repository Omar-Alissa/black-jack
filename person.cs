using System.Collections.Generic;

namespace black_jack
{
    public class Person
    {
        // Egenskaper för personens namn och kort på handen
        public string Namn { get; set; }
        public List<Kort> Hand { get; set; }

        // Konstruktor som sätter namnet och initierar kortlisten
        public Person(string namn)
        {
            Namn = namn;
            Hand = new List<Kort>();
        }

        // Lägger till ett kort på handen om kortet inte är null
        public void LäggTillKort(Kort kort)
        {
            if (kort != null)
            {
                Hand.Add(kort);
            }
        }

        // Räknar ut den totala poängen för handen med hänsyn till Ess (värde 11 eller 1)
        public int RäknaPoäng()
        {
            int summa = 0;
            int antalEss = 0;

            foreach (var kort in Hand)
            {
                summa += kort.Värde;
                if (kort.Valör == "Ess")
                {
                    antalEss++;
                }
            }

            // Om summan överstiger 21 och det finns Ess, räknas Ess som 1 istället för 11
            while (summa > 21 && antalEss > 0)
            {
                summa -= 10;
                antalEss--;
            }

            return summa;
        }

        // Tömmer handen inför en ny spelrunda
        public void RensaHand()
        {
            Hand.Clear();
        }
    }
}