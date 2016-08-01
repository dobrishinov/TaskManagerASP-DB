using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels.Users
{
    public class UsersEditVM : BaseEditVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage="Admin status is required")]
        [Display(Name="Admin Status")]
        public bool AdminStatus { get; set; }
    }
}