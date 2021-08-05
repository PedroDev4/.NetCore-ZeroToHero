using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marcorattiWebApí.Models
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

        public ICollection<Product> Products { get ; set; } 
        // Uma categoria pode conter muitos produtos, informando ao EF que uma categoria possui uma coleção de products
    }
}