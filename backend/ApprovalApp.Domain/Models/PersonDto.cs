using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Domain.Models
{
    public class PersonDto
    {
        private PersonDto(long id, string? fullName, DateTime dateBirth)
        {
            Id = id;
            FullName = fullName;
            DateBirth = dateBirth;
        }

        public long Id { get; }

        public string? FullName { get; }
        public DateTime DateBirth { get; }

        public static (PersonDto PersonDto, string Error) Create(long id, string? fullName, DateTime dateBirth)
        {
            string error = string.Empty;    
            if(String.IsNullOrEmpty(fullName))
            {
                error = "Имя сотрудника не должно быть пустым";
            }

            PersonDto person = new PersonDto(id, fullName, dateBirth);

            return (person, error);
        }
    }
}
