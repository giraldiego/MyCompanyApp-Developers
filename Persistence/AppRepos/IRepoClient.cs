using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IRepoClient
    {
        IEnumerable<Client> List(); // Update return type
        Client Create(Client client);   // Update return and parameter type
        Client Update(Client client);   // Update return and parameter type
        bool Delete(int pk);
        Client Detail(int pk);  // Update return type
    }
}
