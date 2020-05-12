using NodaMoney;

namespace buildxact_supplies.Models
{

    /// <summary>
    /// Supply base implementation.
    /// </summary>
    public class Supply : ISupply
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }

        /// <summary>
        /// Price of the supply.
        /// Not guaranteed in AUD.
        /// </summary>
        public Money Price { get; set; }

        /// <summary>
        /// Override ToString for printing the supply to console.
        /// Prices will be to the nearest cent.
        /// </summary>
        public override string ToString()
        {
            // All prices must be shown to the nearest cent.
            return $"{Id}, {Description}, {Price:C2}";
        }
    }
}
