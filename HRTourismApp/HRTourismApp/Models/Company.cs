using System;

namespace HRTourismApp.Models
{
    public partial class Company
    {
        public Company()
        {
            IsActive = true;
        }        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }               
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string TaxPlace { get; set; }
        public string TaxNumber { get; set; }      
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }   
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string UETDSEndPoint { get; set; }
        public string UETDSUserName { get; set; }
        public string UETDSPassword { get; set; }

    }
}
