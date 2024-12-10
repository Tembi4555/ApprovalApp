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

        public async Task<string> StopApprovalAsync(long ticketId, string? reasonStopping)
        {
            Ticket ticket = await GetTicketByIdAsync(ticketId);

            if (ticket == null) 
            { 
                return $"По идентификатору - {ticketId} не найдена заявка.";
            }

            if(ticket.TicketApprovals == null || ticket.TicketApprovals.Count() == 0)
            {
                return $"";
            }

            foreach(var ta in ticket.TicketApprovals)
            {
                ta.UpdateStatusAndComment(status: "Прекращено", comment: reasonStopping);
            }

            string statusOperation = await UpdateTicketWithTicketsApprovalAsync(ticket);

            if(statusOperation != "ok")
                return statusOperation;

            return "ok";
        }

        public async Task<Ticket> GetTicketByIdAsync(long ticketId)
        {
            Ticket ticket = await _ticketsRepository.GetTicketByIdAsync(ticketId);

            return ticket;
        }

        public async Task<string> UpdateTicketWithTicketsApprovalAsync(Ticket ticket)
        {
            long statusOperation = _ticketsRepository.UpdateTicket(ticket);

            if(statusOperation <= 0)
            {
                return "Произошла ошибка при сохранении данных.";
            }
            return "ok";
        }
    }
}
