using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext() : base("dbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbConnectionContext>());
        }
        public DbSet<PhotoGallery> PhotoGallery { get; set; }

    }
}