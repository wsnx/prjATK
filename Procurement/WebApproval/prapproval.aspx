<%@ Page Language="VB" AutoEventWireup="false" CodeFile="prapproval.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PR - Outstanding Approval</title>    
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
        .auto-style1 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="XX-Large" Text="Outstanding PR Approval"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    <img alt="PT Agility International" class="style2" 
                        src="Images/AgililtyLogo.gif" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
                        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Small" 
                        ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px" 
                        style="margin-bottom: 0px">
                        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#F7F6F3" />
                        <DynamicSelectedStyle BackColor="#5D7B9D" />
                        <Items>
                            <asp:MenuItem NavigateUrl="~/prapproval.aspx" Text="Outstanding PR Approval" 
                                Value="Outstanding PR Approval"></asp:MenuItem>
                            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/poapproval.aspx" Text="Outstanding PO Approval" Value="Outstanding PO Approval"></asp:MenuItem>
                            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                            <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Logout.aspx"></asp:MenuItem>
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
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="Large" Text="List PR"></asp:Label>
                </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataKeyNames="PRNo" DataSourceID="SqlDataSource1" 
                        EnableModelValidation="True" Font-Names="Verdana" Font-Size="Small" 
                        GridLines="Vertical" EmptyDataText="No Outstanding Approval">
                        <AlternatingRowStyle BackColor="Gainsboro" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="TransID" Visible="False">
                                <AlternatingItemTemplate>
                                    <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("TransID") %>'></asp:Label>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("TransID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PRNo" HeaderText="PRNo" />
                            <asp:BoundField DataField="NamaSite" HeaderText="NamaSite" ReadOnly="True" 
                                SortExpression="NamaSite" />
                            <asp:BoundField DataField="Name" HeaderText="Name" 
                                SortExpression="Name" />
                            <asp:BoundField DataField="Designation" HeaderText="Designation" 
                                SortExpression="Designation" />
                            <asp:BoundField DataField="EndUserLocation" HeaderText="EndUserLocation" 
                                SortExpression="EndUserLocation" />
                            <asp:BoundField DataField="TglTransaksi" HeaderText="TglTransaksi" 
                                SortExpression="TglTransaksi" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Status">
                                <AlternatingItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                        SelectCommand="select a.TransID, PRNo, NamaSite, Name, Designation, a.StorerKey, EndUserLocation, TglTransaksi, case status when 1 then 'Created' when 2 then 'Waiting for Manager Approval' when 4 then 'Waiting for Area Manager Approval' when 5 then 'Approved' when 9 then 'Cancel' end as Status
from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy=b.UserID 
where  (case when charindex('@',PRApproval) &gt; 0 then lower(left(PRApproval,charindex('@',PRApproval)-1)) end =@UserName) 
or   (case when charindex('@',PRApproval1) &gt; 0 then lower(left(PRApproval1,charindex('@',PRApproval1)-1)) end =@UserName) 
and status in (2,4) order by a.TransID desc
">
                        <SelectParameters>
                            <asp:SessionParameter Name="UserName" SessionField="username" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style3">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" 
                        Font-Size="Large" Text="List Barang"></asp:Label>
                            </td>
                            <td class="style3">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" 
                                    CellPadding="4" DataSourceID="SqlDataSource2" EmptyDataText="No Data Selected" 
                                    EnableModelValidation="True" Font-Names="Verdana" Font-Size="Small" 
                                    ForeColor="Black" GridLines="Vertical" BorderStyle="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="PRNo" HeaderText="PRNo" SortExpression="PRNo" 
                                            Visible="False" />
                                        <asp:BoundField DataField="Keterangan" 
                                            HeaderText="Nama Barang" SortExpression="Keterangan" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="KodeBarang" HeaderText="KodeBarang" 
                                            SortExpression="KodeBarang" Visible="False" />
                                        <asp:BoundField DataField="UOM" HeaderText="UOM" 
                                            SortExpression="UOM" />
                                        <asp:BoundField DataField="Qty" 
                                            HeaderText="Qty" SortExpression="Qty" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastPrice" HeaderText="LastPrice" SortExpression="LastPrice" DataFormatString="{0:N0}" >
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstTotPrice" HeaderText="EstTotPrice" SortExpression="EstTotPrice" DataFormatString="{0:N0}" >
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                                        HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
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
                                    Font-Size="Small" Text="Approve" Height="37px" Width="150px" />
                                <asp:Button ID="btnNotApprove" runat="server" Font-Names="Verdana" 
                                    Font-Size="Small" Text="Not Approve" Height="37px" Width="150px" />
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
                        SelectCommand="select PRNo, KodeBarang, UOM, Qty, Keterangan, LastPrice, EstTotPrice from [dbo].[tbATKPRDetails] Where PRNo=@PRNo">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="PRNo" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
