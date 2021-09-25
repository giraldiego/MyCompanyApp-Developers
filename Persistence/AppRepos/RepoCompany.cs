using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class RepoCompany : IRepoCompany
    {

        private readonly AppDbContext _appDbContext;

        public RepoCompany(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Company Create(Company company)
        {
            var addedEntity = _appDbContext.Companies.Add(company);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Company> List()
        {
            return _appDbContext.Companies;
        }

        public Company Detail(int pk)
        {
            return _appDbContext.Companies.FirstOrDefault(p => p.CompanyId == pk);
        }

        public bool Delete(int pk)
        {
            var entityFound = _appDbContext.Companies.FirstOrDefault(p => p.CompanyId == pk);
            if (entityFound == null)
                return false;
            _appDbContext.Companies.Remove(entityFound);
            _appDbContext.SaveChanges();
            return true;
        }

        public Company Update(Company company)
        {
            var entityFound = _appDbContext.Companies.FirstOrDefault(p => p.CompanyId == company.CompanyId);
            if (entityFound == null)
                return null;

            entityFound.Name = company.Name;
            entityFound.Address = company.Address;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
