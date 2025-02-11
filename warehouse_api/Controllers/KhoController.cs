using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/kho")]
    [ApiController]
    public class KhoController : ControllerBase
    {
        private readonly KhoRepository _repository;

        public KhoController(KhoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Kho>>> GetAll()

        {
            var items = await _repository.GetAllKho();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var k = await _repository.GetByIdKho(id);
            if (k == null)
            {
                return NotFound();
            }
            return Ok(k);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateKho([FromBody] Kho k)
        {
            if (k == null || string.IsNullOrWhiteSpace(k.TenKho))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateKho(k);
            return Ok(new { Message = notification });
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateKho([FromBody] Kho k)
        {
            if (k == null || k.Id <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var updatedKho = await _repository.UpdateKho(k);

            if (updatedKho == null)
            {
                return NotFound("Không tìm thấy kho cần cập nhật.");
            }

            return Ok(new { message = "Cập nhật thành công!", data = updatedKho });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteKho(int id)
        {
            var result = await _repository.DeleteKho(id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy kho!" });
        }

    }
}
