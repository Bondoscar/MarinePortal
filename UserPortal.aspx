<%@ Page Title="" Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="false" CodeFile="UserPortal.aspx.vb" Inherits="UserPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 82%">
        <tr>
            <td style="width: 120px; height: 12px;"><b>User Details:</b></td>
            <td style="width: 152px; height: 12px; background-color: #CCCCCC;"></td>
            <td style="height: 12px; width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblAlert" runat="server" style="font-size: x-small; color: #FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 120px" rowspan="4">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Files/scib.png" Visible="False" />
            </td>
            <td style="width: 152px"><b>Username:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblUsername" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 152px; background-color: #CCCCCC;"><b>Company Name:</b></td>
            <td style="width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblFullName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 152px"><b>User Category:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblCateg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 152px; background-color: #CCCCCC;"><b>Email Address:</b></td>
            <td style="width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 120px">&nbsp;</td>
            <td style="width: 152px"><b>GSM Number:</b></td>
            <td style="width: 677px">
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 82%">
        <tr>
            <td style="width: 137px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 137px">
                            <asp:LinkButton ID="lblFire" runat="server" Font-Bold="True">Certificates</asp:LinkButton>
                        </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 137px">&nbsp;</td>
            <td><b>Active Certificates</b></td>
        </tr>
        <tr>
            <td style="width: 137px; color: #FFFFFF;">&nbsp;</td>
            <td>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4"  Width="946px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
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
        <tr>
            <td style="width: 137px; color: #FFFFFF;">xxxxxxxxxxxxxxxxxxx</td>
            <td>
                            &nbsp;</td>
        </tr>
</table>
</asp:Content>

