using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/nhacungcap")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly NhaCungCapRepository _repository;

        public NhaCungCapController(NhaCungCapRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<NhaCungCap>>> GetAll()

        {
            var items = await _repository.GetAllNhaCungCap();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var n = await _repository.GetByIdNhaCungCap(id);
            if (n == null)
            {
                return NotFound();
            }
            return Ok(n);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNhaCungCap([FromBody] NhaCungCap n)
        {
            if (n == null || string.IsNullOrWhiteSpace(n.MaNCC))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            var notification = await _repository.CreateNhaCungCap(n);
            return Ok(new { Message = notification });
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateNhaCungCap([FromBody] NhaCungCap n)
        {
            if (n == null || n.Id <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            var updatedNhaCungCap = await _repository.UpdateNhaCungCap(n);

            if (updatedNhaCungCap == null) { return NotFound("Không tìm thấy nhà cung cấp."); }
            return Ok(new { message = "Cập nhật thành công!", data = updatedNhaCungCap });
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNhaCungCap(int id)
        {
            var result = await _repository.DeleteNhaCungCap(id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy nhà cung cấp!" });
        }
    }
}
