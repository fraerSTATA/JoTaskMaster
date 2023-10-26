using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface IProjectService
    {
        #region Commands
        public void CreateProject(Project project);
        public Task<int> CreateProjectAsync(Project project);
        public void DeleteProject(int id);
        public Task<int> DeleteProjectAsync(int id);
        public void UpdateProject(Project project);
        public Task<int> UpdateProjectAsync(Project project);

        #endregion

        #region Queries
        public List<Project>? GetAllProjects();
        public Task<List<Project>?> GetAllProjectsAsync();
        public Project? GetProjectById(int id);
        public Task<Project?> GetProjectByIdAsync(int id);
        public Project? GetProjectByName(string name);
        public Task<Project?> GetProjectByNameAsync(string name);
        public Task<List<Project>?> GetProjectByUserAsync(User user);
        public List<Project>? GetProjectByUser(User user);
        public List<Project>? GetProjectsByStatus(StatusType status);
        public Task<List<Project>?> GetProjectsByStatusAsync(StatusType status);
        public List<Project>? GetProjectsByCompany(Company company);
        public Task<List<Project>?> GetProjectsByCompanyAsync(Company company);
        #endregion
    }
}
