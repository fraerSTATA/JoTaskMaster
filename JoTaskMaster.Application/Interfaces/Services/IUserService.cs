using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {

        public Task<User?> GetUserByIdAsync(int id);
        public User? GetUserById(int id);
        public IList<User>? GetAllUsers();
        public Task<IList<User>>? GetAllUsersAsync();
        public void DeleteUser(int id);
        public Task<int> DeleteUserAsync(int id);
        public void UpdateUser(User copy);
        public Task<int> UpdateUserAsync(User copy);
        public void CreateUser(User user);
        public Task<int> CreateUserAsync(User user);

    }
}