namespace black_jack
{
    public class Spelare : Person
    {
        public int Saldo { get; set; }

        public Spelare(string namn) : base(namn)
        {
            Saldo = 100;
        }
    }
}