using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {
        [Required, MinLength(3), MaxLength(40)]
        [RegularExpression(@"^[A-Za-z]+[\d]*$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}-[\d]{3}-[\d]{4}$")]
        public string Phone { get; set; }

        //public ImportTasksPerUserDto[] Tasks { get; set; }
        public HashSet<int> Tasks { get; set; }
    }

    //public class ImportTasksPerUserDto
    //{
    //    public int TaskId { get; set; }
    //}
}
