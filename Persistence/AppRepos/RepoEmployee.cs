using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    // Change to class name
    public class RepoEmployee : IRepoPerson
    {

        private readonly AppDbContext _appDbContext;

        // Change to class name
        public RepoEmployee(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Change to class name
        public Person Create(Person employee)
        {
            // Change to class name
            var addedEntity = _appDbContext.Employees.Add((Employee)employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Person> List()
        {
            // Change to class name
            return _appDbContext.Managers;
        }

        public Person Detail(int pk)
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
        public Person Update(Person employee)
        {
            // Change to class name
            Employee newEmployee = (Employee)employee;
            // Change to class name
            var entityFound = _appDbContext.Employees.FirstOrDefault(p => p.PersonId == newEmployee.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = newEmployee.Name;
            entityFound.DateOfBirth = newEmployee.DateOfBirth;
            entityFound.Salary = newEmployee.Salary;
            entityFound.Manager = newEmployee.Manager;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
