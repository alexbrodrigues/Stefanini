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
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeResponse> FindAllAsync()
        {
            var result = await _phoneNumberTypeService.FindAllAsync();
            var response = new PhoneNumberTypeResponse();
            response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));
            return response;
        }

        public async Task<PhoneNumberTypeDto> GetPhoneNumberTypeAsyncById(int id)
        {
            var result = await _phoneNumberTypeService.GetPhoneNumberTypeAsyncById(id);
            var response = _mapper.Map<PhoneNumberTypeDto>(result);
            return response;
        }

        public PhoneNumberTypeDto AddPhoneNumberType(PhoneNumberTypeDto example)
        {
            var response = _mapper.Map<PhoneNumberType>(example);
            _phoneNumberTypeService.Add(response);
            return _mapper.Map<PhoneNumberTypeDto>(response);
        }

        public PhoneNumberTypeDto UpdatePhoneNumberType(PhoneNumberTypeDto example)
        {
            var response = _mapper.Map<PhoneNumberType>(example);
            _phoneNumberTypeService.Update(response);
            return _mapper.Map<PhoneNumberTypeDto>(response);
        }

        public void Delete(PhoneNumberTypeDto example)
        {
            var response = _mapper.Map<PhoneNumberType>(example);
            _phoneNumberTypeService.Delete(response);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _phoneNumberTypeService.SaveChangesAsync();
        }
    }
}
