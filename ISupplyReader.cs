using buildxact_supplies.Models;
using NodaMoney;
using System.Collections.Generic;

namespace SuppliesPriceLister
{
    /// <summary>
    /// Describes a reader of supply data.
    /// </summary>
    public interface ISupplyReader
    {

        /// <summary>
        /// Reads the supplies from the underlying data.
        /// </summary>
        /// <param name="fp">File path.</param>
        /// <param name="currency">Currency that is in the file.</param>
        /// <returns>
        /// Supply enumerable.
        /// Prices will be in the input currency.
        /// </returns>
        IEnumerable<ISupply> ReadSupplies(string fp, Currency currency);
    }
}