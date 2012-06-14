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

public class DataAccess
{    
    public static SqlDataReader CheckLogin(string Id)
    {
        //string sql = string.Format("SELECT password FROM UserDetails WHERE userid = {0}", Id);
        string sql = string.Format("SELECT password FROM UserDetails WHERE username = \'{0}\'",Id);

        SqlConnection connect = connection.GetConnection();

        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }

    public static bool AddUser(string user,string pass,string name,int phone,string dsg,string mail,string purp)
    {
        try
        {
            string sql = "INSERT INTO UserDetails(username,password,fullname,phone,designation,email,purpose)" +
                "VALUES(@user,@pass,@name,@phone,@dsg,@mail,@purp)";

            SqlConnection connect = connection.GetConnection();
            SqlCommand command = new SqlCommand(sql, connect);
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@pass", pass);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@dsg", dsg);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@purp", purp);

            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            return true;
        }
        catch (SqlException ex)
        {
            return false;
        }
    }

    public static SqlDataReader GetFlights()
    {
        //string sql = string.Format("SELECT password FROM UserDetails WHERE userid = {0}", Id);
        string sql = string.Format("SELECT * FROM flights");

        SqlConnection connect = connection.GetConnection();

        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }
    public static int GetFlightCount()
    {
        string sql = "SELECT COUNT(*) FROM flights";

        SqlConnection connect = connection.GetConnection();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;
        
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        
        if (reader.Read())
            return reader.GetInt32(0);
        else
            return 0;
    }    
    public static void UpdateFlights(string _lat,string _lon,string _flight)
    {
        //    string sql = "UPDATE Vehicle_Registration SET Number=@number, Company=@company WHERE Id=@username";
        string sql = "UPDATE flights SET lat =@lat,long = @long WHERE flightno = @flight";
        using (SqlConnection connect = connection.GetConnection())
        {
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@lat", _lat);
            command.Parameters.AddWithValue("@long", _lon);
            command.Parameters.AddWithValue("@flight", _flight);
            command.ExecuteNonQuery();
        }
    }
}