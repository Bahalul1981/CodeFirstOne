using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstTest.Model
{
    public class Product
    {
        

        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
