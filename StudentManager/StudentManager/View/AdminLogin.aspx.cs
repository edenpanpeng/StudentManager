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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtUserId.Text.Trim()),
                LoginPwd = this.txtPwd.Text.Trim()
            };

            try
            {
                objAdmin = new AdminService().AdminLogin(objAdmin);
                if (null == objAdmin)
                {
                    this.ltaInfo.Text = "<script>alert('用户名或密码错误！')</script>";
                }
                else
                {
                    Session["CurrentUser"] = objAdmin;
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                this.ltaInfo.Text = "<script>alert('用户登录访问出现异常'" + ex.Message+")</script>";
            }
        }
    }
}