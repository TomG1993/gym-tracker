using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerApi.Models.Responses
{
    public class UserResponseModel
    {
        public string Token { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
