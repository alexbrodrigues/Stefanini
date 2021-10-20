using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();

        Task<PersonDto> GetPersonAsyncById(int id);

        PersonDto AddPerson(PersonDto example);

        PersonDto UpdatePerson(PersonDto example);

        void Delete(PersonDto example);

        Task<bool> SaveChangesAsync();
    }
}