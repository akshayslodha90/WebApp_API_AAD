using CourseLibrary.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseLibrary.API.DbContexts
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options)
           : base(options)
        {
        }


        public DbSet<ComplaintDetail> ComplaintDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data

            modelBuilder.Entity<ComplaintDetail>().HasData(
                 new ComplaintDetail()
                 {
                     Area = "Swargate",
                     City = "Pune",
                     ContactNumber = "",
                     CreatedDate = DateTime.UtcNow,
                     LastModifiedDate = DateTime.Now,
                     EmailAddress = "ab123@gmail.com",
                     Id = Guid.NewGuid(),
                     IssueDescription = "Since Last Four Days we are since Network Range Issues in Area. Please can you resolve asap",
                     Title = "Internet Range Issue"
                 },
                 new ComplaintDetail()
                 {
                     Area = "Magarpatta",
                     City = "Pune",
                     ContactNumber = "",
                     CreatedDate = DateTime.UtcNow,
                     LastModifiedDate = DateTime.Now,
                     EmailAddress = "ab123@gmail.com",
                     Id = Guid.NewGuid(),
                     IssueDescription = "Increase in Call Drop Since Last Few Days",
                     Title = "Call Drop Issue"
                 },
                 new ComplaintDetail()
                 {
                     Area = "Magarpatta",
                     City = "Pune",
                     ContactNumber = "",
                     CreatedDate = DateTime.UtcNow,
                     LastModifiedDate = DateTime.Now,
                     EmailAddress = "231abc@gmail.com",
                     Id = Guid.NewGuid(),
                     IssueDescription = "Increase in Call Drop Since Last Few Days",
                     Title = "Call Drop Issue"
                 }
                );



            base.OnModelCreating(modelBuilder);
        }
    }
}
