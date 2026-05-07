using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime MembershipDate { get; set; }
    }
}
