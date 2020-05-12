/********************************************************************************************
* OverviewController.cs
* Created on: 12/05/2020
* Created by: Tom Gorton
*******************************************************************************************/
namespace GymTrackerApi.Controllers
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Repository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="OverviewController" />.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OverviewController : ControllerBase
    {
        /// <summary>
        /// Defines the userDetailRepository.
        /// </summary>
        private IUserDetailsRepository userDetailRepository;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<OverviewController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverviewController"/> class.
        /// </summary>
        /// <param name="_userDetailRepository">The _userDetailRepository<see cref="IUserDetailsRepository"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{OverviewController}"/>.</param>
        public OverviewController(IUserDetailsRepository _userDetailRepository, ILogger<OverviewController> logger)
        {
            userDetailRepository = _userDetailRepository;
            _logger = logger;
        }

        /// <summary>
        /// The Get user.
        /// </summary>
        /// <param name="Email">The Email<see cref="string"/>.</param>
        /// <returns>The <see cref="List{UserDetail}"/>.</returns>
        [HttpGet("/GetUserDetails")]
        public List<UserDetail> Get(string Email)
        {
            var users = new List<UserDetail>();
            users.Add(userDetailRepository.GetUserDetail(Email));
            return users;
        }

        /// <summary>
        /// The Post to create a new user.
        /// </summary>
        /// <param name="user">The user<see cref="UserDetail"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDetail}}"/>.</returns>
        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDetail>> PostUser([FromBody]UserDetail user)
        {
            if (user != null)
            {
                user = await this.userDetailRepository.AddUser(user);
            }


            return user;
        }

        /// <summary>
        /// The Get test.
        /// </summary>
        /// <param name="number">The number<see cref="int"/>.</param>
        /// <returns>The <see cref="IEnumerable{string}"/>.</returns>
        [HttpGet("/Test")]
        public IEnumerable<string> Get(int number)
        {
            var test = new List<string>();

            test.Add("This is a test");

            return test;
        }
    }
}
