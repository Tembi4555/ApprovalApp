using ApprovalApp.API.Contracts.Requests;
using ApprovalApp.API.Contracts.Responses;
using ApprovalApp.Application;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        /// <summary>
        /// Контроллер для создания и обработки заявок
        /// </summary>
        /// <param name="ticketsService"></param>
        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        /// <summary>
        /// Добавление новой заявки
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<long>> CreateTicketAsync([FromBody] TicketsRequest request)
        {
            var (ticket, error) = Ticket.Create(
                id: 0,
                title: request.Title,
                description: request.Description,
                idAuthor: request.IdAuthor

            );

            if (!String.IsNullOrEmpty(error))
                return BadRequest(error);

            if (request.approvingInQueue.Count() == 0 || request.approvingInQueue == null)
            {
                return BadRequest("Не назначены согласующие заявку.");
            }

            long ticketId = await _ticketsService.CreateTicketAsync(ticket, request.approvingInQueue);

            return Ok(ticketId);
        }

        /// <summary>
        /// Прекращение заявки
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> StopApproval(long id, string? reason)
        {
            if (String.IsNullOrEmpty(reason))
                return BadRequest("Требуется указать причину прекращения согласования заявки.");

            string statusOperation = await _ticketsService.StopApprovalAsync(id, reason);

            if(statusOperation != "ok")
                return BadRequest(statusOperation);

            return Ok();

        }

        /// <summary>
        /// Получение заявки по идентификатору
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketByIdAsync(long id)
        {
            Ticket ticket = await _ticketsService.GetTicketByIdAsync(id);

            if (ticket == null)
                return BadRequest($"Не удалось найти заявку по идентфикатору {id}");

            TicketsResponse response = new TicketsResponse (ticket.Id, ticket.Title, ticket.Description, ticket.IdAuthor);

            return Ok(response);
        }
    }
}
