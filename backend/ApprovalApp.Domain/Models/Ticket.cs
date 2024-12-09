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
            long idAuthor)
        {
            Id = id;
            Title = title; 
            Description = description;
            CreateDate = createDate;
            IdAuthor = idAuthor;
        }

        public long Id { get; }

        public string? Title { get; }

        public string? Description { get; }

        public DateTime CreateDate { get; } 

        public long IdAuthor { get;  }


        public static (Ticket Ticket, string? Error) Create (long id, string? title, string? description, 
            long idAuthor)
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

            DateTime createDate = DateTime.Now;

            Ticket ticket = new Ticket(id, title, description, createDate, idAuthor);

            return (ticket,  error);
        }
    }
}
