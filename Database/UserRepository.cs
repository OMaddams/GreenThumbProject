using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbProject.Database
{

    public class UserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<UserModel?> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }
        public async Task<UserModel?> GetByUsername(string username)
        {
            return await context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

    }
}
