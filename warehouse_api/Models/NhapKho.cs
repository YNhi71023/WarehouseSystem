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
    public class ChiTietNhapKho
    {
        public int SLNhap { get; set; }
        public int DonGiaNhap { get; set; }
        public string SoPhieuNhapKho { get; set; }
        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }

    }
    public class ChiTietNhapKhoCreate
    {
        public int NhapKhoId { get; set; }
        public int SanPhamId { get; set; }
        public int SLNhap { get; set; }
        public int DonGiaNhap { get; set; }
    }
    public class BaoCaoNhapKhoDate
    {
        public string SoPhieuNhapKho { get; set; }
        public string TenKho { get; set; }
        public string TenNCC { get; set; }
        public DateTime NgayNhapKho { get; set; }
    }
    public class NhapKhoDate
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}