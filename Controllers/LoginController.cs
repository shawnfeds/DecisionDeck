using AutoMapper;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RestSharp;

namespace DecisionDeck.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;

        public IUserRepository _repository { get; }

        public LoginController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Role");
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AuthenticateUser([FromBody] UserDTO user)
        {
            //var booking = _mapper.Map<Models.User>(user);

            var userExists = _repository.HasUser(user);

            var existingUser = _repository.GetUserbyUsernamePassword(user);

            if (userExists)
            {
                var cookie = HttpContext.Request.Cookies["Role"];

                if (cookie == null)
                {

                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(60), // Set expiration date to 7 days from now
                        Path = "/", // Cookie is available within the entire application
                        Secure = true, // Ensure the cookie is only sent over HTTPS
                        HttpOnly = false, // Prevent client-side scripts from accessing the cookie
                        IsEssential = true // Indicates the cookie is essential for the application to function
                    };

                    Response.Cookies.Append("Role", existingUser.Role.RoleName, options);
                }

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTO user)
        {
            var newUser = _mapper.Map<Models.User>(user);

            _repository.Add(newUser);
            
            return Json(new { success = true });
        }
    }
}
