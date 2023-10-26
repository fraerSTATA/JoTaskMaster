using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Persistence.RelationalDB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        #region Commands
        public void CreateCompany(Company company);
        public Task<int> CreateCompanyAsync(Company company);
        public void DeleteCompany(int id);
        public Task<int> DeleteCompanyAsync(int id);          
        public void UpdateCompany(Company company);
        public Task<int> UpdateCompanyAsync(Company company);
        
        #endregion
        
        #region Queries
        public List<Company>? GetAllCompanies();
        public Task<List<Company>?> GetAllCompaniesAsync();
        public Company? GetCompanyById(int id);
        public Task<Company?> GetCompanyByIdAsync(int id);
        public Company? GetCompanyByName(string name);
        public Task<Company?> GetCompanyByNameAsync(string name);
        public Task<Company?> GetCompanyByUserAsync(User user);
        public Company? GetCompanyByUser(User user);
        #endregion
   
    }
}
