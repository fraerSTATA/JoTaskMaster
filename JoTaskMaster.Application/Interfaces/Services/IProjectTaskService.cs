using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface IProjectTaskService 
    {
        #region Commands
        public void CreateProjectTask(ProjectTask projectTask);
        public Task<int> CreateProjectTaskAsync(ProjectTask projectTask);
        public void DeleteProjectTask(int id);
        public Task<int> DeleteProjectTaskAsync(int id);
        public void UpdateProjectTask(ProjectTask projectTask);
        public Task<int> UpdateProjectTaskAsync(ProjectTask projectTask);

        #endregion

        #region Queries
        public List<ProjectTask>? GetAllProjectTasks();
        public Task<List<ProjectTask>?> GetAllProjectTasksAsync();
        public ProjectTask? GetProjectTaskById(int id);
        public Task<ProjectTask?> GetProjectTaskByIdAsync(int id);
        public List<ProjectTask>? GetProjectTasksByProject(Project project);
        public Task<List<ProjectTask>?> GetProjectTasksByProjectAsync(Project project);
        public List<ProjectTask>? GetProjectTasksByUser(User user);
        public Task<List<ProjectTask>?> GetProjectTasksByUserAsync(User user);
        public List<ProjectTask>? GetProjectTasksByStatus(StatusType status);
        public Task<List<ProjectTask>?> GetProjectTasksByStatusAsync(StatusType status);
        public ProjectTask? GetProjectTaskByTaskRepsonce(TaskResponse taskResponse);
        public Task<ProjectTask?> GetProjectTaskByTaskRepsonceAsync(TaskResponse taskResponse);
        public ProjectTask? GetProjectTaskBySubTask(ProjectTask SubTask);
        public Task<ProjectTask?> GetProjectTaskBySubTaskAsync(ProjectTask SubTask);


        #endregion
    }
}
