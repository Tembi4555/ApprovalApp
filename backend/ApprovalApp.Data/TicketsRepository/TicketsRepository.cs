using ApprovalApp.Data.Entities;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Data.TicketsRepository
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly ApprovalDbContext _context;

        public TicketsRepository(ApprovalDbContext context)
        {
            _context = context;
        }

        public async Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> approvingInQueue)
        {
            if (approvingInQueue.Count() == 0)
            {
                throw new ArgumentException("Не указан ни один адресат заявки");
            }

            if (ticket.IdAuthor <= 0)
            {
                throw new ArgumentException("Не указан автор заявки");
            }

            TicketEntity te = new TicketEntity
            {
                Id = ticket.Id,
                IdAuthor = ticket.IdAuthor,
                Title = ticket.Title,
                Description = ticket.Description
            };

            foreach (var author in approvingInQueue)
            {
                TicketApprovalEntity tae = new TicketApprovalEntity
                {
                    TicketId = ticket.Id,
                    ApprovingPersonId = author.Key,
                    Status = "Новая",
                    Iteration = 1,
                    NumberQueue = author.Value
                };

                te.TicketApprovalEntities.Add(tae);
            }

            await _context.Tickets.AddAsync(te);
            await _context.SaveChangesAsync();

            return te.Id;
        }
    }
}
