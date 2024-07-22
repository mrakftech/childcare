using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChildRecordCareSystem.Models
{
    public class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChildId { get; set; }
        [Required]
        [StringLength(100)]
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        [Required]
        [StringLength(50)]
        public string? City { get; set; }
        [Required]
        [StringLength(50)]
        public string? Country { get; set; }
        [Required]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        public string? ChildProfilePath { get; set; }
        public string? Doument1 { get; set; }
        public string? Doument2 { get; set; }
        public string? Doument3 { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
    }
}
