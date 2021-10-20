using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonDto> GetPersonAsyncById(int id)
        {
            var result = await _personService.GetPersonAsyncById(id);
            var response = _mapper.Map<PersonDto>(result);
            return response;
        }

        public PersonDto AddPerson(PersonDto example)
        {
            var response = _mapper.Map<Person>(example);
            _personService.Add(response);
            return _mapper.Map<PersonDto>(response);
        }

        public PersonDto UpdatePerson(PersonDto example)
        {
            var response = _mapper.Map<Person>(example);
            _personService.Update(response);
            return _mapper.Map<PersonDto>(response);
        }

        public void Delete(PersonDto example)
        {
            var response = _mapper.Map<Person>(example);
            _personService.Delete(response);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _personService.SaveChangesAsync();
        }
    }
}
