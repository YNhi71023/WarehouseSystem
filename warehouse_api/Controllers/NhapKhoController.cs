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
        public async Task<ActionResult<IEnumerable<NhapKho>>> GetAll()
        {
            var items = await _repository.GetAllNhapKho();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nhapKho = await _repository.GetByIdNhapKho(id);
            if (nhapKho == null)
            {
                return NotFound();
            }
            return Ok(nhapKho);
        }
        [HttpGet("chitiet/get/{nhapKhoId}")]
        public async Task<ActionResult<IEnumerable<ChiTietNhapKho>>> GetChiTietNhapKho(int nhapKhoId)
        {
            var result = await _repository.GetChiTietNhapKhoAsync(nhapKhoId);
            if (result == null || !result.Any())
            {
                return NotFound("Không tìm thấy dữ liệu.");
            }
            return Ok(result);
        }
        [HttpPost("getbydaterange")]
        public async Task<IActionResult> GetPhieuNhapByDateRange([FromBody] NhapKhoDate d)
        {
            if (d.FromDate > d.ToDate)
            {
                return BadRequest("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
            }

            var data = await _repository.GetPhieuNhapByDateRange(d.FromDate, d.ToDate);
            return Ok(data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateNhapKho([FromBody] NhapKho nk)
        {
            if (nk == null || string.IsNullOrWhiteSpace(nk.SoPhieuNhapKho))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateNhapKho( nk);
            return Ok(new { Message = notification });
        }
        [HttpPost("chitiet/create")]
        public async Task<IActionResult> CreateChiTietNhapKho([FromBody] ChiTietNhapKhoCreate nk)
        {
            if (nk == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateChiTietNhapKho(nk);
            return Ok(new { Message = notification });
        }

        [HttpPut("chitiet/update")]
        public async Task<IActionResult> UpdateChiTietPhieuNhap([FromBody] ChiTietNhapKhoCreate c)
        {
            if (c == null || c.NhapKhoId <= 0)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            var updatedPhieuNhap = await _repository.UpdateChiTietNhapKho(c);
            if (updatedPhieuNhap == null)
            {
                return NotFound("Không tìm thấy phiếu nhập kho cần cập nhật.");
            }
            return Ok(new { message = "Cập nhật thành công!" });
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
