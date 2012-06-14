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
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Timers;

public partial class Home : System.Web.UI.Page
{
    HiddenField[] flightno;
    HiddenField[] source;
    HiddenField[] dest;
    HiddenField[] alt;
    HiddenField[] dep;
    HiddenField[] airline;
    HiddenField[] lat;
    HiddenField[] lon;
    HiddenField totalflights;
    int count = 0;
    int flights = 0;
    
    //System.Timers.Timer timer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Username"] == "")        
            Response.Redirect("Default.aspx");        
        else
            L_user.Text = HttpContext.Current.Session["Username"].ToString() + "   ";
        AccessFlightInfo();
    }    
    protected void AccessFlightInfo()
    {
        totalflights = new HiddenField();
        totalflights.ID = "total";
        flights = DataAccess.GetFlightCount();
        totalflights.Value = flights.ToString();
        form1.Controls.Add(totalflights);
        count = 0;

        using (SqlDataReader reader = DataAccess.GetFlights())
        {
            flightno = new HiddenField[flights];
            source = new HiddenField[flights];
            dest = new HiddenField[flights];
            alt = new HiddenField[flights];
            dep = new HiddenField[flights];
            airline = new HiddenField[flights];
            lat = new HiddenField[flights];
            lon = new HiddenField[flights];

            while (reader.Read())
            {
                flightno[count] = new HiddenField();
                flightno[count].ID = "flightno" + count.ToString();
                flightno[count].Value = reader.GetString(0);
                form1.Controls.Add(flightno[count]);

                source[count] = new HiddenField();
                source[count].ID = "source" + count.ToString();
                source[count].Value = reader.GetString(1);
                form1.Controls.Add(source[count]);

                dest[count] = new HiddenField();
                dest[count].ID = "dest" + count.ToString();
                dest[count].Value = reader.GetString(2);
                form1.Controls.Add(dest[count]);

                alt[count] = new HiddenField();
                alt[count].ID = "alt" + count.ToString();
                alt[count].Value = reader.GetString(3);
                form1.Controls.Add(alt[count]);

                dep[count] = new HiddenField();
                dep[count].ID = "dep" + count.ToString();
                dep[count].Value = reader.GetString(4);
                form1.Controls.Add(dep[count]);

                airline[count] = new HiddenField();
                airline[count].ID = "airline" + count.ToString();
                airline[count].Value = reader.GetString(5);
                form1.Controls.Add(airline[count]);

                lat[count] = new HiddenField();
                lat[count].ID = "lat" + count.ToString();
                lat[count].Value = reader.GetString(6);
                form1.Controls.Add(lat[count]);

                lon[count] = new HiddenField();
                lon[count].ID = "lon" + count.ToString();
                lon[count].Value = reader.GetString(7);
                form1.Controls.Add(lon[count]);
                count++;
            }
        }
    }

    //Simulate radar data by updating the lat/lon every 30 sec.
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {        
        for (int count = 0; count < flights; count++)
        {
            lat[count].Value = (0.2 + float.Parse(lat[count].Value)).ToString();
            lon[count].Value = (0.2 + float.Parse(lon[count].Value)).ToString();
            DataAccess.UpdateFlights(lat[count].Value, lon[count].Value, flightno[count].Value);
        }
        AccessFlightInfo();        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["Username"] = "";
        Response.Redirect("Default.aspx");
    }
}
