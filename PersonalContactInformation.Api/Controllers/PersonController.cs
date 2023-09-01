using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PersonalContactInformation.Api.Services;
using PersonalContactInformation.Library.Models;
using PersonalContactInformation.Library.Responses;

namespace PersonalContactInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersonsAsync() => Ok(await personService.GetPersonsAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPersonByIdAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if(person == null)
            {
                return NotFound("Contact not found");
            } else
            {
                return Ok(person);
            }

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse>> DeletePersonAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if(person == null)
            {
                return NotFound("Contact not found");
            }

            var response = await personService.DeletePersonAsync(person.Id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse>> UpdatePersonAsync(Person person)
        {
            var result = await personService.GetPersonByIdAsync(person.Id);
            if (result == null)
            {
                return NotFound("Contact not found");
            }

            var response = await personService.UpdatePersonAsync(person);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddPersonAsync(Person person)
        {
            if(person == null)
            {
                return BadRequest("Bad request");
            }

            var result = await personService.AddPersonAsync(person);
            if(result.Success)
            {
                return Ok(result);
            } else
            {
                return BadRequest(result);
            }
        }
    }
}
