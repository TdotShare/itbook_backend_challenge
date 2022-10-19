using System.Text.Json.Serialization;

namespace itbook_backend_challenge.Mapdata.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string? user_username { get; set; }
        public string? user_password { get; set; }
        public string? user_fullname { get; set; }
        public string? user_create_at { get; set; }
        public string? user_update_at { get; set; }
    }
}
