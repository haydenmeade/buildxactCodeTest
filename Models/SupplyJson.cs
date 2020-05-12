using NodaMoney;
using System.Runtime.Serialization;

namespace buildxact_supplies.Models
{
    class SupplyJson : Supply
    {

        private Currency _currency;
        
        /// <summary>
        /// Empty constructor. Default to USD.
        /// </summary>
        public SupplyJson() : this(Currency.FromCode("USD")) { }

        public SupplyJson(Currency currency)
        {
            _currency = currency;
        }

        /// <summary>
        /// Price in cents. 
        /// </summary>
        public int PriceInCents { get; set; }

        public string ProviderId { get; set; }
        public string MaterialType { get; set; }

        /// <summary>
        /// Occurs when object is deserialized.
        /// </summary>
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            // Set the price from PriceInCents.
            Price = new Money(PriceInCents / 100, _currency);
        }
    }
}
