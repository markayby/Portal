using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class HeadViewModel
    {
        public long? Id { get; set; }
        
        [MaxLength(120)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(120)]
        [Required]
        public string Surname { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength(40)]
        public string Email { get; set; }
    }
}