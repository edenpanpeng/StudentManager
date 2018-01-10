using System;
using System.Data.SqlClient;
using DAL.Helper;
using Models;

namespace DAL
{
    public class AdminService
    {
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            string sql = "select AdminName from Admins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId", objAdmin.LoginId),
                new SqlParameter("@LoginPwd", objAdmin.LoginPwd)
            };
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql,param,false);
                if (objReader.Read())
                {
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                }
                else
                {
                    objAdmin = null;
                }
                objReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("用户登录数据访问出现异常："+ex.Message);
            }

            return objAdmin;
        }

        public int ModifyPwd(SysAdmin objAdmin)
        {
            string sql = "update Admins set LoginPwd=@LoginPwd where LoginId=@LoginId";

            SqlParameter[] param =
            {
                new SqlParameter("@LoginPwd", objAdmin.LoginPwd),
                new SqlParameter("@LoginId", objAdmin.LoginId)
            };
            return SQLHelper.Update(sql, param, false);
        }
    }
}
