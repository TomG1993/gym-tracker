/********************************************************************************************
* UserDetailsRepository.cs
* Created on: 15/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Repository
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UserDetailsRepository" />.
    /// </summary>
    public class UserDetailsRepository : IUserDetailsRepository
    {
        /// <summary>
        /// Defines the context.
        /// </summary>
        private readonly GymTrackerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="GymTrackerContext"/>.</param>
        public UserDetailsRepository(GymTrackerContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The GetUserDetail.
        /// </summary>
        /// <param name="Email">The Email<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{UserDetail}"/>.</returns>
        public async Task<UserDetail> GetUserDetail(string Email)
        {
            var user = await context.UserDetails.FirstOrDefaultAsync(x => x.Email == Email);

            return user;
        }

        /// <summary>
        /// The AddUser.
        /// </summary>
        /// <param name="user">The user<see cref="UserDetail"/>.</param>
        /// <returns>The <see cref="Task{UserDetail}"/>.</returns>
        public async Task<UserDetail> AddUser(UserDetail user)
        {
            var result = context.UserDetails.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// The GetHeaders.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{List{SessionHeader}}"/>.</returns>
        public async Task<List<SessionHeader>> GetHeaders(int userId)
        {
            var headers = await context.SessionHeaders.Where(x => x.UserID == userId).ToListAsync();

            return headers;
        }
    }
}
