using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces
{
    public interface IExampleService
    {
        Task<List<Example>> FindAllAsync();

        Task<Example> GetExampleAsyncById(int id);

        void Add(Example example);

        void Update(Example example);

        void Delete(Example example);

        Task<bool> SaveChangesAsync();
    }
}
