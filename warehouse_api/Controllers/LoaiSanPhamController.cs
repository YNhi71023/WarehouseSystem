using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/loaisanpham")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly LoaiSanPhamRepository _repository;

        public LoaiSanPhamController(LoaiSanPhamRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<LoaiSanPham>>> GetAll()

        {
            var items = await _repository.GetAllLoaiSanPham();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var l = await _repository.GetByIdLoaiSanPham(id);
            if (l == null)
            {
                return NotFound();
            }
            return Ok(l);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLoaiSanPham([FromBody] LoaiSanPham l)
        {
            if (l == null || string.IsNullOrWhiteSpace(l.MaLSP))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            Console.WriteLine($"Nhận được: {l.MaLSP}, Tên: {l.TenLSP}, Ghi chú: {l.GhiChu}");
            var notification = await _repository.CreateLoaiSanPham( l);
            return Ok(new { Message = notification });
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateLoaiSanPham([FromBody] LoaiSanPham l)
        {
            if (l == null || l.Id <= 0) {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            var updatedLoaiSanPham = await _repository.UpdateLoaiSanPham(l);

            if(updatedLoaiSanPham == null) { return NotFound("Không tìm thấy loại sản phẩm."); }
            return Ok(new {message = "Cập nhật thành công!", data = updatedLoaiSanPham});
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLoaiSanPham(int id)
        {
            var result = await _repository.DeleteLoaiSanPham( id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy loại sản phẩm!" });
        }
    }
}
