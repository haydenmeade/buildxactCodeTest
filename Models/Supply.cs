using NodaMoney;

namespace buildxact_supplies.Models
{
    public class Supply : ISupply
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public Money Price { get; set; }
    }
}
