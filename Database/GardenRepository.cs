using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbProject.Database
{
    public class GardenRepository
    {
        private readonly AppDbContext context;
        public GardenRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GardenModel>> GetAll()
        {
            return await context.Garden.ToListAsync();
        }
        public async Task<GardenModel?> GetById(int id)
        {
            return await context.Garden.FindAsync(id);
        }
        public async Task<GardenModel?> GetByUserId(int? userId)
        {
            return await context.Garden.Where(g => g.UserId == userId).FirstOrDefaultAsync();
        }


    }
}
