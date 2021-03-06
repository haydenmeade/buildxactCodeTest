﻿using NodaMoney;

namespace buildxact_supplies.Models
{

    /// <summary>
    /// Description of a supply.
    /// </summary>
    public interface ISupply
    {

        public string Id { get; set; }

        public string Description { get; set; }

        public string Units { get; set; }

        /// <summary>
        /// Price of the supply.
        /// Not guaranteed in AUD.
        /// </summary>
        public Money Price { get; set; }
    }
}
