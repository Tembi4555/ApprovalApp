using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Models
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class User
    {
        private User( long id, string? userName, long personId) 
        {
            Id = id;
            UserName = userName;
            PersonId = personId;
        }

        public long Id { get; }
        public string? UserName { get; }
        public string? Password { get; }
        public long PersonId { get; }
        
        public static (User User, string Error) Create(long id, string? userName, long personId)
        {
            string error = string.Empty;

            User user = new User(id, userName, personId);

            return (user, error);
        }

    }
}
