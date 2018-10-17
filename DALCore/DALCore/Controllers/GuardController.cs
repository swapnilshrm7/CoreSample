using GuardService;
using Microsoft.AspNetCore.Mvc;

namespace DALCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardController : Controller
    {
        IGuard guard;
        public GuardController(IGuard _guard)
        {
            guard = _guard; 
        }   
    }
}