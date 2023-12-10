using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumbProject.Managers;
using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbProject.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public AppDbContext()
        {
            _provider = new GenerateEncryptionProvider(KeyManager.GetEncryptionKey());
        }

        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GardenModel> Garden { get; set; }
        public DbSet<GardenPlantModel> GardenPlant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GardenPlantModel>().HasKey(gd => new { gd.PlantId, gd.GardenId });

            modelBuilder.UseEncryption(_provider);

            modelBuilder.Entity<UserModel>().HasData(new UserModel { UserId = 1, UserName = "admin", UserPassword = "admin", UserEmail = "admin@admin.admin" });

            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 3, PlantName = "Lotus", PlantDescription = "A beautiful aquatic plant, considered holy in some cultures" },
                new PlantModel { PlantId = 4, PlantName = "Lily", PlantDescription = "Lilium is a genus of herbaceous flowering plants growing from bulbs, all with large prominent flowers. " },
                new PlantModel { PlantId = 5, PlantName = "Azalea", PlantDescription = "Azaleas bloom in the spring, their flowers often lasting several weeks." },
                new PlantModel { PlantId = 6, PlantName = "Chrysanthemum", PlantDescription = "Most species originate from East Asia and the center of diversity is in China. Countless horticultural varieties and cultivars exist." },
                new PlantModel { PlantId = 7, PlantName = "Daffodil", PlantDescription = "Narcissus is a genus of predominantly spring flowering perennial plants of the amaryllis family, Amaryllidaceae. Various common names including daffodil, narcissus and jonquil, are used to describe all or some members of the genus." }
                );

            modelBuilder.Entity<InstructionModel>().HasData(new InstructionModel { InstructionId = 1, InstructionDescription = "Keep it in your pond", PlantId = 3 },
                new InstructionModel { InstructionId = 2, InstructionDescription = "Water", PlantId = 4 },
                new InstructionModel { InstructionId = 3, InstructionDescription = "Keep lightly shaded", PlantId = 4 },
                new InstructionModel { InstructionId = 4, InstructionDescription = "Fertalize when planting", PlantId = 5 });
        }
    }
}
