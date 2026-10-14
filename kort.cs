namespace black_jack
{
    public class Kort
    {
        public string Färg { get; set; }
        public string Valör { get; set; }
        public int Värde { get; set; }

        public Kort(string färg, string valör, int värde)
        {
            Färg = färg;
            Valör = valör;
            Värde = värde;
        }

        public override string ToString()
        {
            return $"{Färg} {Valör}";
        }
    }
}
