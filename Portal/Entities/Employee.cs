using System.ComponentModel.DataAnnotations;

namespace Portal.Entities
{
    public class Employee : User
    {
        [MaxLength(120)]
        public string Name { get; set; }
        
        [MaxLength(120)]
        public string Surname { get; set; }
    }
}