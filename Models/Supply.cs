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

        public override string ToString()
        {
            return $"{Id}, {Description}, {Price:C2}";
        }
    }
}
