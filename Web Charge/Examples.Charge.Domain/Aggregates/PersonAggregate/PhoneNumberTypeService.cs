using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;

        }

        public async Task<List<PhoneNumberType>> FindAllAsync() => (await _phoneNumberTypeRepository.FindAllAsync()).ToList();

        public async Task<PhoneNumberType> GetPhoneNumberTypeAsyncById(int id) => (await _phoneNumberTypeRepository.GetPhoneNumberTypeAsyncById(id));

        public void Add(PhoneNumberType phoneNumberType)
        {
            _phoneNumberTypeRepository.Add(phoneNumberType);
        }

        public void Update(PhoneNumberType phoneNumberType)
        {
            _phoneNumberTypeRepository.Update(phoneNumberType);
        }

        public void Delete(PhoneNumberType phoneNumberType)
        {
            _phoneNumberTypeRepository.Delete(phoneNumberType);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _phoneNumberTypeRepository.SaveChangesAsync();
        }
    }
}