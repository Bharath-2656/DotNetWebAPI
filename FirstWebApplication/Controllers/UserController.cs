using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly UserDBContext _context;

        public UserController(UserDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("User/GetAllUsers")]
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [Route("User/GetName")]
        public string GetName(int Id)
        {
            var user = _context.Users.FirstOrDefault(m => m.Id == Id);
            if (user == null)
            {
                return "User not found";
            }
            return user.Name;
        }
        [Route("User/GetUserById/{Id}")]
        public IActionResult GetUserById(int Id)
        {
            User ?user = _context.Users.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return NotFound("No User found");
            }
            return Ok(user);

        }
        [HttpPost]
        [Route("User/PostUser")]
        public string PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return "User Added";

        }
    }
  

}
