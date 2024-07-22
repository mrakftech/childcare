using System.ComponentModel.DataAnnotations;

namespace ChildRecordCareSystem.Models
{
    public class ChildVM
    {
         
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile? ChildProfilePath { get; set; }
        public IFormFile? Doument1 { get; set; }
        public IFormFile? Doument2 { get; set; }
        public IFormFile? Doument3 { get; set; }
        public string? Email { get; set; }
    }
}
