using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Portal.Core.Types;
using Portal.Entities;

namespace Portal.ViewModels
{
    public class HistoryRequestViewModel
    {
        public long? Id { get; set; }
        
        public string Type { get; set; }
        
        public DateTime DateFrom { get; set; }
        
        public DateTime DateTo { get; set; }

        public string Heads { get; set; }

        public string Employee { get; set; }
        
        public string Status { get; set; }

        public string Completed { get; set; }
    }
}