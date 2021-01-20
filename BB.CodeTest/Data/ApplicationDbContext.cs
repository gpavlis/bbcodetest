using BB.CodeTest.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BB.CodeTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organization> Organizaitons { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Organization>().HasData(new Organization[]
            {
                new Organization
                {
                    Id = 1,
                    Name = "Org1",
                    Size = OrgSize.Large
                },
                new Organization
                {
                    Id = 2,
                    Name = "Org2",
                    Size = OrgSize.Small
                }
            });

            builder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Sam",
                    LastName = "Stevens",
                    Address = "5517 W Kentucky Ave.",
                    City = "Lakewood",
                    State = "CO",
                    ZipCode = "80226",
                    OrganizationId = 1
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Dan",
                    LastName = "Jones",
                    Address = "5515 W Kentucky Ave.",
                    City = "Lakewood",
                    State = "CO",
                    ZipCode = "80226",
                    OrganizationId = 1
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Fred",
                    LastName = "Armin",
                    Address = "5513 W Kentucky Ave.",
                    City = "Lakewood",
                    State = "CO",
                    ZipCode = "80226",
                    OrganizationId = 1
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Harry",
                    LastName = "Scott",
                    Address = "1233 W Wyoming Pl.",
                    City = "Denver",
                    State = "CO",
                    ZipCode = "80227",
                    OrganizationId = 2
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Ian",
                    LastName = "Jefferies",
                    Address = "213 W Wyoming Pl.",
                    City = "Denver",
                    State = "CO",
                    ZipCode = "80227",
                    OrganizationId = 2
                }
            });
        }

    }
}
