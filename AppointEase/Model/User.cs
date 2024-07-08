using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppointEase.Model
{
    public class User : IdentityUser
    {
        [Required]
        public string Role { get; set; }
    }
}
