using Domain.Models;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService
    {
        public User GetUser(string username)
        {
            var user = new User();
            try
            {
                using (var context = new Context())
                {
                    user = context.Users.Where(x => x.UserName == username).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }
        public async Task<User> GetUser(Guid userId)
        {
            var user = new User();
            try
            {
                using (var context = new Context())
                {
                    user = await context.Users.Where(x => x.Id == userId).SingleOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }
        public async Task<bool> CreateUser(User user)
        {
            bool userWasCreated = false;
            try
            {
                using (var context = new Context())
                {
                    await context.Users.AddAsync(user);
                    userWasCreated = await context.SaveChangesAsync() == 1;
                }
            }
            catch (Exception ex)
            {
                userWasCreated = false;
            }
            return userWasCreated;
        }

        public async Task<List<User>> GetUserByName(string contactName, Guid userSearching)
        {
            List<User> results = new List<User>();
            try
            {
                using (var context = new Context())
                {
                    results = await context.Users.Where(x => x.UserName.Contains(contactName) && x.Id != userSearching).ToListAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return results;
        }
    }
}
