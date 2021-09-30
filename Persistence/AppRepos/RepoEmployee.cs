using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    // Change to class name
    public class RepoEmployee : IRepoEmployee
    {

        private readonly AppDbContext _appDbContext;

        // Change to class name
        public RepoEmployee(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Change to class name
        public Employee Create(Employee employee)
        {
            // Change to class name
            var addedEntity = _appDbContext.Employees.Add((Employee)employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Employee> List()
        {
            // Change to class name
            return _appDbContext.Employees;
        }

        public Employee Detail(int pk)
        {
            // Change to class name
            return _appDbContext.Employees.FirstOrDefault(p => p.PersonId == pk);
        }

        public bool Delete(int pk)
        {
            // Change to class name
            var entityFound = _appDbContext.Employees.FirstOrDefault(p => p.PersonId == pk);
            if (entityFound == null)
                return false;
            _appDbContext.Employees.Remove(entityFound);
            _appDbContext.SaveChanges();
            return true;
        }

        // Change to class name
        public Employee Update(Employee employee)
        {
            // Change to class name
            var entityFound = _appDbContext.Employees.FirstOrDefault(p => p.PersonId == employee.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = employee.Name;
            entityFound.DateOfBirth = employee.DateOfBirth;
            entityFound.Salary = employee.Salary;
            entityFound.Manager = employee.Manager;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
