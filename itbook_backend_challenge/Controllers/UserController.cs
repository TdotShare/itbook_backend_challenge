using Microsoft.AspNetCore.Mvc;
using itbook_backend_challenge.Mapdata.Formactions;
using itbook_backend_challenge.Mapdata.Models;
using itbook_backend_challenge.Config;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Net.Http.Headers;

namespace itbook_backend_challenge.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("user") , Authorize]
        public IActionResult Index()
        {

            try
            {
                var db = new LibraryContext();
                var user_data = db.User.Select(user => new
                {
                    user_id = user.user_id,
                    user_username = user.user_username,
                    user_fullname = user.user_fullname,
                    favorList = db.Favor.Where(favor => favor.favor_user_id == user.user_id).ToList()
                }
                ).ToList();

                return Ok(user_data);
            }catch(Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }

        }

        [HttpGet("user/getme") , Authorize]
        public IActionResult ActionMe()
        {
            //var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var username =  new { 
              username = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value
            };

            return Ok(username);
        }

        [HttpPost("user/like") , Authorize]
        public IActionResult ActionLikeBook([FromBody]LikeBookUser likebook_user)
        {

            try
            {


                using var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.itbook.store/1.0/books/{likebook_user.book_id}");
                var response = httpClient.Send(request);

                if (response.StatusCode.ToString() != "OK")
                {
                    return BadRequest(new { Message = "Not Found Data !" });
                }

                var db = new LibraryContext();

                var likebook_user_data = new Favor
                {
                    favor_user_id = likebook_user.user_id,
                    favor_book_id = likebook_user.book_id,
                };

                db.Favor.Add(likebook_user_data);
                db.SaveChanges();

                return Ok(new { Message = "LinkBook !" });

            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
