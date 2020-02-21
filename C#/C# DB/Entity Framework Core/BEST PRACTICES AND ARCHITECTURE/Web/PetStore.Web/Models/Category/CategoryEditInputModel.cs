namespace PetStore.Web.Models.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
