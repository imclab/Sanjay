using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;

public class connection
{    
    public static SqlConnection GetConnection()
    {
        //Establishes connection to Campus Connect database
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
        SqlConnection connect = new SqlConnection(connectionstring);
        connect.Open();
        return connect;
    }
}
