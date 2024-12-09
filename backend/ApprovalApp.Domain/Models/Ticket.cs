using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Models
{
    /// <summary>
    /// Заявкм
    /// </summary>
    public class Ticket
    {
        private Ticket(long id, string? title, string? description, DateTime createDate, 
            long idAuthor, Person? person = null, List<TicketApproval>? ticketApprovals = null,
            List<Person>? peoples = null)
        {
            Id = id;
            Title = title; 
            Description = description;
            CreateDate = createDate;
            IdAuthor = idAuthor;
            Person = person;
            TicketApprovals = ticketApprovals;
            Peoples = peoples;
        }

        public long Id { get; }

        public string? Title { get; }

        public string? Description { get; }

        public DateTime CreateDate { get; } 

        public long IdAuthor { get;  }

        public Person? Person { get; }

        public List<TicketApproval>? TicketApprovals { get; }

        public List<Person>? Peoples { get; }

        public static (Ticket Ticket, string? Error) Create (long id, string? title, string? description, 
            long idAuthor, Person? person=null, List<TicketApproval>? ticketApprovals = null,
            List<Person>? peoples = null)
        {
            string error = string.Empty;

            if (String.IsNullOrEmpty(title))
            {
                error = "Тема заявки не должна быть заполнена.";
            }

            if(String.IsNullOrEmpty(description))
            {
                if (!String.IsNullOrEmpty(error))
                    error += "\nОписание заявки должно быть заполнено.";
                else
                    error = "Описание заявки должно быть заполнено.";
            }

            if(idAuthor <= 0)
            {
                if (!String.IsNullOrEmpty(error))
                    error += "\nВ заявке не указан автор.";
                else
                    error = "В заявке не указан автор.";
            }

            if(ticketApprovals == null)
                ticketApprovals = new List<TicketApproval>();

            if(peoples == null)
                peoples = new List<Person>();

            DateTime createDate = DateTime.Now;

            Ticket ticket = new Ticket(id, title, description, createDate, idAuthor, person,
                ticketApprovals, peoples);

            return (ticket,  error);
        }
    }
}
