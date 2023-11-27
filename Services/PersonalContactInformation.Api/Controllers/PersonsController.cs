using Microsoft.AspNetCore.Mvc;
using PersonalContactInformation.Api.Services;
using PersonalContactInformation.Library.Models;
using PersonalContactInformation.Library.Responses;

namespace PersonalContactInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Person>>> GetPersonsAsync() => Ok(await personService.GetPersonsAsync());

        [HttpGet("PersonById")]
        public async Task<ActionResult<Person>> GetPersonByIdAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound("Contact not found");
            }
            else
            {
                return Ok(person);
            }

        }

        [HttpDelete("DeletePerson")]
        public async Task<ActionResult<ServiceResponse>> DeletePersonAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound("Contact not found");
            }

            var response = await personService.DeletePersonAsync(person.Id);
            return Ok(response);
        }

        [HttpPut("UpdatePerson")]
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

        [HttpPost("AddPerson")]
        public async Task<ActionResult<ServiceResponse>> AddPersonAsync(Person person)
        {
            if (person == null)
            {
                return BadRequest("Bad request");
            }

            var result = await personService.AddPersonAsync(person);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

       [HttpPost("AddJson")]
        public async Task<ActionResult<ServiceResponse>> AddPersonJSONAsync(IFormFile jsonFile, [FromQuery] UpdateStrategy updateStrategy)
        {
            var x = jsonFile;
            if (jsonFile == null)
            {
                return BadRequest("Bad request");
            }
            var sr = new StreamReader(jsonFile.OpenReadStream());
            var jsonContent = sr.ReadToEnd();

            var result = await personService.AddPersonJSONAsync(jsonContent, updateStrategy);
            if (result.Success && result.Message == "Done, there were one or more duplicate contacts")
            {
                return Accepted();  // workaround since OK(result) didn't transfer result.message to the frontend
            }
            else if (result.Success && result.Message == "Done")
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
       }

        [HttpPost("AddTel")]
        public async Task<ActionResult<ServiceResponse>> AddTelefonnummerAsync(Person person, string newNumber)
        {
            if (person == null)
            {
                return BadRequest("Bad request");
            }
            else if (newNumber == null)
            {
                return BadRequest("No number found");
            }

            var result = await personService.AddTelefonnummerAsync(person, newNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateTel")]
        public async Task<ActionResult<ServiceResponse>> UpdateTelefonnummerAsync(Person person, string oldNumber, string newNumber)
        {
            var response = await personService.UpdateTelefonnummerAsync(person, oldNumber, newNumber);
            return Ok(response);
        }

        [HttpDelete("DeleteTel")]
        public async Task<ActionResult<ServiceResponse>> DeleteTelefonnummerAsync(Person person, string deleteNumber)
        {
            var response = await personService.DeleteTelefonnummerAsync(person, deleteNumber); 
            return Ok(response);
        }
    }
}
