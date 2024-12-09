using ApprovalApp.API.Contracts.Requests;
using ApprovalApp.Application;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
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
        /// Добавление персоны
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<long>> CreateTicketAsync([FromBody] TicketsRequest request
            /*Dictionary<long, int> approvingInQueue*/)
        {
            var approvingInQueue = new Dictionary<long, int>();
            var (ticket, error) = Ticket.Create(
                id: 0,
                title: request.Title,
                description: request.Description,
                idAuthor: request.IdAuthor
                
            );
            

            if (!String.IsNullOrEmpty(error))
                return BadRequest(error);

            if(approvingInQueue.Count()==0 || approvingInQueue == null)
            {
                return BadRequest("Не назначены согласующие заявку.");
            }

            long ticketId = await _ticketsService.CreateTicketAsync(ticket, approvingInQueue);

            return Ok(ticketId);
        }
    }
}
