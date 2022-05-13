using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberCafe.Models.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name="Admin Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name="Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}