using System;

namespace HRTourismApp.Models
{
    public partial class User
    {
        public User()
        {           
            IsActive = true;
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }       
        public string NameSurname { get; set; }
        public string Password { get; set; }      
        public string Email { get; set; }       
        
                
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual Company Company { get; set; }  
        public bool IsMailSent { get; set; }

    }
}
