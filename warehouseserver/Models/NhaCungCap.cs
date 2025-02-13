using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã nhà cung cấp không được bỏ trống.")]
        public string MaNCC { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được bỏ trống.")]
        public string TenNCC { get; set; }
        public string? GhiChu { get; set; }
    }
}
