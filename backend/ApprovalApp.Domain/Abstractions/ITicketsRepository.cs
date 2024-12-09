using ApprovalApp.Domain.Models;

namespace ApprovalApp.Domain.Abstractions
{
    public interface ITicketsRepository
    {
        Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> authorsInQueue);
    }
}