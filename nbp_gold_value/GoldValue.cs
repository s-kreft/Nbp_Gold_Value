using System;
using System.Collections.Generic;

namespace nbp_gold_value
{
    public partial class GoldValue
    {
        public int? Id { get; set; }
        public double? Price { get; set; }
        public DateOnly? PriceDate { get; set; }
    }
}
