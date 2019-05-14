using System.ComponentModel.DataAnnotations;

namespace Portal.Entities
{
    public class User : BaseEntity 
    {
        [MaxLength(120)]
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public long RoleId { get; set; }
        
        public Role Role { get; set; }
    }
}