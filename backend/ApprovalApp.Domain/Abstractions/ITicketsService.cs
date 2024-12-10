﻿using ApprovalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Abstractions
{
    public interface ITicketsService
    {
        /// <summary>
        /// Создание заявки.
        /// </summary>
        Task<long> CreateTicketAsync(Ticket ticket, Dictionary<long, int> approvingInQueue);

        /// <summary>
        /// Прекращение согласования заявки.
        /// </summary>
        Task<string> StopApprovalAsync(long ticketId, string? reasonStopping);

        /// <summary>
        /// Получить заявку по идентификатору
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        Task<Ticket> GetTicketByIdAsync(long ticketId);
    }
}
