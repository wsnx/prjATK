<%@ Page Language="VB" AutoEventWireup="false" CodeFile="prapproval1.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SPL - Outstanding Approval</title>    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 227px;
            height: 74px;
        }
        .style3
        {
            height: 26px;
        }
    </style>

    <meta name="viewport" content="width=<%# Request.Browser("ScreenPixelsWidth") %>, height=<%#Request.Browser("ScreenPixelsHeight")%>"/>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <img alt="PT Agility International" class="style2" 
                        src="Images/AgililtyLogo.gif" /></td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="XX-Large" Text="Outstanding PR Approval"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
                        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                        ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px" 
                        style="margin-bottom: 0px">
                        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#F7F6F3" />
                        <DynamicSelectedStyle BackColor="#5D7B9D" />
                        <Items>
                            <asp:MenuItem NavigateUrl="~/Default1.aspx" Text="Outstanding Approval" 
                                Value="Outstanding Approval"></asp:MenuItem>
                            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                            <asp:MenuItem Text="Reports" Value="Reports">
                                <asp:MenuItem NavigateUrl="~/summaryreport.aspx" Text="Summary Reports" 
                                    Value="Summary Reports"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Logout1.aspx"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#5D7B9D" />
                    </asp:Menu>
                </td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="Large" Text="List PR"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataKeyNames="NoSPL" DataSourceID="SqlDataSource1" 
                        EnableModelValidation="True" Font-Names="Verdana" Font-Size="X-Small" 
                        GridLines="Vertical" EmptyDataText="No Outstanding Approval" CssClass="footable"  >
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="NamaSite" HeaderText="NamaSite" ReadOnly="True" 
                                SortExpression="NamaSite" />
                            <asp:BoundField DataField="Customer" HeaderText="Customer" 
                                SortExpression="Customer" />
                            <asp:BoundField DataField="NoSPL" HeaderText="NoSPL" ReadOnly="True" 
                                SortExpression="NoSPL" />
                            <asp:BoundField DataField="Kategori" HeaderText="Kategori" ReadOnly="True" 
                                SortExpression="Kategori" />
                            <asp:TemplateField HeaderText="Status">
                                <AlternatingItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# eval("Status") %>'></asp:Label>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TransID" Visible="False">
                                <AlternatingItemTemplate>
                                    <asp:Label ID="lblTransID" runat="server" Text='<%# eval("MainTransID") %>'></asp:Label>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTransID" runat="server" Text='<%# eval("MainTransID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DORConnectionString %>" 
                        SelectCommand="select a.TransID as MainTransID, NamaSite, NoSPL, NamaBagian, c.CustomerName as Customer, TglLembur, Weekday as HariKerja, DiperintahOleh, case Kategori when '1' then 'Request(Customer)' when '2' then 'Request Sales / CS Agility' when '3' then 'Request(Internal)' end as Kategori , TargetPekerjaan, PencapaianTarget, InputBy, case status when 1 then 'Created' when 2 then 'Waiting for Approval' when 3 then 'Approved' when 8 then 'Realisasi Confirm' when 4 then 'Waiting for 2nd Approval' when 5 then 'Approved' when 9 then 'Cancel' end as Status from tbsplmain a inner join tbspluserconfig b on a.InputBy=b.UserID left join tbDORStorer c on a.Customer=c.StorerKey where  case when charindex('@',splappemail) &gt; 0 then lower(left(splappemail,charindex('@',splappemail)-1)) end =@UserName and status in (2,4) order by a.TransID desc">
                        <SelectParameters>
                            <asp:SessionParameter Name="UserName" SessionField="username" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style3">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="Large" Text="List Karyawan Lembur"></asp:Label>
                            </td>
                            <td class="style3">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                    CellPadding="2" DataSourceID="SqlDataSource2" EmptyDataText="No Data Selected" 
                                    EnableModelValidation="True" Font-Names="Verdana" Font-Size="XX-Small" 
                                    ForeColor="Black" GridLines="None" CssClass="footable"  >
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:BoundField DataField="NoSPL" HeaderText="NoSPL" SortExpression="NoSPL" 
                                            Visible="False" />
                                        <asp:BoundField DataField="NamaKaryawan" HeaderText="Nama Karyawan" 
                                            SortExpression="NamaKaryawan" />
                                        <asp:BoundField DataField="Departemen" HeaderText="Departemen" 
                                            SortExpression="Departemen" />
                                        <asp:BoundField DataField="PlanStart" DataFormatString="{0:t}" 
                                            HeaderText="Rencana Mulai" SortExpression="PlanStart" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PlanEnd" DataFormatString="{0:t}" 
                                            HeaderText="Rencana Selesai" SortExpression="PlanEnd" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                        HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="X-Small" Text="Alasan &quot;Not Approve&quot;" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtReason" runat="server" Width="456px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ErrorMessage="Alasan Tidak Boleh Kosong" ControlToValidate="txtReason">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                    Font-Names="Verdana" Font-Size="X-Small" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnApprove" runat="server" Font-Names="Verdana" 
                                    Font-Size="XX-Small" Text="Approve" />
                                <asp:Button ID="btnNotApprove" runat="server" Font-Names="Verdana" 
                                    Font-Size="XX-Small" Text="Not Approve" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblErr" runat="server" Font-Names="Verdana" Font-Size="Small" 
                                    ForeColor="#FF3300"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DORConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbspldetails] WHERE ([NoSPL] = @NoSPL)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="NoSPL" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:HiddenField ID="width" runat="server" />
                    <asp:HiddenField ID="height" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <link href="css/footable/footable.metro.min.css" rel="stylesheet" type="text/css" />
    <script src="_scripts/footable/footable.min.js" type="text/javascript"></script>
    <script src="_scripts/footable/jquery-1.9.1.min.js" type="text/javascript"></script>
      <script type="text/javascript">
          $(function () {
              $('#GridView1').footable();
          });
    </script>

    </form>
</body>
</html>
