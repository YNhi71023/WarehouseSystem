using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_api.Models;
using warehouse_api.Repository;

namespace warehouse_api.Controllers
{
    [Route("api/xuatkho")]
    [ApiController]
    public class XuatKhoController : ControllerBase
    {

        private readonly XuatKhoRepository _repository;

        public XuatKhoController(XuatKhoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<XuatKho>>> GetAll()

        {
            var items = await _repository.GetAllXuatKho();
            return Ok(items);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _repository.GetByIdXuatKho(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateXuatKho([FromBody] XuatKho x)
        {
            if (x == null || string.IsNullOrWhiteSpace(x.SoPhieuXuatKho))
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var notification = await _repository.CreateXuatKho(x);
            return Ok(new { Message = notification });
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteXuatKho(int id)
        {
            var result = await _repository.DeleteXuatKho(id);
            if (result)
                return Ok(new { message = "Xóa thành công!" });
            return NotFound(new { message = "Không tìm thấy phiếu xuất!" });
        }
    }
}
