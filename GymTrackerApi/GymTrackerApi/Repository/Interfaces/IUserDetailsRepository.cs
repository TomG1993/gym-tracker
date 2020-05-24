using GymTrackerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Repository.Interfaces
{
    public interface IUserDetailsRepository
    {
        public Task<UserDetail > GetUserDetail(string Email);

        public Task<UserDetail> AddUser(UserDetail user);

        public Task<List<SessionHeader>> GetHeaders(int userId);

        public Task<List<SessionExercise>> GetSession(int headerId);

        public Task<int> AddSession(string sessionName, int userId);
    }
}
