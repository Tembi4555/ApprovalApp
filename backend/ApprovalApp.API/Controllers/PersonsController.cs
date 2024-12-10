using ApprovalApp.API.Contracts.Requests;
using ApprovalApp.API.Contracts.Responses;
using ApprovalApp.Data.Entities;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;

        /// <summary>
        /// Конструктор для Person
        /// </summary>
        /// <param name="personsService"></param>
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        /// <summary>
        /// Список персон
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PersonsResponse>>> GetPersonsAsync()
        {
            List<Person> persons = await _personsService.GetAllPersonsAsync();

            List<PersonsResponse> response = persons
                .Select(p => new PersonsResponse(p.Id, p.FullName, p.DateBirth))
                .ToList();
            
            return Ok(response);
        }

        /// <summary>
        /// Добавление персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<long>> CreatePersonAsync([FromBody] PersonsRequest request)
        {
            var (person, error) = Person.Create(
                id: 0, 
                fullName: request.FullName,
                dateBirth: request.BirthDate
                );

            if(!String.IsNullOrEmpty(error))
                return BadRequest(error);

            long personId = await _personsService.CreatePersonAsync(person);

            return Ok(personId);
        }

        /// <summary>
        /// Изменение персоны
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<long>> UpdatePersonAsync(long id, [FromBody] PersonsRequest request)
        {
            var (person, error) = Person.Create(id: id, fullName: request.FullName, dateBirth: request.BirthDate);

            long personId = await _personsService.UpdatePersonAsync(person);

            return Ok(personId);
        }
    }
}
