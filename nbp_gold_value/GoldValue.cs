using System;
using System.Collections.Generic;

namespace nbp_gold_value
{
    public class GoldValue
    {
        public GoldValue()
        {

        }
        public GoldValue(Nbp_Response nbp_response)
        {
            
           if (DateTime.TryParse(nbp_response.Data, out var result))
            {
                PriceDate = result;
            }
            Price = nbp_response.Cena;

        }
        public int? Id { get; set; }
        public double? Price { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
