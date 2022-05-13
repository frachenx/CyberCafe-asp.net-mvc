using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberCafe.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string EntryID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string ComputerID { get; set; }
        public string ComputerName { get; set; }
        public string IdProof { get; set; }
        public DateTime? InTime { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Remark { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }
    }
}