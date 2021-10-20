using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeService
    {
        Task<List<PhoneNumberType>> FindAllAsync();

        Task<PhoneNumberType> GetPhoneNumberTypeAsyncById(int id);

        void Add(PhoneNumberType phoneNumberType);

        void Update(PhoneNumberType phoneNumberType);

        void Delete(PhoneNumberType phoneNumberType);

        Task<bool> SaveChangesAsync();
    }
}
