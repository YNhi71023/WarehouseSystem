namespace warehouse_api.Models
{
    public class NhapKho
    {
        public int Id { get; set; }
        public string SoPhieuNhapKho { get; set; }
        public int KhoId { get; set; }
        public int NCCId { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public String? GhiChu {  get; set; }
        public String TenKho { get; set; }
        public String TenNCC { get; set; }
    }
}