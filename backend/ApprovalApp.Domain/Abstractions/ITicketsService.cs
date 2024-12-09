using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Abstractions
{
    public interface ITicketsService
    {
        Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> approvingInQueue);
    }
}
