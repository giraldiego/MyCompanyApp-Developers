using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class RepoPerson : IRepoPerson
    {

        private readonly AppDbContext _appDbContext;

        public RepoPerson(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Person Create(Person person)
        {
            var addedEntity = _appDbContext.Persons.Add(person);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Person> List()
        {
            return _appDbContext.Persons;
        }

        public Person Detail(int pk)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonId == pk);
        }

        public bool Delete(int pk)
        {
            var entityFound = _appDbContext.Persons.FirstOrDefault(p => p.PersonId == pk);
            if (entityFound == null)
                return false;
            _appDbContext.Persons.Remove(entityFound);
            _appDbContext.SaveChanges();
            return true;
        }

        public Person Update(Person person)
        {
            var entityFound = _appDbContext.Persons.FirstOrDefault(p => p.PersonId == person.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = person.Name;
            entityFound.DateOfBirth = person.DateOfBirth;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
