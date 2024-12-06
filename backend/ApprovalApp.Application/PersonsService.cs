using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;

namespace ApprovalApp.Application
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonsPerository _personsPerository;
        public PersonsService( IPersonsPerository  personsPerository)
        {
            _personsPerository = personsPerository; 
        }

        public async Task<List<PersonDto>> GetAllPersonsAsync()
        {
            return await _personsPerository.GetAsync();
        }

        public async Task<long> CreatePersonAsync(PersonDto personDto)
        {
            return await _personsPerository.CreateAsync(personDto);
        }

        public async Task<long> UpdatePersonAsync(PersonDto personDto)
        {
            return await _personsPerository.UpdateAsync(personDto);
        }
    }
}
