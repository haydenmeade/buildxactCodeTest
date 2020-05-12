using System;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the data.
            var csvReader = new CsvSupplyReader();
            var jsonReader = new JsonSupplyReader();

            // Combine the supplies.

            // Convert to AUD -> Sort -> Print.
        }
    }
}
