using buildxact_supplies.Models;
using CsvHelper;
using NodaMoney;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace buildxact_supplies.Readers
{

    /// <summary>
    /// Supply reader for json files.
    /// </summary>
    public class CsvSupplyReader : ISupplyReader
    {
        public CsvSupplyReader()
        {
        }

        /// <summary>
        /// Reads the supplies from the underlying data.
        /// </summary>
        /// <param name="fp">File path.</param>
        /// <param name="currency">Currency that is in the file.</param>
        /// <returns>
        /// Supply enumerable.
        /// Prices will be in the input currency.
        /// </returns>
        public IEnumerable<ISupply> ReadSupplies(string fp, Currency currency)
        {
            using (var reader = new StreamReader(fp))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap(new SupplyMap(currency));
                return csv.GetRecords<Supply>().ToList();
            }

        }
    }
}