//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace warehouse_api.CORE
//{
//    public class APIController : ControllerBase
//    {
//        public int user_login
//        {
//            get
//            {
//                try
//                {
//                    string token = Request.Headers["Authorization"].ToString();
//                    var gentoken = new JwtSecurityTokenHandler();
//                    var jwtToken = gentoken.ReadJwtToken(token.Replace("Bearer ", ""));

//                    var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "user_id");
//                    if (userIdClaim != null)
//                    {
//                        return int.Parse(userIdClaim.Value);
//                    }
//                    return 0;
//                }
//                catch (Exception)
//                {
//                    return 0;
//                }
//            }
//        }

//        public int ma_dang_nhap
//        {
//            get
//            {
//                try
//                {
//                    string token = Request.Headers["Authorization"].ToString();
//                    var gentoken = new JwtSecurityTokenHandler();
//                    dynamic c = gentoken.ReadToken(token.Replace("Bearer ", ""));

//                    return Convert.ToInt32(c.Claims[3].Value);
//                }
//                catch (Exception)
//                {

//                    return 0;
//                }

//            }
//        }
//    }
//}
