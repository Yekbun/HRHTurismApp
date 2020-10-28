using System;


namespace HRTourismApp.Models
{
    public partial class Group
    {
        public Group()
        {
            IsActive = true;
        }
        public long Id { get; set; }
        public long JourneyId { get; set; }
        public string Name { get; set; }        
        public int UetdsStatus { get; set; }
        public string UetdsMessage { get; set; }
        public long GrupReferensNo { get; set; }
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }       

    }
}
