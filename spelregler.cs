namespace black_jack
{
    public class Spelregler
    {
        // kollar om poängen är över 21 : Bust
        public bool ÄrBust(int poäng)
        {
            return poäng > 21;
        }

        // kollar om handen är black jack i de första två korter
        public bool HarBlackJack(Person person)
        {
            return person.Hand.Count == 2 && person.RäknaPoäng() == 21;
        }

        // Jämför resultat mellan spelare och dealer
        public string AvgörVinnare(Spelare spelare, Dealer dealer)
        {
            int spelarePoäng = spelare.RäknaPoäng();
            int dealerPoäng = dealer.RäknaPoäng();

            if (ÄrBust(spelarePoäng))
            {
                return "Spelare blev Bust! Dealern vinner";
            }

            if (ÄrBust(dealerPoäng))
            {
                return "Dealern blev Bust! spelaren vinner";
            }

            if (HarBlackJack(spelare))
            {
                return "spelaren vinner! Black Jack";
            }

            if (spelarePoäng > dealerPoäng)
            {
                return "Spelare vinner";
            }

            else if (dealerPoäng > spelarePoäng)
            {
                return "Dealern vinner";
            }

            else
            {
                return "Oavgjort! PUSH";
            }

        }
    }
}