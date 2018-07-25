<%@ Page Title="" Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="false" CodeFile="CancelCert.aspx.vb" Inherits="CancelCert" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" style="width: 229px; font-weight: bold;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 229px; font-weight: bold;">Certificate Cancellation:</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 229px">&nbsp;</td>
            <td>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5" style="width: 164px">UserName:</td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired" runat="server" ControlToValidate="txtUsername" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 164px">Certificate Number:</td>
                        <td>
                            <asp:TextBox ID="txtOldPwd" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired0" runat="server" ControlToValidate="txtOldPwd" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 164px">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4" style="width: 164px">&nbsp;</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Cancel Cert." Width="128px" ValidationGroup="RegisterUserValidationGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" style="width: 164px">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

