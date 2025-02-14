using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/nhapkho")]
    [ApiController]
    public class NhapKhoController : ControllerBase
    {
        private readonly NhapKhoRepository _repository;

        public NhapKhoController(NhapKhoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<DonViTinh>>> GetAll()

        {
            var items = await _repository.GetAllNhapKho();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donViTinh = await _repository.GetByIdNhapKho(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            return Ok(donViTinh);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateNhapKho([FromBody] NhapKho nk)
        {
            if (nk == null || string.IsNullOrWhiteSpace(nk.SoPhieuNhapKho))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateNhapKho(nk);
            return Ok(new { Message = notification });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNhapKho(int id)
        {
            var result = await _repository.DeleteNhapKho(id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm Phiếu nhập kho!" });
        }
    }
}
