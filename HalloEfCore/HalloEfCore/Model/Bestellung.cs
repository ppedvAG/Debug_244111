namespace HalloEfCore.Model
{
    public class Bestellung
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public Kunde? Kunde { get; set; }
        public List<Bestellitem> Bestellitems { get; set; } = new List<Bestellitem>();
    }


}
