using buildxact_supplies.Extensions;
using buildxact_supplies.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaMoney;
using System.Collections.Generic;
using System.Globalization;

namespace SuppliesPriceLister.UnitTest
{

    /// <summary>
    /// Tests on <see cref="SuppliesExtensions"/>.
    /// </summary>
    [TestClass]
    public class SuppliesExtensionsTests
    {

        /// <summary>
        /// Test on the <see cref="SuppliesExtensions.ConvertPricesToBase(List{ISupply}, ExchangeRate)"/>
        /// </summary>
        [TestMethod]
        public void SuppliesExtensions_ConvertPricesToBase()
        {
            //
            // Arrange.
            //
            CultureInfo.CurrentCulture = new CultureInfo("en-au");

            // Single aud supply.
            var audSupply = new Supply
            {
                Price = new Money(10, Currency.FromCode("AUD")),
                Id = "AUD"
            };
            // Single usd supply.
            var usdSupply = new Supply
            {
                Price = new Money(10, Currency.FromCode("USD")),
                Id = "USD"
            };
            var supplies = new List<ISupply>
            {
                audSupply,
                usdSupply
            };

            // AUD - USD Exchange rate.
            var exchange = new ExchangeRate("AUD", "USD", 100);

            //
            // Act.
            //
            supplies.ConvertPricesToBase(exchange);

            //
            // Assert.
            //
            foreach (ISupply s in supplies)
            {
                Assert.AreEqual(exchange.BaseCurrency,
                                s.Price.Currency,
                                "Should have converted all supplies to base currency.");

                if (s.Id == "AUD")
                {
                    Assert.AreEqual(10,
                                    s.Price.Amount,
                                    "Should not perform conversion");
                }
                else
                {
                    Assert.AreEqual(exchange.Convert(new Money(10, exchange.QuoteCurrency)),
                                    s.Price.Amount,
                                    "Should perform conversion");
                }
            }
        }
    }
}
