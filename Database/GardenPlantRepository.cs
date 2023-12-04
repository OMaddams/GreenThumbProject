using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbProject.Database
{
    public class GardenPlantRepository
    {

        private readonly AppDbContext context;

        public GardenPlantRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GardenPlantModel>> GetAll()
        {
            return await context.GardenPlant.ToListAsync();
        }
        public async Task<GardenPlantModel?> GetById(int id)
        {
            return await context.GardenPlant.FindAsync(id);
        }
        public async Task<List<GardenPlantModel>> GetByUserId(int id)
        {
            return await context.GardenPlant.Include(gp => gp.Garden).Where(gp => gp.Garden.UserId == id).ToListAsync();
        }
        public async Task AddAsync(GardenPlantModel gardenplantToAdd)
        {
            await context.GardenPlant.AddAsync(gardenplantToAdd);
        }

    }
}
