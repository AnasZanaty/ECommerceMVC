using Demo.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace session3_MVC.Models
{
    public class EmployeeViewModel
    {

        //Emplyee Form Data

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal salary { get; set; }

        public string Email { get; set; }

        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }


    }
}
