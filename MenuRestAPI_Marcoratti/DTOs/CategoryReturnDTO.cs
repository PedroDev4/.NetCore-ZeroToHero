using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.DTOs;

namespace MenuRestAPI_Marcoratti.DTOs
{
    public class CategoryReturnDTO
    {

        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }

        public ICollection<ProductReturnDTO> Products { get; set; }

    }
}
