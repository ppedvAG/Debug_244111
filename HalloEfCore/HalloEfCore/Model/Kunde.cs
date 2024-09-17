namespace HalloEfCore.Model
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public List<Bestellung> Bestellungen { get; set; } = new List<Bestellung>();
    }


}
