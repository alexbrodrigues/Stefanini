using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneNumberTypeResponse> FindAllAsync();

        Task<PhoneNumberTypeDto> GetPhoneNumberTypeAsyncById(int id);

        PhoneNumberTypeDto AddPhoneNumberType(PhoneNumberTypeDto example);

        PhoneNumberTypeDto UpdatePhoneNumberType(PhoneNumberTypeDto example);

        void Delete(PhoneNumberTypeDto example);

        Task<bool> SaveChangesAsync();
    }
}
