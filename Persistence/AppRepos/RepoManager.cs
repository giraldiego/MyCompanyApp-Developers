using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class RepoManager : IRepoManager
    {

        private readonly AppDbContext _appDbContext;

        public RepoManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Manager Create(Manager manager)
        {
            var addedEntity = _appDbContext.Managers.Add((Manager)manager);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Manager> List()
        {
            return _appDbContext.Managers;
        }

        public Manager Detail(int pk)
        {
            return _appDbContext.Managers.FirstOrDefault(p => p.PersonId == pk);
        }

        public bool Delete(int pk)
        {
            var entityFound = _appDbContext.Managers.FirstOrDefault(p => p.PersonId == pk);
            if (entityFound == null)
                return false;
            _appDbContext.Managers.Remove(entityFound);
            _appDbContext.SaveChanges();
            return true;
        }

        public Manager Update(Manager manager)
        {
            Manager newManager = (Manager)manager;
            var entityFound = _appDbContext.Managers.FirstOrDefault(p => p.PersonId == newManager.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = newManager.Name;
            entityFound.DateOfBirth = newManager.DateOfBirth;
            entityFound.Salary = newManager.Salary;
            entityFound.Manager = newManager.Manager;
            entityFound.Category = newManager.Category;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
