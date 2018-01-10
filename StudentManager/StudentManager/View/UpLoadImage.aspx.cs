using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManager.View
{
    public partial class UpLoadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/ErrorPage.html");
                }
                ViewState["StudentId"] = Request.QueryString["id"];
            }

        }

        protected void btnUpLoadImage_Click(object sender, EventArgs e)
        {
            if (!this.fulStuImage.HasFile) return;

            double fileLength = this.fulStuImage.FileContent.Length / (1024.0 * 1024.0);
            if (fileLength > 1)
            {
                this.ltaMsg.Text = "<script>alert('图片必须小于1M')</script>";
                return;
            }

            string fileName = this.fulStuImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".png")
            {
                this.ltaMsg.Text = "<script>alert('图片必须是png')</script>";
                return;
            }

            fileName = ViewState["StudentId"].ToString() + ".png";
            try
            {
                string path = Server.MapPath("~/Images/Stus");
                this.fulStuImage.SaveAs(path + "/" + fileName);
                this.ltaMsg.Text = "<script>alert('图片上传成功')</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('图片上传失败')</script>";
            }
        }
    }
}