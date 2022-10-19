using Microsoft.AspNetCore.Mvc;
using itbook_backend_challenge.Mapdata.Responses;

namespace itbook_backend_challenge.Controllers
{
    public class BookController : Controller
    {

        [HttpGet("books")]
        [HttpGet("books/{page?}" , Name = "book_page")]
        public async Task<Itbook> ActionBookList(int? page = 0)
        {
            using var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, page == 0 ? $"https://api.itbook.store/1.0/search/mysql" : $"https://api.itbook.store/1.0/search/mysql?page={page}");
            var response = httpClient.Send(request);

            var Itbook_data = await response.Content.ReadFromJsonAsync<Itbook>();

            int next_page = (int)(page != 0 ? Itbook_data.page + 1 : 2);
            int previous_page = (int)(page == 0 ? 0 : Itbook_data.page - 1);
            string url_book_page = $"{Request.Scheme}://{Request.Host}/books";

            Itbook_data.next_page = $"{url_book_page}?page={next_page}";
            Itbook_data.previous_page = previous_page == 0 ? "" : $"{url_book_page}?page={previous_page}";

            return Itbook_data;
        }
    }
}
