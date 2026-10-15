namespace black_jack
{
    public class Spelare : Person
    {
        public int Saldo { get; set; }

        // Konstruktor som tar emot namnet och skickar det vidare till Person klassen med base: namn 
        public Spelare(string namn) : base(namn)
        {
            Saldo = 100;
        }
    }
}