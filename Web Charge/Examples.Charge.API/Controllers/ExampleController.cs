using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {
        private IExampleFacade _facade;

        public ExampleController(IExampleFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<ExampleListResponse>> GetAll()
        {
            try
            {
                var results = await _facade.FindAllAsync();

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _facade.GetExampleAsyncById(id);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ExampleDto model)
        {
            try
            {
                var example = _facade.AddExample(model);


                if (await _facade.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", example);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ExampleDto model)
        {
            try
            {

                var example = await _facade.GetExampleAsyncById(id);
                if (example == null) return NotFound();

                var exampleAtualizado = _facade.UpdateExample(example);

                if (await _facade.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", exampleAtualizado);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var example = await _facade.GetExampleAsyncById(id);
                if (example == null) return NotFound();

                _facade.Delete(example);
                if (await _facade.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou: {ex.Message}");
            }
            return BadRequest();
        }
    }
}
