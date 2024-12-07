using ApprovalApp.Domain.Models;

namespace ApprovalApp.Data.Entities
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class TicketEntity
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public long IdAuthor { get; set; }

        public PersonEntity? Person { get; set; }

        public ICollection<TicketApprovalEntity> TicketApprovalEntities { get; set; } = new List<TicketApprovalEntity>();
        public ICollection<PersonEntity> Peoples { get; set; } = new List<PersonEntity>();


    }
}
