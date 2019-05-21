using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Portal.Core.Types;

namespace Portal.Entities
{
    public class Request: BaseEntity
    {
        public RequestTypeEnum Type { get; set; }
        
        public DateTime DateFrom { get; set; }
        
        public DateTime DateTo { get; set; }

        public ICollection<User> Heads { get; set; }

        public User Employee { get; set; }
        
        [EmailAddress]
        public string OptionalEmail { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public RequestStatusEnum Status { get; set; }

        public bool Completed { get; set; }
    }
}