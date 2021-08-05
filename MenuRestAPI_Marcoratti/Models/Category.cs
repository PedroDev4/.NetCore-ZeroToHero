using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MenuRestAPI_Marcoratti.Models
{
    [Table("Categorias")]
    public class Category
    {

        public Category()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int id { get; set; } // Prop da table ->  Entity

        [Required]
        [MaxLength(80)]
        public string name { get; set; }

        [Required]
        [MaxLength(80)]
        public string imageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
        // Uma categoria pode conter muitos produtos, informando ao EF que uma categoria possui uma coleção de products
    }
}
