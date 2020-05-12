using buildxact_supplies.Models;
using NodaMoney;
using System.Collections.Generic;

namespace buildxact_supplies.Extensions
{
    public static class SuppliesExtensions
    {

        /// <summary>
        /// Converts prices in <paramref name="supplies"/> to the base currency in <paramref name="exchange"/>.
        /// </summary>
        /// <param name="supplies">Supply list.</param>
        /// <param name="exchange">Exchange rate.</param>
        public static void ConvertPricesToBase(this List<ISupply> supplies, ExchangeRate exchange)
        {
            // Convert all the prices to base if needed.
            supplies.ForEach(s => s.Price = s.Price.Currency == exchange.BaseCurrency ? s.Price : exchange.Convert(s.Price));
        }
    }
}
