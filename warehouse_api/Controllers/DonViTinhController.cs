using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/donvitinh")]
    [ApiController]
    public class DonViTinhController : ControllerBase
    {
        private readonly DonViTinhRepository _repository;

        public DonViTinhController(DonViTinhRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<DonViTinh>>> GetAll()

        {
            var items = await _repository.GetAllDonViTinh();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donViTinh = await _repository.GetByIdDonViTinh(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            return Ok(donViTinh);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateDonViTinh([FromBody] DonViTinh d)
        {
            if (d == null || string.IsNullOrWhiteSpace(d.TenDonViTinh))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            Console.WriteLine($"Nhận được: {d.TenDonViTinh}, Ghi chú: {d.GhiChu}");

            var notification = await _repository.CreateDonViTinh(d);
            return Ok(new { Message = notification });
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDonViTinh([FromBody] DonViTinh d)
        {
            if (d == null || d.Id <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var updatedDonViTinh = await _repository.UpdateDonViTinh(d);

            if (updatedDonViTinh == null)
            {
                return NotFound("Không tìm thấy đơn vị tính cần cập nhật.");
            }

            return Ok(new { message = "Cập nhật thành công!", data = updatedDonViTinh });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDonViTinh(int id)
        {
            var result = await _repository.DeleteDonViTinh(id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy đơn vị tính!" });
        }

    }
}
