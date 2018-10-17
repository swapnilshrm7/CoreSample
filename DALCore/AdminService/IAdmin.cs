using System;
using System.Collections.Generic;
using System.Text;

namespace AdminService
{
    public interface IAdmin
    {
        bool UserValidation(string UserId, string Password);
    }
}
