using System;
using System.Collections.Generic;

namespace HRTourismApp.Models
{
    public partial class Driver
    {
        public Driver()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }        
        public string NameSurname { get; set; }        
        public string TCKNo { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual Company Company { get; set; }
     
    }
}
