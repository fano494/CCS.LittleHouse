using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Web.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersAppService _usersAppService;

        public HomeController(ILogger<HomeController> logger, IUsersAppService usersAppService)
        {
            _logger = logger;
            _usersAppService = usersAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName)
        {
            UserDTO user = _usersAppService.Login(userName);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName)
        {
            UserDTO user = await _usersAppService.Register(userName);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
