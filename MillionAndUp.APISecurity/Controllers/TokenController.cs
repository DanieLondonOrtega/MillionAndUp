using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MillionAndUp.APISecurity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        // GET: TokenController
        public ActionResult GenerateToken()
        {
            return View();
        }
    }
}
