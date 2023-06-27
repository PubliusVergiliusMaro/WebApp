using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data.Entities;
using WebApp.EntityFramework;
using WebApp.EntityFramework.Repository;
using WebApp.Services.UserServices;
using WebApp.WebUI.Models;

namespace WebApp.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly IGenericRepository<UserEntity> _userRepository;
		private readonly IUserService _userService;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
            _logger = logger;
			_context = context;
			_userRepository = new GenericRepository<UserEntity>(_context);
			_userService = new UserService(_userRepository);
		}

		public IActionResult Index()
		{
            #region Generate 10 Test Users
            //for (int i = 0; i < 10; i++)
            //{
            //	_userService.Create(new UserEntity { Login=$"TestUser_{i}", Email = $"testemail{i}@gmail.com", Phone=$"3809442{i}" });
            //}
            #endregion

            IEnumerable<UserEntity> users = _userService.GetAll();
			return View(users);
		}

		// GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

		// POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(UserEntity user)
		{
			_userService.Create(user);
				return RedirectToAction("Index");
		}

        public IActionResult GetUserById(int userId)
        {
            var user = _userService.GetById(userId);

            if (user != null)
            {
                return Json(user);
            }
           
            return NotFound();
        }

        public IActionResult GetAllUsers()
        {
            IEnumerable<UserEntity> users = _userService.GetAll();

			if(users != null) 
			{
				return Json(users);
			}
            
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}