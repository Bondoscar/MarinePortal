<%@ Page Title="" Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="false" CodeFile="ResetPwd.aspx.vb" Inherits="ResetPwd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" style="width: 229px; font-weight: bold;">Reset Password:</td>
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
                            <asp:TextBox ID="txtUsername" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired" runat="server" ControlToValidate="txtUsername" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="width: 164px">Old-Password:</td>
                        <td>
                            <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired0" runat="server" ControlToValidate="txtOldPwd" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 164px">New-Password:</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 164px">Confirm New-Password:</td>
                        <td>
                            <asp:TextBox ID="txtConNewPwd" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtConNewPwd" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConNewPwd" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4" style="width: 164px">&nbsp;</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Reset" Width="128px" ValidationGroup="RegisterUserValidationGroup" />
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

