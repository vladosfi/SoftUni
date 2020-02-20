
namespace FastFood.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3),MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal),"0.00","100.00")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
