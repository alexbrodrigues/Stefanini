using System.Collections.Generic;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDto
    {
        public int BusinessEntityID { get; set; }

        public string Name { get; set; }

        public ICollection<PersonPhoneDto> Phones { get; set; }
    }
}
