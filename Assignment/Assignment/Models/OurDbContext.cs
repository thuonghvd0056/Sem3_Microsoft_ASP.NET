using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> userAccounts { get; set; }
    }
}