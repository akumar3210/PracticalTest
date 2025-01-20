using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
