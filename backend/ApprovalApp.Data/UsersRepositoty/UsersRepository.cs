using ApprovalApp.Data.Entities;
using ApprovalApp.Domain.Abstractions;
using ApprovalApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalApp.Data.UsersRepositoty
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApprovalDbContext _context;
        public UsersRepository( ApprovalDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string? login, string password)
        {
            UserEntity? userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == login!.ToLower() && String.Equals(password, u.Password));
            
            if (userEntity == null) 
            {
                return null;
            }

            User user = User.Create(id: userEntity.Id, userName: userEntity.UserName, personId: userEntity.PersonId).User;

            return user;
        }
    }
}
