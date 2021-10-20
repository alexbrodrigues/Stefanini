using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class ExampleFacade : IExampleFacade
    {
        private IExampleService _exampleService;
        private IMapper _mapper;

        public ExampleFacade(IExampleService exampleService, IMapper mapper)
        {
            _exampleService = exampleService;
            _mapper = mapper;
        }

        public async Task<ExampleListResponse> FindAllAsync()
        {
            var result = await _exampleService.FindAllAsync();
            var response = new ExampleListResponse();
            response.ExampleObjects = new List<ExampleDto>();
            response.ExampleObjects.AddRange(result.Select(x => _mapper.Map<ExampleDto>(x)));
            return response;
        }

        public async Task<ExampleDto> GetExampleAsyncById(int id)
        {
            var result = await _exampleService.GetExampleAsyncById(id);
            var response = _mapper.Map<ExampleDto>(result);
            return response;
        }

        public ExampleDto AddExample(ExampleDto example)
        {
            var response = _mapper.Map<Example>(example);
            _exampleService.Add(response);
            return _mapper.Map<ExampleDto>(response);
        }

        public ExampleDto UpdateExample(ExampleDto example)
        {
            var response = _mapper.Map<Example>(example);
            _exampleService.Update(response);
            return _mapper.Map<ExampleDto>(response);
        }

        public void Delete(ExampleDto example)
        {
            var response = _mapper.Map<Example>(example);
            _exampleService.Delete(response);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _exampleService.SaveChangesAsync();
        }
    }
}
