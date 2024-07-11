using MongoCrud.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MongoCrud.API.Models.DTO
{
    public class UpdateStudentRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        //[Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters")]
        public string Address { get; set; }


        //public Branch Branch { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public string BranchId { get; set; }

    }
}
