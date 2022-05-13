using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CyberCafe.Models.TableViewModels;
namespace CyberCafe.Models.ViewModels
{
    public class ReportViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime End { get; set; }

        public List<UsersTableViewModel> Users { get; set; }
    }
}