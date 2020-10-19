<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimerTest.aspx.cs" Inherits="TimerTest.TimerTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Panel ID="pnlEnterName" runat="server">
                <label id="nameLabel">Enter Name: </label><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Button ID="btnEnterName" runat="server" Text="Go" OnClick="btnEnterName_Click" />
            </asp:Panel>
            
            <asp:Timer ID="Timer1" runat="server" Interval="500" ontick="Timer1_Tick">
            </asp:Timer>
            <asp:UpdatePanel ID="pnlTurns" runat="server" Visible="false">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="TurnButton" Text="End Turn" runat="server" Enabled="false" OnClick="TurnButton_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick">
                    </asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="TurnButton" EventName="Click">
                    </asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
