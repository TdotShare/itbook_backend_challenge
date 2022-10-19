using Microsoft.AspNetCore.Mvc;

namespace itbook_backend_challenge.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("user") ]
        public String Index()
        {
            return "test !";
        }
    }
}
