/********************************************************************************************
* ExerciseController.cs
* Created on: 12/05/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Controllers
{
    using GymTrackerApi.Models;
    using GymTrackerApi.Repository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Defines the <see cref="ExerciseController" />.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        /// <summary>
        /// Defines the exerciseRepository.
        /// </summary>
        private IExerciseRepository exerciseRepository;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<ExerciseController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseController"/> class.
        /// </summary>
        /// <param name="_exerciseRepository">The _exerciseRepository<see cref="IExerciseRepository"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{ExerciseController}"/>.</param>
        public ExerciseController(IExerciseRepository _exerciseRepository, ILogger<ExerciseController> logger)
        {
            exerciseRepository = _exerciseRepository;
            _logger = logger;
        }

        /// <summary>
        /// The Get session header.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="SessionHeader"/>.</returns>
        [HttpGet("/GetSessionHeader")]
        public SessionHeader Get(int userId)
        {
            var user = exerciseRepository.GetSessionHeader(userId);
            return user;
        }
    }
}
