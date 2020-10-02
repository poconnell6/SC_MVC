using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SC_MVC.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key] // this is an item level key not a cart key
        public int PrimaryKey { get; set; }

        [Required]
       // [ForeignKey("Id")] // whole carts are pulled by refrencing user id. In a more mature version of this there would be an index on this for performance reasons (if one isn't created automatically due to it being a FK)
        public string UserId { get; set; }

        public int BookId { get; set; }

    }
}