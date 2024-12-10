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
        Task<List<Person>> GetAsync();

        Task<long> CreateAsync(Person person);

        Task<long> UpdateAsync(Person person);
    }
}
