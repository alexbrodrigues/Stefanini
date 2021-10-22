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
    public class PhoneNumberTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _facade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeResponse>> GetAll()
        {
            try
            {
                var results = await _facade.FindAllAsync();

                return Ok(results.PhoneNumberTypeObjects);
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
                var results = await _facade.GetPhoneNumberTypeAsyncById(id);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PhoneNumberTypeDto model)
        {
            try
            {
                var person = _facade.AddPhoneNumberType(model);


                if (await _facade.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.PhoneNumberTypeID}", person);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PhoneNumberTypeDto model)
        {
            try
            {

                var person = await _facade.GetPhoneNumberTypeAsyncById(id);
                if (person == null) return NotFound();

                var personAtualizado = _facade.UpdatePhoneNumberType(person);

                if (await _facade.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.PhoneNumberTypeID}", personAtualizado);
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
                var person = await _facade.GetPhoneNumberTypeAsyncById(id);
                if (person == null) return NotFound();

                _facade.Delete(person);
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
