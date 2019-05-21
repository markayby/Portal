using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portal.Entities
{
    public class User : BaseEntity 
    {
        [MaxLength(120)]
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        [MaxLength(120)]
        public string Name { get; set; }
        
        [MaxLength(120)]
        public string Surname { get; set; }
        
        [MaxLength(120)]
        public string Position { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public long RoleId { get; set; }
        
        public Role Role { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}