using System;
using System.ComponentModel.DataAnnotations;

namespace AppointEase.Views
{
    public class AppointmentViewModel
    {
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Client Email")]
        public string ClientEmail { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
    }
}
