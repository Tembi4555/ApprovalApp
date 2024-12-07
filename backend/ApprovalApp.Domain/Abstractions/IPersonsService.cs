using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Abstractions
{
    public interface IPersonsService
    {
        Task<List<Person>> GetAllPersonsAsync();
        Task<long> CreatePersonAsync(Person personDto);
        Task<long> UpdatePersonAsync(Person personDto);
    }
}
