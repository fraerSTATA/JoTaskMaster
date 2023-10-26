using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface IStatusTypeService
    {
        #region Commands
        public void CreateStatusType(StatusType company);
        public Task<int> CreateStatusTypeAsync(StatusType company);
        public void DeleteStatusType(int id);
        public Task<int> DeleteStatusTypeAsync(int id);
        public void UpdateStatusType(StatusType company);
        public Task<int> UpdateStatusTypeAsync(StatusType company);

        #endregion

        #region Queries
        public List<StatusType>? GetAllStatusTypes();
        public Task<List<StatusType>?> GetAllStatusTypesAsync();
        public StatusType? GetStatusTypeById(int id);
        public Task<StatusType?> GetStatusTypeByIdAsync(int id);
        public List<StatusType>? GetStatusTypeByName(string name);
        public Task<List<StatusType>?> GetStatusTypeByNameAsync(string name);
        public StatusType? GetStatusTypeByProject(Project project);
        public Task<StatusType?> GetStatusTypeByProjectAsync(Project project);
        #endregion
    }
}
