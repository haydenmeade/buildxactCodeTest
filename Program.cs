using buildxact_supplies.Extensions;
using buildxact_supplies.Models;
using buildxact_supplies.Readers.Csv;
using buildxact_supplies.Readers.Json;
using Microsoft.Extensions.Configuration;
using NodaMoney;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {

            // read the configuration file for the exchange rate.
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var audToUsd = double.Parse(configuration["audUsdExchangeRate"]);

            // Read the data.
            var combinedSupplies = new List<ISupply>();
            combinedSupplies.AddRange(new CsvSupplyReader().ReadSupplies("humphries.csv", Currency.FromCode("AUD")));
            combinedSupplies.AddRange(new JsonSupplyReader().ReadSupplies("megacorp.json", Currency.FromCode("USD")));

            // Convert prices to AUD.
            combinedSupplies.ConvertPricesToBase(new ExchangeRate(Currency.FromCode("AUD"),
                                                                  Currency.FromCode("USD"),
                                                                  audToUsd));

            // Output the supplies in price order.
            foreach (ISupply s in combinedSupplies.OrderByDescending(s => s.Price))
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine();
            }
        }
    }
}
