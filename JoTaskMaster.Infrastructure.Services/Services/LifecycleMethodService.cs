using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;

namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class LifecycleMethodService : ILifecycleMethodService
    {
        private readonly JoTaskMasterDbContext _context;

        public LifecycleMethodService(JoTaskMasterDbContext context) => _context = context;

        public void CreateLifecycleMethod(LifecycleMethod lifecycleMethod)
        {
            _context.LifecycleMethods.Add(lifecycleMethod);
            _context.SaveChanges();
        }

        public async Task<int> CreateLifecycleMethodAsync(LifecycleMethod lifecycleMethod)
        {
            await _context.LifecycleMethods.AddAsync(lifecycleMethod);
            return await _context.SaveChangesAsync();
        }

        public void DeleteLifecycleMethod(int id)
        {
            _context.LifecycleMethods
                    .Where(l => l.Id == id)
                    .ExecuteDelete();
            _context.SaveChanges();
        }

        public async Task<int> DeleteLifecycleMethodAsync(int id)
        {
           await _context.LifecycleMethods
                         .Where(l => l.Id == id)
                         .ExecuteDeleteAsync();

           return  await _context
                         .SaveChangesAsync();
        }

        public List<LifecycleMethod>? GetAllLifecycleMethods()
        {
            var lif = _context.LifecycleMethods.ToList();

            if (lif.Any())
                return lif;
            else
                return null;
        }

        public async Task<List<LifecycleMethod>?> GetAllLifecycleMethodsAsync()
        {
            var lif = await _context.LifecycleMethods.ToListAsync();

            if (lif.Any())
                return lif;
            else
                return null;
        }

        public LifecycleMethod? GetLifecycleMethodById(int id)
        {
            return _context.LifecycleMethods
                    .Where (l => l.Id == id)
                    .FirstOrDefault();
        }

        public async Task<LifecycleMethod?> GetLifecycleMethodByIdAsync(int id)
        {
            return await  _context.LifecycleMethods
                          .Where(l => l.Id == id)
                          .FirstOrDefaultAsync();
        }

        public LifecycleMethod? GetLifecycleMethodByName(string name)
        {
            return     _context.LifecycleMethods
                       .Where(l => l.MethodName == name)
                       .FirstOrDefault();
        }

        public async Task<LifecycleMethod?> GetLifecycleMethodByNameAsync(string name)
        {
            return await _context.LifecycleMethods
                         .Where(l => l.MethodName == name)
                         .FirstOrDefaultAsync();
        }

        public LifecycleMethod? GetLifecycleMethodyByProject(Project project)
        {
            return  _context.LifecycleMethods
                    .Where(l => l.Id == project.Id)
                    .FirstOrDefault();
        }

        public async Task<LifecycleMethod?> GetLifecycleMethodyByProjectAsync(Project project)
        {
            return await _context.LifecycleMethods
                         .Where(l => l.Id == project.Id)
                         .FirstOrDefaultAsync();
        }

        public void UpdateLifecycleMethod(LifecycleMethod lifecycleMethod)
        {
            _context.LifecycleMethods.Update(lifecycleMethod);
            _context.SaveChanges();
        }

        public async Task<int> UpdateLifecycleMethodAsync(LifecycleMethod lifecycleMethod)
        {
            _context.LifecycleMethods.Update(lifecycleMethod);
            return await _context.SaveChangesAsync();
        }
    }
}
