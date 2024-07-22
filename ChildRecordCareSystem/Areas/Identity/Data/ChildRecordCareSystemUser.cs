using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChildRecordCareSystem.Areas.Identity.Data
{
    public class ChildRecordCareSystemUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FullName { get; set; }

        

        [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string? Address { get; set; }
        public string? ProfileImagePath { get; set; }
        public string? BackgroundImagePath { get; set; }
    }
}
