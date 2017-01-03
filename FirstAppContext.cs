using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyFirstApp.Models;
using MyFirstApp.Data.Model;

namespace MyFirstApp
{
    public class FirstAppContext : DbContext
    {
        public DbSet<UserMaster> users { get; set; }
        public DbSet<MenuMaster> menus { get; set; }
        public DbSet<RoleMaster> roles { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
 
    }
}