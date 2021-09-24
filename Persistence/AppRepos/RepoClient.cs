using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    // Change to class name
    public class RepoClient : IRepoPerson
    {

        private readonly AppDbContext _appDbContext;

        // Change to class name
        public RepoClient(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Change to class name
        public Person Create(Person client)
        {
            // Change to class name
            var addedEntity = _appDbContext.Clients.Add((Client)client);
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
            return _appDbContext.Clients.FirstOrDefault(p => p.PersonId == pk);
        }

        public bool Delete(int pk)
        {
            // Change to class name
            var entityFound = _appDbContext.Clients.FirstOrDefault(p => p.PersonId == pk);
            if (entityFound == null)
                return false;
            _appDbContext.Clients.Remove(entityFound);
            _appDbContext.SaveChanges();
            return true;
        }

        // Change to class name
        public Person Update(Person client)
        {
            // Change to class name
            Client newClient = (Client)client;
            // Change to class name
            var entityFound = _appDbContext.Clients.FirstOrDefault(p => p.PersonId == newClient.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = newClient.Name;
            entityFound.DateOfBirth = newClient.DateOfBirth;
            entityFound.PhoneNumber = newClient.PhoneNumber;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
