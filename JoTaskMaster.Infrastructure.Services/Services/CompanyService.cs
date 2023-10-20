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
    public class CompanyService : ICompanyService
    {

        private readonly JoTaskMasterDbContext _context;

        public CompanyService (JoTaskMasterDbContext context) => _context = context;
        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public async Task<int> CreateCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            return await _context.SaveChangesAsync();
        }

        public void DeleteCompany(int id)
        {
            _context.Companies
                .Where(c => c.Id == id)
                .ExecuteDelete();
            _context.SaveChanges();   
        }

        public async Task<int> DeleteCompanyAsync(int id)
        {
           await _context.Companies
                 .Where(c => c.Id == id)
                 .ExecuteDeleteAsync();
           return await _context.SaveChangesAsync();
        }

        public List<Company>? GetAllCompanies() => _context.Companies.ToList();
       
        public async Task<List<Company>?> GetAllCompaniesAsync() => await _context.Companies.ToListAsync();      

        public Company? GetCompanyById(int id)
        {
            return _context.Companies.Where
                (c => c.Id == id).FirstOrDefault();
                
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {   
            return await _context.Companies.Where
                (c => c.Id == id).FirstOrDefaultAsync();
        }

        public Company? GetCompanyByName(string name)
        {
            return _context.Companies
                .Where(c => c.CompanyName == name)
                .FirstOrDefault();
        }

        public async Task<Company?> GetCompanyByNameAsync(string name)
        {
                 return  await _context.Companies
                .Where(c => c.CompanyName == name)
                .FirstOrDefaultAsync();
        }

        public Company? GetCompanyByUser(User user)
        {
            return
             _context.Companies
             .Where(c => c.Id == user.UserCompanyId)
             .FirstOrDefault();
        }

        public async Task<Company?> GetCompanyByUserAsync(User user)
        {
            return await
              _context.Companies
              .Where(c => c.Id == user.UserCompanyId)
              .FirstOrDefaultAsync();
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        public async Task<int> UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            return await _context.SaveChangesAsync();
        }
    }
}
