using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;

namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly JoTaskMasterDbContext _context;

        public ProjectService(JoTaskMasterDbContext context)
        {
            _context = context;
        }

        public void CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public async Task<int> CreateProjectAsync(Project project)
        {
             await _context.Projects.AddAsync(project);
             return await _context.SaveChangesAsync();
        }

        public void DeleteProject(int id)
        {
            _context.Projects
               .Where(p => p.Id == id)
               .ExecuteDelete();
            _context.SaveChanges();
        }

        public async Task<int> DeleteProjectAsync(int id)
        {
           await _context.Projects
              .Where(p => p.Id == id)
              .ExecuteDeleteAsync();
           return await _context.SaveChangesAsync();
        }

        public List<Project>? GetAllProjects()
        {
            if ( _context.Projects.Any())
                return _context.Projects.ToList();
            else
                return null;
        }


        public async Task<List<Project>?> GetAllProjectsAsync()
        {
            if (await _context.Projects.AnyAsync())
                return await _context.Projects.ToListAsync();
            else
                return null;
        }


        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Project?> GetProjectByNameAsync(string name)
        {
            return await  _context.Projects.Where(p=> p.ProjectName == name).FirstOrDefaultAsync();
        }

        public Project? GetProjectById(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public Project? GetProjectByName(string name)
        {
            return _context.Projects.Where(p => p.ProjectName == name).FirstOrDefault();
        }

        public List<Project>? GetProjectByUser(User user)
        {
            var proj = _context.Projects.Where(p => p.UserManagerId == user.Id).ToList();
            if (proj.Any())            
                return proj;
            else
                return null;
        }

        public async Task<List<Project>?> GetProjectByUserAsync(User user)
        {
            var proj = await _context.Projects.Where(p => p.UserManagerId == user.Id).ToListAsync();
            if (proj.Any())
                return proj;
            else
                return null;
        }

        public  List<Project>? GetProjectsByCompany(Company company)
        {
            var proj = _context.Projects.Where(p => p.UserManager.UserCompanyId == company.Id).ToList();
            if (proj.Any())
                return proj;
            else
                return null;
        }

        public async Task<List<Project>?> GetProjectsByCompanyAsync(Company company)
        {
            var proj = await _context.Projects.Where(p => p.UserManager.UserCompanyId == company.Id).ToListAsync();
            if (proj.Any())
                return proj;
            else
                return null;
        }

        public List<Project>? GetProjectsByStatus(StatusType status)
        {
            var proj = _context.Projects.Where(p => p.Status == status).ToList();
            if (proj.Any())
                return proj;
            else
                return null;
        }

        public async Task<List<Project>?> GetProjectsByStatusAsync(StatusType status)
        {
            var proj = await _context.Projects.Where(p => p.Status == status).ToListAsync();
            if (proj.Any())
                return proj;
            else
                return null;
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public async Task<int> UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
           return await _context.SaveChangesAsync();
        }
    }
}
