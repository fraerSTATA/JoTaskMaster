﻿using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;

namespace JoTaskMaster.Infrastructure.Services.Services
{
    public class StatusTypeService : IStatusTypeService
    {
        private readonly JoTaskMasterDbContext _context;

        public StatusTypeService(JoTaskMasterDbContext context) => _context = context;
        public void CreateStatusType(StatusType status)
        {
            _context.StatusTypes.Add(status);
            _context.SaveChanges();
        }

        public async Task<int> CreateStatusTypeAsync(StatusType status)
        {
           await _context.StatusTypes.AddAsync(status);
           return await _context.SaveChangesAsync();
        }

        public void DeleteStatusType(int id)
        {
                _context.StatusTypes
                .Where(s => s.Id == id)
                .ExecuteDelete();
        }

        public async Task<int> DeleteStatusTypeAsync(int id)
        {
           return await _context.StatusTypes
                        .Where(s => s.Id == id)
                        .ExecuteDeleteAsync();
        }

        public List<StatusType>? GetAllStatusTypes()
        {
            var st = _context.StatusTypes.ToList();

            if (st.Any())
                return st;
            else
                return null;
        }

        public async Task<List<StatusType>?> GetAllStatusTypesAsync()
        {
            var st = await _context.StatusTypes.ToListAsync();

            if (st.Any())
                return st;
            else
                return null;

        }       

        public StatusType? GetStatusTypeById(int id)
        {
            return _context.StatusTypes
                   .Where(s => s.Id == id)
                   .FirstOrDefault();
        }

        public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
        {
            return await _context.StatusTypes.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public StatusType? GetStatusTypeByName(string name)
        {
            return _context.StatusTypes
                .Where( s => s.StatusName == name)
                .FirstOrDefault();
        }

        public async Task<StatusType?> GetStatusTypeByNameAsync(string name)
        {
            return await _context.StatusTypes
                .Where(s => s.StatusName == name)
                .FirstOrDefaultAsync();
        }

        public StatusType? GetStatusTypeByProject(Project project)
        {
            return
                 _context.StatusTypes
                 .Where(c => c.Id == project.StatusId)
                 .FirstOrDefault();
        }

        public async Task<StatusType?> GetStatusTypeByProjectAsync(Project project)
        {
            return await
                   _context.StatusTypes
                   .Where(c => c.Id == project.StatusId)
                   .FirstOrDefaultAsync();
        }

        public void UpdateStatusType(StatusType status)
        {
             _context.StatusTypes.Update(status);
             _context.SaveChanges();
        }

        public async Task<int> UpdateStatusTypeAsync(StatusType status)
        {
            _context.StatusTypes.Update(status);
            return await _context.SaveChangesAsync();
        }
    }
}
