
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApp.Validation;

namespace SchoolApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? StudentNo { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        [Display(Name = "Confirm Email")]
[Required(ErrorMessage = "Please type the email again.")]
// [NotMapped]: form only, not saved as a column
[NotMapped]
// [Compare("Email")]: must be exactly the same as Email
[Compare("Email", ErrorMessage = "Emails do not match.")]
public string? ConfirmEmail { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; }

        [Range(16, 60, ErrorMessage = "Age must be between 16 and 60.")]
        public int? Age { get; set; }

       [Display(Name = "Birth Date")]
// Shows a date picker without the time
[DataType(DataType.Date)]
// Our custom rule from Validation/NotFutureDateAttribute.cs
[NotFutureDate(ErrorMessage = "Birth date can't be in the future.")]
public DateTime? BirthDate { get; set; }
    }
}