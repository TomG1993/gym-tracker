using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTrackerApi.Models;
using GymTrackerApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private IExerciseRepository exerciseRepository;

        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(IExerciseRepository _exerciseRepository, ILogger<ExerciseController> logger)
        {
            exerciseRepository = _exerciseRepository;
            _logger = logger;

        }

        [HttpGet("/GetSessionHeader")]
        public SessionHeader Get(int userId)
        {
            var user = exerciseRepository.GetSessionHeader(userId);
            return user;
        }
    }
}