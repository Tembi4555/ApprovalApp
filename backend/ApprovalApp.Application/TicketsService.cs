using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Application
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public async Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> approvingInQueue)
        {
            long ticketId = await _ticketsRepository.CreateTicketAsync(ticket, approvingInQueue);

            return ticketId;
        }
    }
}
