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

        public PersonDto AddPerson(PersonDto personDto)
        {
            var response = _mapper.Map<Person>(personDto);
            _personService.Add(response);
            return _mapper.Map<PersonDto>(response);
        }

        public async Task<PersonDto> UpdatePerson(int id, PersonDto personDto)
        {
            var person = new Person();

            person = await _personService.GetPersonAsyncById(id);

            var personRetorno = _mapper.Map<PersonDto>(person);
            if (personRetorno != null)
            {
                var idPersonPhones = new List<int>();

                if (personDto.Phones != null)
                {
                    foreach (var phones in personDto.Phones)
                    {
                        idPersonPhones.Add(phones.BusinessEntityID);
                    }
                }


                var personPhones = person.Phones.Where(
                    phone => !idPersonPhones.Contains(phone.BusinessEntityID)
                ).ToArray();

                if (personPhones.Length > 0) _personService.DeleteRange(personPhones);

                _mapper.Map(personDto, person);

                _personService.Update(person);

                return personRetorno;
            }

            return personRetorno;
        }

        public void Delete(PersonDto personDto)
        {
            var response = _mapper.Map<Person>(personDto);
            _personService.Delete(response);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _personService.SaveChangesAsync();
        }
    }
}
