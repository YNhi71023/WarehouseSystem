using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/sanpham")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {

        private readonly SanPhamRepository _repository;

        public SanPhamController(SanPhamRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetAll()

        {
            var items = await _repository.GetAllSanPham();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _repository.GetByIdSanPham(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSanPham([FromBody] SanPham s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s.TenSP))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateSanPham( s);
            return Ok(new { Message = notification });
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSanPham([FromBody] SanPham s)
        {
            if (s == null || s.Id <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var updatedSanPham = await _repository.UpdateSanPham( s);

            if (updatedSanPham == null)
            {
                return NotFound("Không tìm thấy đơn vị tính cần cập nhật.");
            }

            return Ok(new { message = "Cập nhật thành công!", data = updatedSanPham});
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var result = await _repository.DeleteSanPham( id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy sản phẩm!" });
        }
    }
}
