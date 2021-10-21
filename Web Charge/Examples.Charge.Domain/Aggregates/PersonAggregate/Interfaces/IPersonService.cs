using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();

        Task<Person> GetPersonAsyncById(int id);

        void Add(Person person);

        void Update(Person person);

        void Delete(Person person);

        void DeleteRange(PersonPhone[] persons);

        Task<bool> SaveChangesAsync();
    }
}
