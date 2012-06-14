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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class GeneratImage : System.Web.UI.Page
{
    private int _height = 75;
    public int height
    {
      get { return _height; }
      set { _height = value; }
    }

    private string _text = "generateimage";
    public string text
    {
      get { return _text; }
      set { _text = value; }
    }
    private int _width = 275;
    public int width
    {
        get { return _width; }
        set { _width = value; }
    }
    //Get Character from Random Number
    /// </summary>
    /// <param name="genNo"></param>
    /// <returns></returns>
    
    public string getChar(int genNo)
    {
        switch (genNo)
        {
            case 0:
                return "a";
            case 1:
                return "b";
            case 2:
                return "c";
            case 3:
                return "d";
            case 4:
                return "e";
            case 5:
                return "f";
            case 6:
                return "g";
            case 7:
                return "h";
            case 8:
                return "i";
            case 9:
                return "j";
        }
        return string.Empty;
    }
  //generating random numbers.
    private Random ObjRandom = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        //generate random text
        Random r = new Random();
        string str =r.Next().ToString().Substring(0,4);
        char[] ch = str.ToCharArray();
        text = string.Empty;
        foreach (char var in ch)
        {
            //get appropriate char
            text += getChar(Convert.ToInt32(var.ToString()));
        }
        //generate random image
        GenerateImage();
    }
    /// <summary>
    /// Generate Image
    /// </summary>

    private void GenerateImage()
     {
        //using System.Drawing; and using System.Drawing.Imaging;
        //Create a new 32-bit bitmap image.
        //specify height width
        //if you want to change pass that value in to query string
        Bitmap ObjBitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);
        //Create a graphics object 
        Graphics ObjGraphic = Graphics.FromImage(ObjBitmap);
        ObjGraphic.SmoothingMode = SmoothingMode.HighQuality;
        Rectangle ObjRect = new Rectangle(0, 0, this.width, this.height);
        // Fill in the background color
        //using System.Drawing.Drawing2D;
        //you specify different fillup style
        HatchBrush ObjHatchBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Transparent, Color.Transparent);
        ObjGraphic.FillRectangle(ObjHatchBrush, ObjRect);
        // Text Font Size
        SizeF ObjectFontSize;
        float fontSize = ObjRect.Height + 3;
        Font ObjFont;
        // Adjust the font size until the text fits within the image.
        do
        {
            fontSize--;
            ObjFont = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold);
            ObjectFontSize = ObjGraphic.MeasureString(this.text, ObjFont);
        } while (ObjectFontSize.Width > ObjRect.Width);
        // Set up the text format.
        StringFormat ObjectStringFormat = new StringFormat();
        ObjectStringFormat.Alignment = StringAlignment.Center;
        ObjectStringFormat.LineAlignment = StringAlignment.Center;    
        // Create a path using the text and warp it randomly.
        GraphicsPath ObjGraphicPath = new GraphicsPath();
        ObjGraphicPath.AddString(this.text, ObjFont.FontFamily, (int)ObjFont.Style, ObjFont.Size, ObjRect, ObjectStringFormat);
        float size = 6F;
        PointF[] points =
        {
            new PointF(this.ObjRandom.Next(ObjRect.Width) / size, this.ObjRandom.Next(ObjRect.Height) / size),
            new PointF(ObjRect.Width - this.ObjRandom.Next(ObjRect.Width) / size, this.ObjRandom.Next(ObjRect.Height) / size),
            new PointF(this.ObjRandom.Next(ObjRect.Width) / size, ObjRect.Height - this.ObjRandom.Next(ObjRect.Height) / size),
            new PointF(ObjRect.Width - this.ObjRandom.Next(ObjRect.Width) / size, ObjRect.Height - this.ObjRandom.Next(ObjRect.Height) / size)
        };
        Matrix ObjMatrix = new Matrix();
        ObjMatrix.Translate(0F, 0F);
        ObjGraphicPath.Warp(points, ObjRect, ObjMatrix, WarpMode.Perspective, 0F);
        //Draw Text
        ObjHatchBrush = new HatchBrush(HatchStyle.Wave, Color.Gray, Color.DarkGray);
        ObjGraphic.FillPath(ObjHatchBrush, ObjGraphicPath);
        //Add more noise in the image
        int m = Math.Max(ObjRect.Width, ObjRect.Height);
        for (int i = 0; i < (int)(ObjRect.Width * ObjRect.Height / 30F); i++)
        {
            int x = this.ObjRandom.Next(ObjRect.Width);
            int y = this.ObjRandom.Next(ObjRect.Height);
            int w = this.ObjRandom.Next(m / 52);
            int h = this.ObjRandom.Next(m / 52);
            ObjGraphic.FillEllipse(ObjHatchBrush, x, y, w, h);
        }
        ObjFont.Dispose();
        ObjHatchBrush.Dispose();
        ObjGraphic.Dispose();
        this.Response.ContentType = "image/jpeg";
        Session.Add("ImageString",this.text);
        ObjBitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
    }
}