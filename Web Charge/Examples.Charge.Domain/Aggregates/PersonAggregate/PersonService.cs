using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> GetPersonAsyncById(int id) => (await _personRepository.GetPersonAsyncById(id));

        public void Add(Person person)
        {
            _personRepository.Add(person);
        }

        public void Update(Person person)
        {
            _personRepository.Update(person);
        }

        public void Delete(Person person)
        {
            _personRepository.Delete(person);
        }

        public void DeleteRange(PersonPhone[] persons)
        {
            _personRepository.DeleteRange(persons);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _personRepository.SaveChangesAsync();
        }
    }
}
