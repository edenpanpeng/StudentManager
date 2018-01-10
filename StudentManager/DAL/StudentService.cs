using System;
using System.Collections.Generic;
using Models;
using System.Data;
using System.Data.SqlClient;
using DAL.Helper;
using System.Text;

namespace DAL
{
    public class StudentService
    {
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from students where studentIdNo=@StudentIdNo";
            SqlParameter[] param = { new SqlParameter("@StudentIdNo", studentIdNo) };
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql,param,false));
            return result == 1;
        }

        public int AddStudent(Student objStudent)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@StudentName", objStudent.StudentName),
                new SqlParameter("@Gender", objStudent.Gender),
                new SqlParameter("@Birthday", objStudent.Birthday),
                new SqlParameter("@StudentIdNo", objStudent.StudentIdNo),
                new SqlParameter("@PhoneNumber", objStudent.PhoneNumber),
                new SqlParameter("@StudentAddress", objStudent.StudentAddress),
                new SqlParameter("@ClassId", objStudent.ClassId),
            };

            return Convert.ToInt32(SQLHelper.GetSingleResult("usp_AddStudent", param, true));
        }

        public List<StudentExt> GetStudentByClass(string className)
        {
            string sql = "select StudentId, StudentName, Gender, Birthday, ClassName, StudentAddress from students";
            sql += " inner join StudentClass on Students.ClassId = StudentClass.ClassId";
            sql += " where ClassName = @ClassName";

            SqlParameter[] param = { new SqlParameter("@ClassName", className) };

            SqlDataReader objReader = SQLHelper.GetReader(sql, param, false);
            List<StudentExt> stuList = new List<StudentExt>();
            while (objReader.Read())
            {
                stuList.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    ClassName = objReader["ClassName"].ToString()
                });
            }

            objReader.Close();

            return stuList;
        }

        public StudentExt GetStudentById(string studentId)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select StudentId, StudentName, Gender, Birthday, ClassName, ");
            sqlBuilder.Append("StudentIdNo, PhoneNumber, StudentAddress, Students.ClassId from Students ");
            sqlBuilder.Append("inner join StudentClass on Students.ClassId = StudentClass.ClassId");
            sqlBuilder.Append(" where StudentId = @StudentId");

            SqlParameter[] param = { new SqlParameter("@StudentId", studentId)};

            SqlDataReader objReader = SQLHelper.GetReader(sqlBuilder.ToString(), param, false);
            StudentExt objStudent = null;
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    ClassName = objReader["ClassName"].ToString()
                };
            }

            objReader.Close();
            return objStudent;
        }

        public bool IsIdNoExisted(string idNO, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo = @StudentIdNo and StudentId<>@StudentId";

            SqlParameter[] param =
            {
                new SqlParameter("@StudentIdNo", idNO),
                new SqlParameter("@StudentId", studentId)
            };

            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param, false));

            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public int ModifyStudent(Student objStudent)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@StudentName", objStudent.StudentName),
                new SqlParameter("@Gender", objStudent.Gender),
                new SqlParameter("@Birthday", objStudent.Birthday),
                new SqlParameter("@StudentIdNo", objStudent.StudentIdNo),
                new SqlParameter("@PhoneNumber", objStudent.PhoneNumber),
                new SqlParameter("@StudentAddress", objStudent.StudentAddress),
                new SqlParameter("@ClassId", objStudent.ClassId),
                new SqlParameter("@StudentId", objStudent.StudentId)
            };

            return Convert.ToInt32(SQLHelper.GetSingleResult("usp_modifyStudent", param, true));
        }
    }
}
