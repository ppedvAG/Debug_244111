using HalloEfCore.Data;
using HalloEfCore.Logic;
using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEfCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EfContext con = new EfContext();
        private void button1_Click(object sender, EventArgs e)
        {
            var created = con.Database.EnsureCreated();

            if (created)
                MessageBox.Show("db wurde erstellt");
            else
                MessageBox.Show("db wurde NICHT erstellt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var b = new Bestellung() { Datum = DateTime.Now };
            b.Kunde = new Kunde() { Name = "Fred Feuerstein", Adresse = "Steinstr. 8" };
            var p = new Pizza() { Name = $"Pizza #{con.Pizzas.Count()}", Preis = 12.60m };
            b.Bestellitems.Add(new Bestellitem() { Pizza = p, Menge = 4 });

            con.Bestellungen.Add(b);
            con.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.Pizzas.Where(x => x.Name.Length > 3 && x.Name.StartsWith("P")).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.Bestellungen.Include(x => x.Kunde).ToList();

            errorProvider1.SetError(button3, "AAAAA");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ps =  new PizzaService();

            var result = ps.GetKundeWithMostBestellungen(true,false);

        }
    }
}
