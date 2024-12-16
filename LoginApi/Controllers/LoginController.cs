using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Policy")]
    public class LoginController : Controller
    {
        [HttpPost(Name = "Login")]
        public ApiResponse Login([FromBody] User user)
        {
            ApiResponse apiRes = new ApiResponse{ message = "Login Fail" };

            string AdminUsername = "Admin";
            //encrypt input password
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.password, 12);

            //check encrypt password is correct?
            bool isCorrectPassword = BCrypt.Net.BCrypt.EnhancedVerify("Password123456", passwordHash);
            if (isCorrectPassword && user.username.Equals(AdminUsername))
                apiRes.message = "Login Success";

            return apiRes;
        }
    }
}
