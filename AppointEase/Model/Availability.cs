using System;

namespace AppointEase.Model
{
    public class Availability
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public User User { get; set; }
    }
}
