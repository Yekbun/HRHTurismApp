using System;

namespace HRTourismApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class UserSkill
    {
        public long ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int DailyRate { get; set; }
    }
}