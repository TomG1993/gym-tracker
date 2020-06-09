/********************************************************************************************
* OverviewController.cs
* Created on: 12/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Controllers
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Models.Requests;
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
        public async Task<List<UserDetail>> Get(string Email)
        {
            var users = new List<UserDetail>();
            var user = await userDetailRepository.GetUserDetail(Email);
            users.Add(user);
            return users;
        }

        /// <summary>
        /// The Post to create a new user.
        /// </summary>
        /// <param name="user">The user<see cref="UserDetail"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDetail}}"/>.</returns>
        [HttpPost("/AddUser")]
        public async Task<ActionResult<UserDetail>> PostUser([FromBody]UserDetail user)
        {
            if (user != null)
            {
                user = await this.userDetailRepository.AddUser(user);
            }


            return user;
        }

        /// <summary>
        /// The Post Login.
        /// </summary>
        /// <param name="request">The request containing an email and a password<see cref="LoginRequest"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDetail}}"/>.</returns>
        [HttpPost("/Login")]
        public async Task<ActionResult<UserDetail>> PostLogin([FromBody]LoginRequest request)
        {
            var user = await this.userDetailRepository.GetUserDetail(request.Email);

            if (user.Email == request.Email)
            {
                if (request.Password == user.Password)
                {
                    return user;
                }

                return new UserDetail() { ID = 0, Name = "Incorrect password" };
            }

            return null;
        }

        /// <summary>
        /// The GetSessions.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{List{SessionHeader}}}"/>.</returns>
        [HttpGet("/GetHeaders")]
        public async Task<ActionResult<List<SessionHeader>>> GetHeaders(int userId)
        {
            if (userId > 0)
            {
                var headers = await this.userDetailRepository.GetHeaders(userId);

                return headers;
            }

            return new List<SessionHeader>();
        }

        /// <summary>
        /// The GetSession.
        /// </summary>
        /// <param name="headerId">The headerId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{List{SessionExercise}}}"/>.</returns>
        [HttpGet("/GetSession")]
        public async Task<ActionResult<List<SessionExercise>>> GetSession(int headerId)
        {
            if (headerId > 0)
            {
                var headers = await this.userDetailRepository.GetSession(headerId);

                return headers;
            }

            return new List<SessionExercise>();
        }

        /// <summary>
        /// The PostAddSession.
        /// </summary>
        /// <param name="request">The request<see cref="AddSessionRequest"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{int}}"/>.</returns>
        [HttpPost("/AddSessionHeader")]
        public async Task<ActionResult<int>> PostAddSession([FromBody]AddSessionRequest request)
        {
            var sessionId = await this.userDetailRepository.AddSession(request.SessionName, request.UserId);

            return sessionId;
        }

        /// <summary>
        /// The PostAddSession.
        /// </summary>
        /// <param name="request">The request<see cref="AddSessionRequest"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{int}}"/>.</returns>
        [HttpPost("/AddSessionExercise")]
        public async Task<ActionResult<int>> PostAddSessionExercise([FromBody]AddSessionExerciseRequest request)
        {
            // GetExercise(string exerciseName)
            // Check if exercise already exists
            var exercise = await this.userDetailRepository.GetExercise(request.ExerciseName);

            // If not create new record of the exercise
            if (exercise == null)
            {
                exercise = await this.userDetailRepository.AddExercise(request.ExerciseName);
            }

            // Save the session exercise
            // .AddSessionExercise
            var sessionId = await this.userDetailRepository.AddSessionExercise(request.SessionHeaderId, exercise.Id);

            return sessionId;
        }
        /// <summary>
        /// The Get session exercise end point
        /// </summary>
        /// <param name="sessionHeaderId"></param>
        /// <returns></returns>
        public async Task<ActionResult<List<SessionExercise>>> GetSessionExercises(int sessionHeaderId)
        { 
            var sessionExercises = await this.userDetailRepository.GetSessionExercises(sessionHeaderId);

            return sessionExercises;
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
