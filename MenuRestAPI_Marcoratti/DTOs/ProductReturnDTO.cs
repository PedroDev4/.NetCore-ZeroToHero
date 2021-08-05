using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.DTOs
{
    public class ProductReturnDTO
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public int category_id { get; set; }

    }
}
