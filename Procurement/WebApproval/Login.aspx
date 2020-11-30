<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PR/PO Approval</title>
    <style type="text/css">
        .style1
        {
            width: 29%;
        }
        .style2
        {
        }
        .style3
        {
            width: 227px;
            height: 74px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table align="center" class="style1">
            <tr>
                <td align="center" class="style2" colspan="2">
                    <img alt="" class="style3" src="Images/AgililtyLogo.gif" /><br />
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblError" runat="server" Font-Names="Verdana" 
                        Font-Size="X-Small" ForeColor="Red" Text="UserID atau Password Salah" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" 
                        Text="User ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" Font-Names="Verdana" 
                        Font-Size="XX-Small" Height="16px" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUserID" ErrorMessage="UserID tidak boleh kosong" 
                        Font-Names="Verdana" Font-Size="XX-Small">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="XX-Small" 
                        Text="Password :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Font-Names="Verdana" 
                        Font-Size="XX-Small" Height="16px" TextMode="Password" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Password tidak boleh kosong" 
                        Font-Names="Verdana" Font-Size="XX-Small">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Images/logIn_enable.gif" />
                    <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Images/forgot.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        Font-Names="Verdana" Font-Size="XX-Small" style="margin-bottom: 0px" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
