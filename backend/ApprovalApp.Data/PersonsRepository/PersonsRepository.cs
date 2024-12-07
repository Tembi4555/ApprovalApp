using ApprovalApp.Data.Entities;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Data.PersonsRepository
{
    public class PersonsRepository : IPersonsPerository
    {
        private readonly ApprovalDbContext _context;

        public PersonsRepository(ApprovalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAsync()
        {
            List<PersonEntity> persons = await _context.Persons.AsNoTracking().ToListAsync();

            // Mapping
            List<Person> personsDtos = persons.Select(p => Person.Create(p.Id, p.FullName, p.DateBirth).Person)
                .ToList();

            return personsDtos;
        }

        public async Task<long> CreateAsync(Person personDto)
        {
            PersonEntity person = new PersonEntity
            {
                Id = personDto.Id,
                FullName = personDto.FullName,
                DateBirth = personDto.DateBirth
            };

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return person.Id;
        }

        public async Task<long> UpdateAsync(Person personDto)
        {
            await _context.Persons
                .Where(p => p.Id == personDto.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.FullName, p => personDto.FullName)
                    .SetProperty(p => p.DateBirth, p => personDto.DateBirth));

            return personDto.Id;
        }
    }
}
