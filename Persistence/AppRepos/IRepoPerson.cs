using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IRepoPerson
    {
        IEnumerable<Person> List();
        Person Create(Person person);
        Person Update(Person person);
        bool Delete(int pk);
        Person Detail(int pk);
    }
}
