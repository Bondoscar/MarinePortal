<%@ Page Title="My PortalPage" Language="VB" MasterPageFile="~/PortalMaster.master" AutoEventWireup="false" CodeFile="MyPortal.aspx.vb" Inherits="MyPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 140px; height: 12px;"><b>User Details:</b></td>
            <td style="width: 152px; height: 12px; background-color: #CCCCCC;"></td>
            <td style="height: 12px; width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblAlert" runat="server" style="font-size: x-small; color: #FF3300"></asp:Label>
            </td>
            <td rowspan="6">
                <img alt="" src="Files/person.jpe" style="width: 201px; height: 143px" /></td>
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;</td>
            <td style="width: 152px"><b>Username:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblUsername" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;</td>
            <td style="width: 152px; background-color: #CCCCCC;"><b>Company Name:</b></td>
            <td style="width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblFullName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;</td>
            <td style="width: 152px"><b>User Category:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblCateg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;</td>
            <td style="width: 152px; background-color: #CCCCCC;"><b>Email Address:</b></td>
            <td style="width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;</td>
            <td style="width: 152px"><b>GSM Number:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="width: 141px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">
                            <asp:LinkButton ID="lblFire" runat="server" Font-Bold="True">Active Users</asp:LinkButton>
                        </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">&nbsp;</td>
            <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="968px">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                             
                        </asp:GridView>
                    </td>
        </tr>
        <tr>
            <td style="width: 141px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">
                            <asp:LinkButton ID="lblFire0" runat="server" Font-Bold="True">Active Certificate</asp:LinkButton>
                        </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">
                            &nbsp;</td>
            <td>
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView2_PageIndexChanging" CellPadding="4" Width="967px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"  >
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                             <Columns>
                                    <asp:TemplateField HeaderText="Cetificate">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click">Certificate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DebitNote">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView1" OnClick="lnkView1_Click">DebitNote</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        </asp:GridView>
                    </td>
        </tr>
    </table>
<table class="auto-style4">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    </table>
    <script>
        <asp:Literal id="ltlAlert" runat="server" EnableViewState="False"></asp:Literal>
    </script>
</asp:Content>

