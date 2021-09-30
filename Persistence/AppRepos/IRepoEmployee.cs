using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IRepoEmployee
    {
        IEnumerable<Employee> List();
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        bool Delete(int pk);
        Employee Detail(int pk);
    }
}
