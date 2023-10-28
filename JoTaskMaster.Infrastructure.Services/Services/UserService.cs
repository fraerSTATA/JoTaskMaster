using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;


namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class UserService : IUserService
    {
        private readonly JoTaskMasterDbContext _context;

        public UserService(JoTaskMasterDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<int> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();

        }

        public void DeleteUser(int id)
        {
            _context.Users
                    .Where(u => u.Id == id)
                    .ExecuteDelete();
            _context.SaveChanges();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
             await _context.Users
                   .Where(u => u.Id == id)
                   .ExecuteDeleteAsync();
             return  await _context.SaveChangesAsync();
        }

        public List<User>? GetAllUsers() => _context.Users.ToList();


        public async Task<List<User>?> GetAllUsersAsync() => await _context.Users.ToListAsync();

        public User? GetUserByEmail(string email)
        {
           return   _context.Users
                    .Where(u => u.Email == email)
                    .FirstOrDefault();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                         .Where(u => u.Email == email)
                         .FirstOrDefaultAsync();
        }

        public User? GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public Task<User?> GetUserByIdAsync(int id) => _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public void UpdateUser(User copy)
        {
            _context.Users.Update(copy);
            _context.SaveChanges();
        }

        public async Task<int> UpdateUserAsync(User copy)
        {
            _context.Update(copy);
            return await _context.SaveChangesAsync();
        }

    }
}
