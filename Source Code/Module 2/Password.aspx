<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
            Text="Enter your Email for password recovery"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="T_email" runat="server" Width="269px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="B_submit" runat="server" Text="Submit" />
    
    </div>
    </form>
</body>
</html>
