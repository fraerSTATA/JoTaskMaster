using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface ILifecycleMethodService
    {
        
        #region Commands
        public void CreateLifecycleMethod(LifecycleMethod company);
        public Task<int> CreateLifecycleMethodAsync(LifecycleMethod company);
        public void DeleteLifecycleMethod(int id);
        public Task<int> DeleteLifecycleMethodAsync(int id);
        public void UpdateLifecycleMethod(LifecycleMethod company);
        public Task<int> UpdateLifecycleMethodAsync(LifecycleMethod company);

        #endregion

        #region Queries
        public List<LifecycleMethod>? GetAllLifecycleMethods();
        public Task<List<LifecycleMethod>?> GetAllLifecycleMethodsAsync();
        public LifecycleMethod? GetLifecycleMethodById(int id);
        public Task<LifecycleMethod?> GetLifecycleMethodByIdAsync(int id);
        public LifecycleMethod? GetLifecycleMethodByName(string name);
        public Task<LifecycleMethod?> GetLifecycleMethodByNameAsync(string name);
        public Task<LifecycleMethod?> GetLifecycleMethodyByProjectAsync(Project project);
        public LifecycleMethod? GetLifecycleMethodyByProject(Project project);
        #endregion
    }
}
