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
        Task<List<PersonDto>> GetAllPersonsAsync();
        Task<long> CreatePersonAsync(PersonDto personDto);
        Task<long> UpdatePersonAsync(PersonDto personDto);
    }
}
