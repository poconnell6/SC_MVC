using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SC_MVC.Models
{
    [Table("contact")]
    public class ContactRequest
    {
        [Key]
        public int intPrimaryKey { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string txtName { get; set; }

        [Display(Name = "Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime dteDate { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string txtEmail { get; set; }

        [Display(Name = "Confirm Email Address")]
        [Required]
        [CompareAttribute(nameof(txtEmail), ErrorMessage = "Passwords don't match.")]
        public string txtEmailConfirm { get; set; }

        [Display(Name = "Message Subject")]
        [Required]
        public string txtSubject { get; set; }

        [Display(Name = "Your Message")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string txtMessage { get; set; }
    }
}