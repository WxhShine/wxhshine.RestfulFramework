using ASPCoreRestfulApiDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Data
{
    public class AspCoreRestApiDbContext : DbContext
    {
        public AspCoreRestApiDbContext(DbContextOptions<AspCoreRestApiDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(x => x.Company)
                        .WithMany(x => x.Employees)
                        .HasForeignKey(x => x.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                        .HasData(
            new Company
            {
                Id = "A7A21717-B5F7-4085-AEB0-4E60641FBAE9",
                Name = "Microsoft",
                Introduction = "Great Company"
            },
            new Company
            {
                Id = ("2A798ED9-CBF5-4A8F-AAC8-937791A82919"),
                Name = "Google",
                Introduction = "No Evil Company...",
            },
            new Company
            {
                Id = ("B93E23E7-4E9D-4FB4-AE18-B5120D50C165"),
                Name = "Alipapa",
                Introduction = "Fubao Company"
            });

        }
    }
}
