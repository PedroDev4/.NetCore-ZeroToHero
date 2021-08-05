using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.Validation;

namespace MenuRestAPI_Marcoratti.Models
{
    [Table("Produtos")]
    public class Product : IValidatableObject
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(20, ErrorMessage = "O Nome deve ter entre 5 a 20 caracteres", MinimumLength = 5)]
        [FirstLetterUppercase]
        [MaxLength(80)]
        public string name { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O Nome deve ter entre 5 a 20 caracteres", MinimumLength = 5)]
        [MaxLength(150)]
        public string description { get; set; }

        [Required]
        [Range(1,10000, ErrorMessage = "O preço deve estar entre 1 a 10000")]
        public decimal price { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        [MaxLength(300)]
        public string imageUrl { get; set; }

        [Required]
        [MinValue]
        public float amount { get; set; }

        public DateTime created_at { get; set; }

        public int category_id { get; set; }

        [ForeignKey("category_id")]
        public Category Category { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.name)) {
                var primeiraLetra = this.name[0].ToString();

                if (primeiraLetra != primeiraLetra.ToUpper()) {

                    yield return new ValidationResult("A primeira letra do nome do produto deve ser maiúscula", new[] { nameof(this.name) });
                }
            }
           
        }
    }
}
