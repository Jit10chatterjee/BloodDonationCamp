using Microsoft.EntityFrameworkCore;

namespace BloodBankMicroservice.Models
{
    public class BloodBankdbContext:DbContext
    {
        public BloodBankdbContext()
        {
            
        }
        public BloodBankdbContext(DbContextOptions<BloodBankdbContext> options):base(options)
        {
            
        }

        public DbSet<BloodBankInfo> BloodBankInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var b1 = new BloodBankInfo { Id = 1, BloodBankName = "Sangam", City = "Kolkata", State = "West Bengal", ContactNumber = "033-2580-2587", Address = "2/1 - RC Road" };
            var b2 = new BloodBankInfo { Id = 2, BloodBankName = "Seva", City="kalyan", State="Maharashtra", ContactNumber="9187485960", Address = "33- NBC Street" };

            modelBuilder.Entity<BloodBankInfo>().HasData(b1, b2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
