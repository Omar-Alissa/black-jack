using System;
using System.Collections.Generic;

namespace black_jack
{
    public class Kortlek
    {
        private List<Kort> listaMedKort;
        private Random slump = new Random();

        public Kortlek()
        {
            listaMedKort = new List<Kort>();
            SkapaKortlek();
            BlandaKort();
        }

        private void SkapaKortlek()
        {
            string[] färger = { "Hjärter", "Ruter", "Klöver", "Spader" };

            foreach (var färg in färger)
            {
                for (int i = 1; i <= 13; i++)
                {
                    string valör = i.ToString();
                    int värde = i;

                    switch (i)
                    {
                        case 1:
                            valör = "Ess";
                            värde = 11;
                            break;
                        case 11:
                            valör = "Knekt";
                            värde = 10;
                            break;
                        case 12:
                            valör = "Dam";
                            värde = 10;
                            break;
                        case 13:
                            valör = "Kung";
                            värde = 10;
                            break;
                    }

                    Kort nyttKort = new Kort(färg, valör, värde);
                    listaMedKort.Add(nyttKort);
                }
            }
        }

        public void BlandaKort()
        {
            for (int i = 0; i < listaMedKort.Count; i++)
            {
                int slumpIndex = slump.Next(listaMedKort.Count);
                Kort temp = listaMedKort[i];
                listaMedKort[i] = listaMedKort[slumpIndex];
                listaMedKort[slumpIndex] = temp;
            }
        }

        public Kort DraKort()
        {
            if (listaMedKort.Count == 0)
            {
                return null;
            }

            Kort dratKort = listaMedKort[0];
            listaMedKort.RemoveAt(0);
            return dratKort;
        }
    }
}
