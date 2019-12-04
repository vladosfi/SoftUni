
namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentsCellsDto
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string Name { get; set; }

        public ImportCellsDto[] Cells { get; set; }
    }
}
