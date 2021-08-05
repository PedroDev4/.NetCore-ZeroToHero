using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace marcorattiWebApí.Models
{
    [Table("Produtos")]
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(80)]
        public string name { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [MaxLength(300)]
        public string imageUrl { get; set; }

      
        public float amount { get; set; }
        
        public DateTime created_at { get; set; }

        public int category_id {get ; set; } 

        public Category Category {get; set; }

    }
}