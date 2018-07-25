<%@ Page Title="Admin Report" Language="VB" MasterPageFile="~/PortalMaster.master" AutoEventWireup="false" CodeFile="AdminReport.aspx.vb" Inherits="AdminReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 88%">
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 77px">&nbsp;</td>
            <td>
                <asp:Label ID="lblAlert" runat="server" style="font-size: x-small; color: #FF3300"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 110px">
    <b>Admin Reports:
    </b>
            </td>
            <td style="width: 77px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 77px">User:</td>
            <td>
                <asp:Label ID="lblUsername" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 77px">Search By: </td>
            <td>
                <asp:RadioButtonList ID="RadSearch" runat="server" RepeatDirection="Horizontal" Width="303px">
                    <asp:ListItem Value="C">Clients</asp:ListItem>
                    <asp:ListItem Value="P">Certificates</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 77px">Status</td>
            <td>
                <asp:RadioButtonList ID="RadStatus" runat="server" RepeatDirection="Horizontal" Width="280px">
                    <asp:ListItem Value="A">Active</asp:ListItem>
                    <asp:ListItem Value="I">In-Active</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width: 88%">
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 80px">From:</td>
            <td style="width: 155px">
                            <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                         <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FrmPop" TargetControlID="txtFrom">
                            </asp:CalendarExtender>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFrom" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
            <td style="width: 28px">To:</td>
            <td style="width: 153px">
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                         <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="FrmPop0" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
            <td>&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Browse" />
            </td>
        </tr>
    </table>
    <table style="width: 88%">
        <tr>
            <td style="width: 109px">&nbsp;</td>
            <td style="width: 82px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 109px">&nbsp;</td>
            <td style="width: 82px">
                <asp:ImageButton ID="btnexcel" runat="server" Height="16px" ImageUrl="~/demo/2.jpg" Width="28px" />
            </td>
            <td>
                           
                                <asp:Panel ID="Panel1" runat="server" Height="236px" ScrollBars="Both" Width="790px">
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="775px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                           
            </td>
        </tr>
    </table>
     
</asp:Content>

