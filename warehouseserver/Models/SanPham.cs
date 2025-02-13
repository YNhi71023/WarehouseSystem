using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã sản phẩm không được bỏ trống.")]
        public string MaSP { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống.")]
        public string TenSP { get; set; }
        public int LSPId { get; set; }
        public int DVTId { get; set; }
        public string? GhiChu { get; set; }
        [Required(ErrorMessage = "Loại sản phẩm không được bỏ trống.")]
        public string TenLSP { get; set; }
        [Required(ErrorMessage = "Đơn vị tính không được bỏ trống.")]
        public string TenDonViTinh { get; set; }
    }
}
