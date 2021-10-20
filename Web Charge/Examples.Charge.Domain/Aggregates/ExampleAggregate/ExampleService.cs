using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate
{
    public class ExampleService : IExampleService
    {
        private IExampleRepository _exampleRepository;
        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<List<Example>> FindAllAsync() => (await _exampleRepository.FindAllAsync()).ToList();

        public async Task<Example> GetExampleAsyncById(int id) => (await _exampleRepository.GetExampleAsyncById(id));

        public void Add(Example example)
        {
            _exampleRepository.Add(example);
        }

        public void Update(Example example)
        {
            _exampleRepository.Update(example);
        }

        public void Delete(Example example)
        {
            _exampleRepository.Delete(example);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _exampleRepository.SaveChangesAsync();
        }
    }
}
