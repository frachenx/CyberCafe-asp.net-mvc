using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CyberCafe.Models.TableViewModels;
namespace CyberCafe.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public string Search { get; set; }
        public List<UsersTableViewModel>  Users { get; set; }
    }
}