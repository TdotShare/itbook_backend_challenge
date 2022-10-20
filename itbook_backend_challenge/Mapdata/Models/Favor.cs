namespace itbook_backend_challenge.Mapdata.Models
{
    public class Favor
    {
        public int favor_id { get; set; }
        public Int64? favor_book_id { get; set; }
        public int? favor_user_id { get; set; }
        public string? favor_create_at { get; set; }
        public string? favor_update_at { get; set; }
    }
}
