using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();

        Task<PersonDto> GetPersonAsyncById(int id);

        PersonDto AddPerson(PersonDto personDto);

        Task<PersonDto> UpdatePerson(int id, PersonDto personDto);

        void Delete(PersonDto personDto);

        Task<bool> SaveChangesAsync();
    }
}