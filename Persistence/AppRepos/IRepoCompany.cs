using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IRepoCompany
    {
        IEnumerable<Company> List();
        Company Create(Company company);
        Company Update(Company company);
        bool Delete(int pk);
        Company Detail(int pk);
    }
}
