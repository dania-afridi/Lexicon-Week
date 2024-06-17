using System.ComponentModel.DataAnnotations;

namespace Assignment_01.Models.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Required]
        [StringLength (10)]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength (30)]
        public string? City { get; set; }
    }
}
