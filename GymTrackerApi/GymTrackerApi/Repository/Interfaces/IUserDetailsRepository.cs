﻿using GymTrackerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Repository.Interfaces
{
    public interface IUserDetailsRepository
    {
        public UserDetail GetUserDetail(string Email);

        public Task<UserDetail> AddUser(UserDetail user);
    }
}