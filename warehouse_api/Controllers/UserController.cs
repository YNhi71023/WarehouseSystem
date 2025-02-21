//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using warehouse_api.CORE;
//using warehouse_api.Repository;
//using warehouse_api.Models;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using Microsoft.EntityFrameworkCore;
//using System.Data;

//namespace warehouse_api.Controllers
//{
//    [Route("api/user")]
//    [ApiController]
//    public class UserController : APIController
//    {
//        private readonly UserRepository _repository;

//        public UserController(UserRepository repository)
//        {
//            _repository = repository;
//        }
//        [HttpPost("create")]
//        public async Task<IActionResult> CreateUser([FromBody] User u)
//        {
//            if (u == null || string.IsNullOrWhiteSpace(u.MaDangNhap))
//            {
//                return BadRequest("Dữ liệu không hợp lệ.");
//            }

//            var notification = await _repository.CreateUser(user_login, u);
//            return Ok(new { Message = notification });
//        }
//        [HttpPost("login")]
//        public async Task<IActionResult> LoginUser(User u)
//        {
//            ReponseModel r = new ReponseModel();
//            DataTable data = await _repository.LoginUser(u);
          
//            if (data.Rows.Count > 0)
//            {
//                r.status = "ok";
//                r.message = "login successful";
//                reponseLogin p = new reponseLogin();

//                p.MaDangNhap = data.Rows[0]["ma_dang_nhap"].ToString();

//                string token = Security.GenerateJwtToken(p.MaDangNhap);
//                p.token = "Bearer " + token;
//                r.data = p;
//                return Ok(r);
//            }

//            return BadRequest("Error creating acccount");
//        }
//    }
//}
