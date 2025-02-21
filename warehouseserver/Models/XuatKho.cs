using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class XuatKho
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên kho không được bỏ trống.")]
        public string SoPhieuXuatKho { get; set; }
        [Required(ErrorMessage = "Kho không được bỏ trống")]
        public int KhoId { get; set; }
        [Required(ErrorMessage = "Ngày xuất kho không được bỏ trống")]
        public DateTime? NgayXuatKho { get; set; }
        public string? GhiChu { get; set; }
        public string TenKho { get; set; }
    }
    public class ChiTietXuatKho: ChiTietXuatKhoUpdate
    {
        public string TenSanPham { get; set; }
    }
    public class ChiTietXuatKhoUpdate
    {
        public int XuatKhoId { get; set; }
        public int SanPhamId { get; set; }
        public int SLXuat { get; set; }
        public int DonGiaXuat { get; set; }
    }
}
