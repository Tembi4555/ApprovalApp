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
        /// Получение заявки по ID из БД.
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        Task<Ticket> GetTicketByIdAsync(long ticketId);

        /// <summary>
        /// Обновить заявку.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        long UpdateTicket(Ticket ticket);
    }
}