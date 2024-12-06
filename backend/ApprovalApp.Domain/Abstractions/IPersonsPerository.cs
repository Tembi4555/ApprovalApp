using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Abstractions
{
    public interface IPersonsPerository
    {
        Task<List<PersonDto>> GetAsync();

        Task<long> CreateAsync(PersonDto personDto);

        Task<long> UpdateAsync(PersonDto personDto);
    }
}
