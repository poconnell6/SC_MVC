using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SC_MVC.Models
{
    [Table("books")]
    public class Work
    {       
    [Key]
        public int PrimaryKey { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }


}