
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IExampleFacade
    {
        Task<ExampleListResponse> FindAllAsync();

        Task<ExampleDto> GetExampleAsyncById(int id);

        ExampleDto AddExample(ExampleDto example);

        ExampleDto UpdateExample(ExampleDto example);

        void Delete(ExampleDto example);

        Task<bool> SaveChangesAsync();
    }
}
