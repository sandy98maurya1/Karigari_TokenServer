using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<UserDTO>();

            base.OnModelCreating(builder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> UserRoles { get; set; }


        [NotMapped]
        public virtual DbSet<UserDTO> UserView { get; set; }
    }
}
