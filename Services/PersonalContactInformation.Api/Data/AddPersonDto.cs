using PersonalContactInformation.Library.Models;

namespace PersonalContactInformation.Api.Data
{
    public class AddPersonDto
    {
        public IFormFile JsonFile { get; set; }
        public UpdateStrategy UpdateStrategy { get; set; }
    }
}