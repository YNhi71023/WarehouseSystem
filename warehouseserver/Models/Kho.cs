using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{
    public class Kho
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên kho không được bỏ trống.")]
        public string TenKho { get; set; }
        public string? GhiChu { get; set; }
    }
}
