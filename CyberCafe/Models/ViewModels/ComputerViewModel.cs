using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberCafe.Models.ViewModels
{
    public class ComputerViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display (Name="Computer Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Computer Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name="Computer IP Address")]
        public string IP { get; set; }
    }
}