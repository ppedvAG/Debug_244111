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
    }
}
