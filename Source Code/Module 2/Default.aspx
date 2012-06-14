<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sanjay - The Air Mission Planner</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        &nbsp;<h1>
            &nbsp;</h1>
        <h1>
            <b>Sanjay - The Air Mission Planner</b></h1>
        <div class="style1">
            <br />
            <br />
    
        <asp:Label ID="Label1" runat="server" Text="UserName" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="T_user" runat="server" Width="201px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="T_user" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="T_pass" runat="server" Width="201px" TextMode="Password"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="T_pass" ErrorMessage="*" 
                style="text-align: center"></asp:RequiredFieldValidator>
    
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Login" 
                onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Clear" onclick="Button2_Click" />
            <br />
            &nbsp;<br />
            <asp:Label ID="L_Status" runat="server" Text=""></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" style="font-weight: 700" 
                NavigateUrl="~/NewUser.aspx">New User?</asp:HyperLink>
        </div>
    
    </div>
    </form>
</body>
</html>
