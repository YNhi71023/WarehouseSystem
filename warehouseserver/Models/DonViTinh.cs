using System.ComponentModel.DataAnnotations;

namespace warehouseserver.Models
{

    public class DonViTinh
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên đơn vị tính không được bỏ trống.")]
        public string TenDonViTinh { get; set; }

        public string? GhiChu { get; set; }
    }

}
