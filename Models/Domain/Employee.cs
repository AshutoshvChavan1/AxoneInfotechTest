using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Models.Domain
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        public string LanguageKnown { get; set; }

    }
}
