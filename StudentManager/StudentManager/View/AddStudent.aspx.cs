using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;

namespace StudentManager.View
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlClass.DataSource = new StudentClassService().GetAllClass();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                this.ltaMsg.Text = "<script>alter('验证码不正确')</script>";
                return;
            }

            StudentService objStuService = new StudentService();
            if (objStuService.IsIdNoExisted(this.txtStuIdNo.Text.Trim()))
            {
                this.ltaMsg.Text = "<script>alter('身份证号已重复')</script>";
                return;
            }

            Student objStudent = new Student()
            {
                StudentName = this.txtStuName.Text.Trim(),
                Gender = this.ddlGender.Text.Trim(),
                Birthday = Convert.ToDateTime(this.txtStuBirthday.Text.Trim()),
                ClassId = Convert.ToInt32(this.ddlClass.SelectedValue),
                StudentAddress = this.txtStuAddress.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentIdNo = this.txtStuIdNo.Text.Trim()
            };

            try
            {
                int newStudentId = objStuService.AddStudent(objStudent);
                if (newStudentId > 0)
                {
                    Response.Redirect("~/View/UpLoadImage.aspx?id="+newStudentId);
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alter('添加学员失败"+ ex.Message+ "身份证号已重复')</script>";
            }
        }
    }
}