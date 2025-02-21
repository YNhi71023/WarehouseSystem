namespace warehouse_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string MaDangNhap { get; set; }
        public int KhoId { get; set; }
        public DateTime LoginTime { get; set; }
    }
    public class reponseLogin
    {
        public string MaDangNhap { get; set; }
        public string token { get; set; }
    }
}
