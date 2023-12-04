using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbProject.Database
{
    public class PlantRepository
    {
        private readonly AppDbContext context;

        public PlantRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PlantModel>> GetAllAsync()
        {
            return await context.Plants.ToListAsync();
        }

        public async Task<PlantModel?> GetByIdAsync(int id)
        {
            return await context.Plants.FindAsync(id);
        }

        public async Task<PlantModel?> GetByNameAsync(string name)
        {
            return await context.Plants.Where(p => p.PlantName == name).FirstOrDefaultAsync();
        }

        public async Task Delete(PlantModel plantToDelete)
        {
            context.Remove(plantToDelete);
        }
        public async Task DeleteById(int id)
        {
            PlantModel? plantToDelete = await GetByIdAsync(id);
            if (plantToDelete != null)
            {
                await Delete(plantToDelete);
            }
        }
    }
}
