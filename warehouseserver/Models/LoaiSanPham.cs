using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class LoaiSanPham
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã loại sản phẩm không được bỏ trống.")]
        public string MaLSP { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được bỏ trống.")]
        public string TenLSP { get; set; }
        public string GhiChu { get; set; }
    }
}
