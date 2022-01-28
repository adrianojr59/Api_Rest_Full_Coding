using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Rest_Full_Coding.Models
{
    [Table("Category")]
    public class Category
    {

        public Category()
        {
            _Product = new Collection<Product>();
        }



        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? CategoryName { get; set; }
        [Required]
        public string? CategoryImageUrl { get; set; }


        public ICollection<Product> _Product { get; set; }
    }
}
