using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL.Helper
{
    class SQLHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region 执行格式SQL语句

        public static int Update(string sql) 
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog("执行 public static int Update(string sql)方法时发生异常：" + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("执行 public static object GetSingleResult(string sql)方法时发生异常：" + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader  GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("执行 public static SqlDataReader GetReader(string sql)方法时发生异常：" + ex.Message);
                throw;
            }
        }

        #endregion

        #region 执行带参数的SQL语句和存储过程

        public static int Update(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);

            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }

            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog(
                    "执行 public static int Update(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)方法时发生异常" +
                    ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object GetSingleResult(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("执行 public static object GetSingleResult(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)方法时发生异常：" + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReader(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("执行 public static SqlDataReader GetReader(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)方法时发生异常：" + ex.Message);
                throw;
            }
        }

        #endregion

        #region 写入日志
        private static void WriteLog(string msg)
        {
            FileStream fs = new FileStream("projectLog.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "" + msg);
            sw.Close();
            fs.Close();
        }
        #endregion

    }
}
