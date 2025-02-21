namespace warehouse_api.Models
{
    public class ReponseModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}
