using buildxact_supplies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaMoney;
using System.Collections.Generic;
using System.Linq;

namespace buildxact_supplies.Readers.Json
{

    /// <summary>
    /// Supply reader for json files.
    /// </summary>
    public class JsonSupplyReader : ISupplyReader
    {
        public JsonSupplyReader()
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
            var jsonFile = System.IO.File.ReadAllText(fp);
            var jobject = JObject.Parse(jsonFile);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new SupplyJsonConverter(currency));
            return jobject["partners"].Children()
                                      .SelectMany(j => j["supplies"])
                                      .Select(j => j.ToObject<ISupply>(JsonSerializer.Create(jsonSettings)))
                                      .ToList();
        }
    }
}