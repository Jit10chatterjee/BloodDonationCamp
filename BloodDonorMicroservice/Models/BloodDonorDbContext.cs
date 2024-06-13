using Microsoft.EntityFrameworkCore;

namespace BloodDonorMicroservice.Models
{
    public class BloodDonorDbContext:DbContext
    {
        public BloodDonorDbContext()
        {
            
        }
        public BloodDonorDbContext(DbContextOptions<BloodDonorDbContext> options):base(options)
        {
            
        }

        public DbSet<BloodDonorInfo> BloodDonorInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var b1 = new BloodDonorInfo { Id = 1, FirstName = "jit", LastName = "chatterjee", City = "Maldah", ContactNumber = "7002589633", Address = "2/1 - RC Road",BloodGroup="AB+",DateOfBrith = DateTime.Parse("08-05-2002")};
            var b2 = new BloodDonorInfo { Id = 2, FirstName = "Rahul", LastName = "Ghosh", City = "Kolkata", ContactNumber = "8475889658", Address = "RBC road", BloodGroup = "B+", DateOfBrith = DateTime.Parse("02-11-2004") };
            var b3 = new BloodDonorInfo { Id = 3, FirstName = "Ram", LastName = "Das", City = "Kolkata", ContactNumber = "7884536985", Address = "2 CBN Lane", BloodGroup = "O+", DateOfBrith = DateTime.Parse("19-03-1998") };
            var b4 = new BloodDonorInfo { Id = 4, FirstName = "Shyam", LastName = "Bardhan", City = "Bhatpara", ContactNumber = "9874585652", Address = "33/87 ghosh para road", BloodGroup = "A+", DateOfBrith = DateTime.Parse("17-01-2001") };
            var b5 = new BloodDonorInfo { Id = 5, FirstName = "Soumya", LastName = "Sen", City = "Naihati", ContactNumber = "8966364587", Address = "2/1 - RC Road", BloodGroup = "AB-", DateOfBrith = DateTime.Parse("21-05-2002") };

            modelBuilder.Entity<BloodDonorInfo>().HasData(b1, b2, b3, b4, b5);

            base.OnModelCreating(modelBuilder);
        }
    }
}
