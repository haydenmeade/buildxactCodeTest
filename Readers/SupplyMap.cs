using buildxact_supplies.Models;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NodaMoney;
using System.Globalization;

namespace buildxact_supplies.Readers
{
    /// <summary>
    /// Mapping class for <see cref="Supply"/> class.
    /// Creates the mappings from csv to object.
    /// </summary>
    internal class SupplyMap : ClassMap<Supply>
    {

        public SupplyMap(Currency currency)
        {
            Map(m => m.Id).Name("identifier");
            Map(m => m.Description).Name("desc");
            Map(m => m.Units).Name("unit");
            Map(m => m.Price).Name("costAUD")
                             .TypeConverter(new MoneyStringConverter(currency));
        }

        /// <summary>
        /// Used in the <see cref="SupplyMap"/> to convert the cost column to a <see cref="Money"/> instance.
        /// </summary>
        private class MoneyStringConverter : ITypeConverter
        {
            /// <summary>
            /// Currency that the data is stored in the csv.
            /// </summary>
            private Currency _currency;

            /// <summary>
            /// Ctor.
            /// </summary>
            /// <param name="currency">Currency that the data is stored in the csv.</param>
            public MoneyStringConverter(Currency currency)
            {
                this._currency = currency;
            }

            /// <summary>
            /// Converts the string representation in the csv to a <see cref="Money"/> instance.
            /// </summary>
            /// <param name="text">Text of the cost.</param>
            /// <param name="row">CSV row.</param>
            /// <param name="memberMapData">Mapping data.</param>
            /// <returns><see cref="Money"/> instance.</returns>
            public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                return new Money(decimal.Parse(text, CultureInfo.InvariantCulture), _currency);
            }

            public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}