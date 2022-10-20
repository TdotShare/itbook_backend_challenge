using itbook_backend_challenge.Mapdata.Formactions;
using itbook_backend_challenge.Mapdata.Models;
using itbook_backend_challenge.Config;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Web.Helpers;

namespace itbook_backend_challenge.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public AuthenticationController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpPost("login")]
        public IActionResult ActionLogin([FromBody] LoginUser login_user)
        {
            try
            {
                var db = new LibraryContext();
                var user_data = db.User.Where(u => u.user_username == login_user.username).FirstOrDefault();

                if (user_data != null)
                {
                    if (Crypto.VerifyHashedPassword(user_data.user_password , login_user.password))
                    {
                        var user_token_data = jwtAuthenticationManager.Authenticate(user_data);
                        return Ok(user_token_data);
                    }
                    else
                    {
                        return BadRequest(new { Message = "password is incorrect" });
                    }
                }

                return BadRequest(new { Message = "Username is incorrect" });


            }
            catch(Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost("register")]
        public IActionResult ActionRegister([FromBody] RegisUser resgis_user)
        {
            /*
            if (resgis_user.GetType().GetProperties().Select(pi => pi.GetValue(resgis_user)).Any(value => value == null))
            {
                return BadRequest("request is incorrects");
            }
            */

            try
            {
                var db = new LibraryContext();

                var chk_user = db.User.Where(u => u.user_username == resgis_user.username).Count();

                if (chk_user > 0)
                {
                    return BadRequest(new { Message = $"This account name = {resgis_user.username} already in the system" });
                }

 
                var resgis_user_data = new User
                {
                   user_username = resgis_user.username,
                   user_password = Crypto.HashPassword(resgis_user.password),
                   user_fullname = resgis_user.fullname
                };

                db.User.Add(resgis_user_data);
                db.SaveChanges();

                return Ok(new { Message = $"create account name = {resgis_user.username}" } );

            }
            catch(Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
