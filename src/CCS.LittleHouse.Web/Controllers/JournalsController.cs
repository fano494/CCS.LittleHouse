using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Interfaces.Journals;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Web.Models.Journals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CCS.LittleHouse.Web.Controllers
{
    public class JournalsController : Controller
    {
        private readonly ILogger<JournalsController> _logger;
        private readonly IJournalsAppService _journalsAppService;
        private readonly IUsersAppService _usersAppService;

        public JournalsController(ILogger<JournalsController> logger
            , IJournalsAppService journalsAppService
            , IUsersAppService usersAppService)
        {
            _logger = logger;
            _journalsAppService = journalsAppService;
            _usersAppService = usersAppService;
        }

        [Route("[controller]/[action]/{userId}")]
        public IActionResult Index(Guid userId)
        {
            UserDTO user = _usersAppService.GetById(userId);
            IEnumerable<JournalDTO> journals = _journalsAppService.GetJournalsByUser(userId);
            return View(IndexViewModel.Create(user, journals));
        }

        [Route("[controller]/[action]/{userId}")]
        public IActionResult Create(Guid userId)
        {
            UserDTO user = _usersAppService.GetById(userId);
            return View(CreateViewModel.Create(user));
        }
    }
}
