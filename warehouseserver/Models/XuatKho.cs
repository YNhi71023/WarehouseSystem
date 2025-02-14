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
}
