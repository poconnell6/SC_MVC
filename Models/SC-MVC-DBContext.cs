using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SC_MVC.Models
{
    //To customise user properties change IdentityUser to AppUser or something and create a coresponding class that inherits from IdentityUser (same for IdentityRole)
    public class SC_MVC_DBContext : IdentityDbContext<IdentityUser>
    {
        public SC_MVC_DBContext() : base("SC_MVC_DBContext") { }
        public DbSet<Work> Works { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
    }
}