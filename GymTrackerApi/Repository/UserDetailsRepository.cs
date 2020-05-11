using GymTrackerApi.Models;
using GymTrackerApi.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly GymTrackerContext context;

        public UserDetailsRepository(GymTrackerContext context)
        {
            this.context = context;
        }

        public UserDetail GetUserDetail(string Email)
        {
            var user = context.UserDetails.FirstOrDefault(x => x.Email == Email);

            return user;
        }


        public async Task<UserDetail> AddUser(UserDetail user)
        {
            var result = context.UserDetails.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}