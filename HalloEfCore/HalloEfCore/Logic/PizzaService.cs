using HalloEfCore.Model;

namespace HalloEfCore.Logic
{
    internal class PizzaService
    {
        public Kunde GetKundeWithMostBestellungen(bool nurVegan = false, bool nurVegetarisch = false)
        {
            if (nurVegan && !nurVegetarisch)
                throw new InvalidOperationException("Wenn vegan, dann ist es auch Vegetarisch!");

            ArgumentNullException.ThrowIfNull(nurVegan);

            //if (nurVegan)
            //{
            //    System.Diagnostics.Debug.Assert(nurVegetarisch, "Wenn vegan, dann ist es auch Vegetarisch!");
            //}


            throw new NotImplementedException();
        }


        public void Linq()
        {

            var text = new List<String>();

            var result = text.Where(x => x.StartsWith("b"));

            var result2 = text.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }
    }
}
