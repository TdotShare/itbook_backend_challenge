using Microsoft.AspNetCore.Mvc;
using itbook_backend_challenge.Mapdata.Formactions;
using itbook_backend_challenge.Mapdata.Models;
using itbook_backend_challenge.Config;

namespace itbook_backend_challenge.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("user") ]
        public String Index()
        {
            return "test !";
        }

        [HttpPost("user/like")]
        public String ActionLikeBook([FromBody]LikeBookUser likebook_user)
        {

            try
            {
                var db = new LibraryContext();
                var likebook_user_data = new Favor
                {
                    favor_user_id = likebook_user.user_id,
                    favor_book_id = likebook_user.book_id,
                };

                db.Favor.Add(likebook_user_data);
                db.SaveChanges();

            }
            catch (Exception e)
            {

            }

            return "test !";
        }
    }
}
