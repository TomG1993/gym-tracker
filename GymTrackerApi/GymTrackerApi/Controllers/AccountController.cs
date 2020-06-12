/********************************************************************************************
* AccountController.cs
* Created on: 11/06/2020
* Created by: Tom Gorton
*******************************************************************************************/

namespace GymTrackerApi.Controllers
{
    using GymTrackerApi.Repository.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Defines the <see cref="AccountController" />.
    /// </summary>
    public class AccountController : Controller
    {

        /// <summary>
        /// Defines the userDetailRepository.
        /// </summary>
        private IUserDetailsRepository userDetailRepository;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<AccountController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="_userDetailRepository">The _userDetailRepository<see cref="IUserDetailsRepository"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{OverviewController}"/>.</param>
        public AccountController(IUserDetailsRepository _userDetailRepository, ILogger<AccountController> logger)
        {
            userDetailRepository = _userDetailRepository;
            _logger = logger;
        }

        [AllowAnonymous]
        public string Login(string returnUrl = "/")
        {
            return "Must log in";
        }
    }
}
