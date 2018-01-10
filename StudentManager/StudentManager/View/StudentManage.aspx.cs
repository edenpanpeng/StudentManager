using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace StudentManager.View
{
    public partial class StudentManage : System.Web.UI.Page
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            //this.dlStuInfo.DataSource = new StudentService().GetStudentByClass(this.ddlClass.SelectedItem.Text.Trim());
            this.Repeater1.DataSource = new StudentService().GetStudentByClass(this.ddlClass.SelectedItem.Text.Trim());
            this.DataBind();
        }
    }
}