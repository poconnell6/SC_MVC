using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SC_MVC.Models
{
    public class SC_MVC_DBContext : DbContext
    {
        public SC_MVC_DBContext() : base("SC_MVC_DBContext") { }
        public DbSet<Work> Works { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
    }
}