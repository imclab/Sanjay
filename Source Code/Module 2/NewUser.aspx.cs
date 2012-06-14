using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class NewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void B_clear_Click(object sender, EventArgs e)
    {
        T_designation.Text = "";
        T_email.Text = "";
        T_name.Text = "";
        T_phone.Text = "";
        T_purpose.Text = "";        
    }

    protected void B_submit_Click(object sender, EventArgs e)
    {
        bool success = DataAccess.AddUser(T_userid.Text,T_pass1.Text,T_name.Text, Int32.Parse(T_phone.Text), T_designation.Text, T_email.Text, T_purpose.Text);
        if (success)
        {
            Response.Redirect("success.aspx");
        }
    }
}
