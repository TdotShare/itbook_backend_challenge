namespace itbook_backend_challenge.Mapdata.Responses
{
    public class Itbook
    {
        public int error { get; set; }
        public int total { get; set; }
        public int page { get; set; }

        public string next_page { get; set; }
        public string previous_page { get; set; }
        public Models.Book? []? books { get; set; }
    }
}
