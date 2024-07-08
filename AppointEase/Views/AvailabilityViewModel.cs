using System;
using System.ComponentModel.DataAnnotations;

namespace AppointEase.Views
{
    public class AvailabilityViewModel
    {
        [Required]
        [Display(Name = "Day of the Week")]
        public string DayOfWeek { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }
    }
}
