using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Rest_Full_Coding.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? ProductName { get; set; }
        [Required]
        [MaxLength(300)]
        public string? ProductDescription { get; set; }
        [Required]
        public string? ProductImageUrl { get; set; }
        [Required]
        public DateTime ProductCreated { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }


    }
}
