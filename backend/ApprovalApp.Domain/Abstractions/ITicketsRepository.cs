using ApprovalApp.Domain.Models;

namespace ApprovalApp.Domain.Abstractions
{
    public interface ITicketsRepository
    {
        /// <summary>
        /// Создание заявки в БД.
        /// </summary>
        Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> authorsInQueue);

        /// <summary>
        /// Получить задачу на согласование по id автора и id задачи.
        /// </summary>
        Task<TicketApproval> GetTicketApprovalByIdTicketAndApproving(long idTicket, long idApproving);

        /// <summary>
        /// Получение заявки по ID из БД.
        /// </summary>
        Task<Ticket> GetTicketByIdAsync(long ticketId);

        /// <summary>
        /// Обновить заявку.
        /// </summary>
        Task<long> UpdateTicket(Ticket ticket);
    }
}