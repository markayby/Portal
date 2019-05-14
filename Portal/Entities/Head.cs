using System.ComponentModel.DataAnnotations;

namespace Portal.Entities
{
    public class Head : BaseEntity
    {
        [MaxLength(120)]
        public string Name { get; set; }
        
        [MaxLength(120)]
        public string Surname { get; set; }
        
        [MaxLength(40)]
        public string Email { get; set; }
    }
}