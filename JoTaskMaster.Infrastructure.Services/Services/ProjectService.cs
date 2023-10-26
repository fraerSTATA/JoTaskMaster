using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Project>? GetAllProjects() => _context.Projects.ToList();


        public async Task<List<Project>?> GetAllProjectsAsync() => await _context.Projects.ToListAsync();


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
            return _context.Projects.Where(p => p.UserManagerId == user.Id).ToList();
        }

        public async Task<List<Project>?> GetProjectByUserAsync(User user)
        {
            return await _context.Projects.Where(p => p.UserManagerId == user.Id).ToListAsync();
        }

        public  List<Project>? GetProjectsByCompany(Company company)
        {
            return _context.Projects.Where(p => p.UserManager.UserCompanyId == company.Id).ToList();
        }

        public async Task<List<Project>?> GetProjectsByCompanyAsync(Company company)
        {
            return await _context.Projects.Where(p => p.UserManager.UserCompanyId == company.Id).ToListAsync();
        }

        public List<Project>? GetProjectsByStatus(StatusType status)
        {
            return _context.Projects.Where(p => p.Status == status).ToList();
        }

        public async Task<List<Project>?> GetProjectsByStatusAsync(StatusType status)
        {
            return await _context.Projects.Where(p => p.Status == status).ToListAsync();
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
