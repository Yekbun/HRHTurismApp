using System;

namespace HRTourismApp.Helper.OCR
{
    public class MRZResult
    {
        public string DocumentType { get; set; }
        public string Gender { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string IssuingCountryIso { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string NationalityIso { get; set; }
        public string NationalityName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Boolean IsValid { get; set; }
        public string ValidationMessage{ get; set; }
        public string DocumentTypeDescription { get; set; }
       
    }
}
