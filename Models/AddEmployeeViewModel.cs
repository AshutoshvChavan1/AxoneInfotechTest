using PracticalTest.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Models
{
    public class AddEmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Short Name is required.")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        public List<string> LanguageKnown { get; set; } = new List<string>();

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
