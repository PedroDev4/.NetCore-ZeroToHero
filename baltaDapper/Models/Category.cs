using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaDapper.Models
{
    public class Category {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string url { get; set; }

        public string Summary { get; set; }

        public int Order { get; set; }

        public string description { get; set; }

        public bool Featured { get; set; }

    }
}
