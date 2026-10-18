using System;

namespace black_jack
{
    internal class Game
    {
        static void Main(string[] args)
        {
            bool spelaIgen = true;

            while (spelaIgen)
            {
                Console.Clear();
                Console.WriteLine("**** BLACKJACK ****");

                Kortlek kortlek = new Kortlek();
                Spelare spelare = new Spelare("Spelare");
                Dealer dealer = new Dealer();
                Spelregler regler = new Spelregler();

                // Dela ut 2 kort till spelare och dealer
                spelare.LäggTillKort(kortlek.DraKort());
                spelare.LäggTillKort(kortlek.DraKort());

                dealer.LäggTillKort(kortlek.DraKort());
                dealer.LäggTillKort(kortlek.DraKort());

                // Spelarens tur
                bool spelareKör = true;
                while (spelareKör)
                {
                    Console.WriteLine("\n**** Din hand ****");
                    foreach (var kort in spelare.Hand)
                    {
                        Console.WriteLine($"{kort.Färg} {kort.Valör} (Värde: {kort.Värde})");
                    }
                    Console.WriteLine($"Total poäng: {spelare.RäknaPoäng()}");

                    if (regler.HarBlackJack(spelare))
                    {
                        Console.WriteLine("Black Jack!");
                        break;
                    }

                    if (spelare.RäknaPoäng() == 21)
                    {
                        Console.WriteLine("Du har 21 poäng!");
                        break;
                    }

                    if (regler.ÄrBust(spelare.RäknaPoäng()))
                    {
                        Console.WriteLine("Du blev Bust!");
                        break;
                    }

                    Console.Write("\nVill du dra ett kort till? (j/n): ");
                    string val = Console.ReadLine()?.Trim().ToLower();

                    if (val == "j")
                    {
                        spelare.LäggTillKort(kortlek.DraKort());
                    }
                    else
                    {
                        spelareKör = false;
                    }
                }

                // Dealerns tur. om spelaren inte blev bust
                if (!regler.ÄrBust(spelare.RäknaPoäng()))
                {
                    Console.WriteLine("\n**** Dealerns tur ****");
                    dealer.SpelaTur(kortlek);

                    foreach (var kort in dealer.Hand)
                    {
                        Console.WriteLine($"Dealer har: {kort.Färg} {kort.Valör}");
                    }
                    Console.WriteLine($"Dealerns totala poäng: {dealer.RäknaPoäng()}");
                }

                // Avgör vinnare
                Console.WriteLine("\n**** RESULTAT ****");
                string resultat = regler.AvgörVinnare(spelare, dealer);
                Console.WriteLine(resultat);

                // Fråga om att spela igen
                Console.Write("\nVill du spela en runda till? (j/n): ");
                string igenVal = Console.ReadLine()?.Trim().ToLower();
                if (igenVal != "j")
                {
                    spelaIgen = false;
                }
            }
        }
    }
}