using Core.Contracts;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AdminService
{
    public class AdminManager : IAdmin
    {
        public bool UserValidation(string UserId, string Password)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<LoginCredentials> credentials = entity.LoginCredentials.FromSql("select * from LoginCredentials where UserId = @Id and Password = @Password", new SqlParameter("@Id", UserId), new SqlParameter("@Password", Password)).ToList<LoginCredentials>();

                if (credentials.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Validation Failed! Please Contact Admin" + ex.StackTrace);
            }
        }

    }
}
