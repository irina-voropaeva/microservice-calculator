using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthMicroservice
{
    public class TokenValidationController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetIsTokenValid()
        {
            return Ok($"valid, {User.Identity.Name}");
        }
    }
}
