using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCA.Mobile.API.Models
{
    public class AccountProfileViewModel
    {
        public string UserName { get; set; }
    }
    public class LoginAccessViewModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }

    }
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}