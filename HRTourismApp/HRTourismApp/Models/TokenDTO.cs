namespace HRTourismApp.Models
{
    public class TokenDTO
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public long user_id { get; set; }
        public string user_roles { get; set; }
    }
}
