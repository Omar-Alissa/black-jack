namespace black_jack
{
    public class Dealer : Person
    {
        public Dealer() : base("Dealer")
        {
        }

        public void SpelaTur(Kortlek kortlek)
        {
            // dealern drar kort tills handvärdet är minst 17
            while (RäknaPoäng() < 17)
            {
                LäggTillKort(kortlek.DraKort());
            }

        }
    }
}