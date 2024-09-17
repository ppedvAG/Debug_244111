namespace HalloEfCore.Model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; }
        public bool Vegan { get; set; }
    }
}
