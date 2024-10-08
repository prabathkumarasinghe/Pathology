using System.ComponentModel.DataAnnotations;

namespace Pathology.Services.PatientAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientNumber { get; set; }
        public int RefNumber { get; set; }
        [Required]
        public int LabNumber { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string TestType { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
