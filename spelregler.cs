namespace black-jack
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
    }
}