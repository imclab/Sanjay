using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session["Username"] = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        T_pass.Text = "";
        T_user.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlDataReader reader = DataAccess.CheckLogin(T_user.Text))
            
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    if(reader.GetString(0) == T_user.Text)
                    {
                        HttpContext.Current.Session["Username"] = T_user.Text;                        
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        L_Status.Text = "Incorrect Username/Password";
                    }
                }
                else
                    L_Status.Text = "Incorrect Username/Password";
            }
        }
        catch (SqlException ex)
        {
            L_Status.Text = ex.Message;
        }
    }
}