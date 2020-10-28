using System;
using System.Collections.Generic;
using System.Text;

namespace HRTourismApp.Models
{
    public class City
    {
        public int Id { get; set; }        
        public string Name { get; set; }
    }
    public class District
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
