using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IRepoManager
    {
        IEnumerable<Manager> List();
        Manager Create(Manager manager);
        Manager Update(Manager manager);
        bool Delete(int pk);
        Manager Detail(int pk);
    }
}
