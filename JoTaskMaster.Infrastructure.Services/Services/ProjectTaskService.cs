
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;

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
            return _context.ProjectTasks.ToList();
        }

        public async Task<List<ProjectTask>?> GetAllProjectTasksAsync()
        {
            return await _context.ProjectTasks.ToListAsync();
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
            return _context.ProjectTasks
                   .Where(p => p.Id == project.Id)
                   .ToList();
        }

        public async Task<List<ProjectTask>?> GetProjectTasksByProjectAsync(Project project)
        {
            return await _context.ProjectTasks
              .Where(p => p.Id == project.Id)
              .ToListAsync();
        }

        public List<ProjectTask>? GetProjectTasksByStatus(StatusType status)
        {
            return _context.ProjectTasks
                   .Where(p => p.TaskStatusId == status.Id)
                   .ToList();
        }

        public async Task<List<ProjectTask>?> GetProjectTasksByStatusAsync(StatusType status)
        {
            return await _context.ProjectTasks
                         .Where(p => p.TaskStatusId == status.Id)
                         .ToListAsync();
        }

        public List<ProjectTask>? GetProjectTasksByUser(User user)
        {
            return _context.ProjectTasks
                   .Where(p => p.TaskManagerId == user.Id)
                   .ToList();
        }

        public async Task<List<ProjectTask>?> GetProjectTasksByUserAsync(User user)
        {
            return await _context.ProjectTasks
                         .Where(p => p.TaskManagerId == user.Id)
                         .ToListAsync();
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
