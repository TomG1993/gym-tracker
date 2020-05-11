using GymTrackerApi.Models;
using GymTrackerApi.Repository;
using GymTrackerApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace GymTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OverviewController : ControllerBase
    {
        private IUserDetailsRepository userDetailRepository;

        private readonly ILogger<OverviewController> _logger;

        public OverviewController(IUserDetailsRepository _userDetailRepository, ILogger<OverviewController> logger)
        {
            userDetailRepository = _userDetailRepository;
            _logger = logger;

        }

#region UserFunctions
        [HttpGet("/GetUserDetails")]
        public List<UserDetail> Get(string Email)
        {
            var users = new List<UserDetail>();
            users.Add(userDetailRepository.GetUserDetail(Email));
            return users;
        }


        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDetail>> PostUser([FromBody]UserDetail user)
        {
            if (user != null)
            {
                user = await this.userDetailRepository.AddUser(user);
            }


            return user;

            // CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            // 
        }
        #endregion
        [HttpGet("/Test")]
        public IEnumerable<string> Get(int number)
        {
            var test = new List<string>();

            test.Add("This is a test");

            return test;
        }


    }
}