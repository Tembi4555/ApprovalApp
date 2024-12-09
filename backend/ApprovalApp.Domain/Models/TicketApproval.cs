namespace ApprovalApp.Domain.Models
{
    /// <summary>
    /// Согласованты
    /// </summary>
    public class TicketApproval
    {
        public TicketApproval(long id, long ticketId, long approvingPersonId, string status,
            int iteration, int numberQueue, DateTime modifiedDate, string coment,
            Ticket? ticket = null, Person? person = null)
        {
            Id = id;
            TicketId = ticketId;
            ApprovingPersonId = approvingPersonId;
            Status = status;
            Iteration = iteration;
            NumberQueue = numberQueue;
            ModifiedDate = modifiedDate;
            Comment = coment;
            Ticket = ticket;
            Person = person;
        }

        public long Id { get; }
        public long TicketId { get; }
        public Ticket? Ticket { get;  }
        public long ApprovingPersonId { get; }
        public Person? Person { get; }
        public string? Status { get; }
        public int Iteration { get; set; }
        public int NumberQueue { get; }
        public DateTime ModifiedDate { get; }
        public string? Comment { get; }

        public static(TicketApproval TicketApproval, string Error) Create (long id, long ticketId, 
            long approvingPersonId, StatusApproval statusEnum, int iteration, 
            int numberQueue, string coment, Ticket? ticket = null, Person? person = null)
        {
            string error = String.Empty;
            string status = String.Empty;

            switch (statusEnum) 
            {
                case StatusApproval.New:
                    status = "Новая";
                    break;

                case StatusApproval.Rejected:
                    status = "Отклонено";
                    break;

                case StatusApproval.Agreed:
                    status = "Согласовано";
                    break;

                case StatusApproval.Discontinued:
                    status = "Прекращено";
                    break;

                default:
                    error = "Заявке не назачен статус";
                    break;
            }

            if(iteration <= 0)
            {
                error += " Неверно задана итерация согласования.";
            }

            if (numberQueue <= 0)
            {
                error += " Неверно задан номер очереди.";
            }

            if((statusEnum == StatusApproval.Rejected || statusEnum == StatusApproval.Discontinued)
                && String.IsNullOrEmpty(coment))
            {
                error += " Требуется задать комментарий к статусу.";
            }

            TicketApproval ta = new TicketApproval(id, ticketId, approvingPersonId, status,
                iteration, numberQueue, DateTime.Now, coment, ticket, person);

            return (ta, error);
        }
    }

    public enum StatusApproval
    {
        New, //Новая
        Rejected, //Отклонено
        Agreed, //Согласовано 
        Discontinued //Прекращено
    }
}