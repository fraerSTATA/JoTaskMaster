
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly JoTaskMasterDbContext _context;

        public ProjectTaskService(JoTaskMasterDbContext context)
        {
            _context = context;
        }

        public void CreateProjectTask(ProjectTask projectTask)
        {
           _context.ProjectTasks.Add(projectTask);
           _context.SaveChanges();
        }

        public async Task<int> CreateProjectTaskAsync(ProjectTask projectTask)
        {
           await _context.ProjectTasks.AddAsync(projectTask);
           return await _context.SaveChangesAsync();
        } 

        public void DeleteProjectTask(int id)
        {
            _context.ProjectTasks
                .Where(p => p.Id == id)
                .ExecuteDelete();
            _context.SaveChanges();
        }

        public async Task<int> DeleteProjectTaskAsync(int id)
        {
            await _context.ProjectTasks
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync();
        }

        public List<ProjectTask>? GetAllProjectTasks()
        {
            var pT = _context.ProjectTasks.ToList();

            if (pT.Any())
                return pT;
            else
                return null;
        }

        public async Task<List<ProjectTask>?> GetAllProjectTasksAsync()
        {
            var pT = await _context.ProjectTasks.ToListAsync();

            if (pT.Any())
                return pT;
            else
                return null;
        }

        public ProjectTask? GetProjectTaskById(int id)
        {
            return _context.ProjectTasks
                   .Where(p => p.Id == id)
                   .FirstOrDefault();
        }

        public async Task<ProjectTask?> GetProjectTaskByIdAsync(int id)
        {
            return  await _context.ProjectTasks
                   .Where(p => p.Id == id)
                   .FirstOrDefaultAsync();
        }

        public ProjectTask? GetProjectTaskBySubTask(ProjectTask SubTask)
        {
            return _context.ProjectTasks
                   .Where(p => p.Id == SubTask.Id)
                   .FirstOrDefault();
        }

        public async Task<ProjectTask?> GetProjectTaskBySubTaskAsync(ProjectTask SubTask)
        {

            return await _context.ProjectTasks
                         .Where(p => p.Id == SubTask.Id)
                         .FirstOrDefaultAsync();

        }

        public ProjectTask? GetProjectTaskByTaskRepsonce(TaskResponse taskResponse)
        {
            return  _context.ProjectTasks
                    .Where(p => p.Id == taskResponse.TaskId)
                    .FirstOrDefault();
        }

        public async Task<ProjectTask?> GetProjectTaskByTaskRepsonceAsync(TaskResponse taskResponse)
        {
            return await _context.ProjectTasks
                  .Where(p => p.Id == taskResponse.TaskId)
                  .FirstOrDefaultAsync();
        }

        public List<ProjectTask>? GetProjectTasksByProject(Project project)
        {
                var pT = _context.ProjectTasks
                       .Where(p => p.Id == project.Id)
                       .ToList();

                if (pT.Any())
                    return pT;
                else
                    return null;
        }

        public async Task<List<ProjectTask>?> GetProjectTasksByProjectAsync(Project project)
        {
                var pT = await _context.ProjectTasks
                               .Where(p => p.Id == project.Id)
                               .ToListAsync();

                if (pT.Any())
                    return pT;
                else
                    return null;
        }

        public List<ProjectTask>? GetProjectTasksByStatus(StatusType status)
        {
            var pT = _context.ProjectTasks
                   .Where(p => p.TaskStatusId == status.Id)
                   .ToList();

            if (pT.Any())
                return pT;
            else
                return null;
        }
    

        public async Task<List<ProjectTask>?> GetProjectTasksByStatusAsync(StatusType status)
        {
                 var pT = await _context.ProjectTasks
                         .Where(p => p.TaskStatusId == status.Id)
                         .ToListAsync();


                 if (pT.Any())
                     return pT;
                 else
                     return null;
        }

        public List<ProjectTask>? GetProjectTasksByUser(User user)
        {
            var pT = _context.ProjectTasks
                   .Where(p => p.TaskManagerId == user.Id)
                   .ToList();

            if (pT.Any())
                return pT;
            else
                return null;
        }

        public async Task<List<ProjectTask>?> GetProjectTasksByUserAsync(User user)
        {
            var pT = await _context.ProjectTasks
                         .Where(p => p.TaskManagerId == user.Id)
                         .ToListAsync();
            if (pT.Any())
                return pT;
            else
                return null;
        }

        public void UpdateProjectTask(ProjectTask projectTask)
        {
            _context.ProjectTasks.Update(projectTask);
            _context.SaveChanges();
        }

        public async Task<int> UpdateProjectTaskAsync(ProjectTask projectTask)
        {
            _context.ProjectTasks.Update(projectTask);
            return await _context.SaveChangesAsync();
        }
    }
}
