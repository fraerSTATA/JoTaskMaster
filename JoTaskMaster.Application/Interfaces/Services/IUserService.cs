using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        #region Commands
        public void DeleteUser(int id);
        public Task<int> DeleteUserAsync(int id);
        public void UpdateUser(User copy);
        public Task<int> UpdateUserAsync(User copy);
        public void CreateUser(User user);
        public Task<int> CreateUserAsync(User user);
        #endregion

        #region Queries
        public Task<User?> GetUserByEmailAsync(string email);
        public User? GetUserByEmail(string email);
        public Task<User?> GetUserByIdAsync(int id);
        public User? GetUserById(int id);
        public List<User>? GetAllUsers();
        public Task<List<User>?> GetAllUsersAsync();

        #endregion

    }
}