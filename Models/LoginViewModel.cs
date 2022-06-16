using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VIATECH.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string? UserName { get; set; }

        [Required]
        [UIHint("password")]
        public string? Password { get; set; }

        [Display(Name = "To remember me")]
        public bool RememberMe { get; set; }
    }
}
