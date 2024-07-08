using System;

namespace AppointEase.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
    }
}
