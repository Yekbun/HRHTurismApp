using System;

namespace HRTourismApp.Models
{
    public partial class Vehicle
    {
      
        public Vehicle()
        {            
            IsActive = true;
        }      
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public string Plaque { get; set; }
        public string License { get; set; }                
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; } 
        public virtual User CreateUser { get; set; }
        public virtual Company Company { get; set; }

    }     

}
