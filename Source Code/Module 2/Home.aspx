<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <meta http-equiv="refresh" content="60">
    <title>Sanjay - The Air Mission Planner</title>
    <script src="http://www.google.com/jsapi?key=ABQIAAAAuPsJpk3MBtDpJ4G8cqBnjRRaGTYH6UMl8mADNa0YKuWNNa8VNxQCzVBXTx2DYyXGsTOxpWhvIG7Djw" type="text/javascript"></script>
    <script language =javascript src =Placemark.js></script>
</head>

<body onload="init()";>
    <form id="form1" runat="server">    
	&nbsp;        
        <asp:Table ID="Table1" runat="server" Width="720px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"> 
                    <div align = "center" style="text-align: left">Enter the Desired Location</div>
                    <div align="center" id="sample-ui" style="text-align: left"></div>
                </asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign = Right>
                    Welcome - <asp:Label ID="L_user" runat="server"></asp:Label>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="LogOut" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>	
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer runat="server" id="UpdateTimer" interval="60000" ontick="UpdateTimer_Tick" />
        <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
            </Triggers>
            <ContentTemplate>            
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <div style="position: absolute; left: 850px; top: 200; width: 350px; height: 480px;">
    <div id="map" style="width: 350px; height: 480px;"></div>
    </div>
    <div align="center" id="map3d" style="width: 840px;height:480px"></div>
</body>
</html>
