using buildxact_supplies.Models;
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

            // AUD to USD exchanger.
            var exch = new ExchangeRate("AUD", "USD", audToUsd);

            // Convert all the prices to AUD.
            // TODO test this only converts USD not AUD
            combinedSupplies.ForEach(s => s.Price = exch.Convert(s.Price));

            // Output the supplies in price order.
            foreach (ISupply s in combinedSupplies.OrderByDescending(s => s.Price))
            {
                // TODO correct output.
                Console.WriteLine("...");
                Console.WriteLine();
            }
        }
    }
}
