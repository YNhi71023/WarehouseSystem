using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class NhapKho
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Số phiếu nhập kho không được bỏ trống.")]
        public string SoPhieuNhapKho { get; set; }
        [Required(ErrorMessage = "Kho không được bỏ trống.")]
        public int KhoId { get; set; }
        [Required(ErrorMessage = "Nhà cung cấp không được bỏ trống.")]
        public int NCCId { get; set; }
        [Required(ErrorMessage = "Ngày nhập kho không được bỏ trống.")]
        public DateTime NgayNhapKho { get; set; }
        public String? GhiChu { get; set; }
        [Required(ErrorMessage = "Tên kho không được bỏ trống.")]
        public String TenKho { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được bỏ trống.")]
        public String TenNCC { get; set; }
    }
    public class ChiTietNhapKho: ChiTietNhapKhoCreate
    {
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
