//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using warehouse_api.Models;

//namespace warehouse_api.CORE
//{
//    public class Security
//    {

        
//        public static string GenerateJwtToken(string MaDangNhap)
//        {
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iKfolJLNwhnuMayeSPlgVoeJzPYWjCUb"));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, MaDangNhap),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//            };

//            var token = new JwtSecurityToken(
//                issuer: "JwtIssuer",
//                audience: "JwtAudience",
//                claims: claims,
//                expires: DateTime.UtcNow.AddHours(1),
//                signingCredentials: credentials
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//    }

//    public class SercurityTokenAttribute : Attribute, IAsyncActionFilter
//    {
//        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {

//            if (context.HttpContext.Request.Headers.Authorization.Count() == 0)
//            {
//                ReponseModel r = new ReponseModel();
//                r.message = "Not Found";
//                r.status = "error";
//                context.Result = new BadRequestObjectResult(r);
//                return;
//            }
//            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var _poten))
//            {
//                if (string.IsNullOrEmpty(_poten))
//                {
//                    ReponseModel r = new ReponseModel();
//                    r.message = "Not Found Token";
//                    r.status = "error";
//                    context.Result = new BadRequestObjectResult(r);
//                    return;
//                }
//            }
//            await next();
//        }
//    }
//}

