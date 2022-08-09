using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Models
{
  public  class RegisterationVM
    {
        [Required(ErrorMessage ="Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm  Required")]
        [Compare("Password",ErrorMessage ="Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
