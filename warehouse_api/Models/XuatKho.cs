namespace warehouse_api.Models
{
    public class XuatKho
    {
        public int Id { get; set; }
        public string SoPhieuXuatKho { get; set; }
        public int KhoID { get; set; }
        public DateTime? NgayXuatKho { get; set; }
        public string? GhiChu {  get; set; }
        public string TenKho {  get; set; }
    }
    public class ChiTietXuatKho
    {
        public int XuatKhoId { get; set; }
        public int SanPhamId { get; set; }
        public string TenSanPham {  get; set; }
        public int SLXuat {  get; set; }
        public int DonGiaXuat {  get; set; }
    }
}