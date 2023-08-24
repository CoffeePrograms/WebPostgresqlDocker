using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebPostgresqlDemo.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Display(Name = "USER ID")]
        public int Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Name length can't be less than 3.")]
        public string? Name { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Remote(action: "VerifyEmail", controller: "User")]
        public string? Email { get; set; } = null!;
    }
}