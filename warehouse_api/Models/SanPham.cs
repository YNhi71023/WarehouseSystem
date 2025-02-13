namespace warehouse_api.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int LSPId { get; set; }
        public int DVTId { get; set; }
        public string? GhiChu { get; set; }
        public string TenLSP { get; set; }
        public string TenDonViTinh { get; set; }
    }

}
