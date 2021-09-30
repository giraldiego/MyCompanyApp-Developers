using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    // Change to class name
    public class RepoClient : IRepoClient
    {

        private readonly AppDbContext _appDbContext;

        // Change to class name
        public RepoClient(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Change to class name
        public Client Create(Client client)
        {
            // Change to class name
            var addedEntity = _appDbContext.Clients.Add((Client)client);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Client> List()
        {
            // Change to class name
            return _appDbContext.Clients;
        }

        public Client Detail(int pk)
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
        public Client Update(Client client)
        {
            // Change to class name
            var entityFound = _appDbContext.Clients.FirstOrDefault(p => p.PersonId == client.PersonId);
            if (entityFound == null)
                return null;

            entityFound.Name = client.Name;
            entityFound.DateOfBirth = client.DateOfBirth;
            entityFound.PhoneNumber = client.PhoneNumber;
            _appDbContext.SaveChanges();
            return entityFound;
        }
    }
}
