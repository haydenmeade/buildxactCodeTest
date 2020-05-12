using buildxact_supplies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaMoney;
using System;
using System.Diagnostics.CodeAnalysis;

namespace buildxact_supplies.Readers.Json
{
    /// <summary>
    /// Converts a json to a <see cref="ISupply"/> instance.
    /// </summary>
    public class SupplyJsonConverter : JsonConverter<ISupply>
    {
        private Currency _currency;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="currency">Currency that is in the Json file.</param>
        public SupplyJsonConverter(Currency currency)
        {
            _currency = currency;
        }

        /// <summary>
        /// Reads the JSON representation of the Supply.
        /// </summary>
        /// <param name="reader">The Newtonsoft.Json.JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override ISupply ReadJson(
            JsonReader reader,
            Type objectType,
            [AllowNull] ISupply existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return new Supply
            {
                Id = (string)jo["id"],
                Description = (string)jo["description"],
                Price = new Money((int)jo["priceInCents"] / 100, _currency), // Convert price in cents to price using currency.
                Units = (string)jo["uom"]
            };
        }

        // No write implemented.
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, [AllowNull] ISupply value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
