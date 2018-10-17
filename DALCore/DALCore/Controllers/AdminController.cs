using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminService;
namespace DALCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdmin admin;
        public AdminController(IAdmin _admin)
        {
            admin = _admin;
        }
        [HttpPut]
        public bool ValidateUser(string userId, string password)
        {
            return admin.UserValidation(userId, password);
        }
    }
}