<%@ Page Title="Control Panel" Language="VB" MasterPageFile="~/PortalMaster.master" AutoEventWireup="false" CodeFile="AdminControl.aspx.vb" Inherits="AdminControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


    <html>
    <body>
        <div>
            <b>Certificate Control Panel.
            <br />
            </b>
            <table style="width: 100%">
                <tr>
                    <td style="width: 188px">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 100%">
                <tr>
                    <td style="width: 112px">&nbsp;</td>
                    <td>
            <table>
                <tr>
                    <td style="width: 407px" valign="top">
                        <asp:GridView ID="grdVendors" runat="server" AllowPaging="True" OnPageIndexChanging="grdVendors_PageIndexChanging"
                    AutoGenerateColumns="True" DataKeyNames ="CertificateNo" PageSize="15"
                    Width="482px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">

                        <Columns>
                            <asp:ButtonField Text="Select" ButtonType="Button" commandname="Select"/>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                   </asp:GridView>      
                    </td>
                    <td style="width: 430px" valign="top">
                        <table class="auto-style4">
                            <tr>
                                <td style="width: 25px">&nbsp;</td>
                                <td style="width: 121px"><b>Certificate No:</b></td>
                                <td>
                                    <asp:TextBox ID="lblAcctno" runat="server" AutoPostBack="True" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px">&nbsp;</td>
                                <td style="width: 121px"><b>Company Name:</b></td>
                                <td>
                                    <asp:TextBox ID="lblCompName" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;"><b>Address:</b></td>
                                <td>
                                    <asp:TextBox ID="lblAddress" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Telephone:</td>
                                <td>
                                    <asp:TextBox ID="lblTel" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Currency:</td>
                                <td>
                            <asp:DropDownList ID="ddlCurrency" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">Naira</asp:ListItem>
                                <asp:ListItem Value="2">Dollar</asp:ListItem>
                                <asp:ListItem Value="3">Pounds</asp:ListItem>
                                <asp:ListItem Value="4">Euros</asp:ListItem>
                                <asp:ListItem Value="5">Lakhs</asp:ListItem>
                                <asp:ListItem Value="6">Yens</asp:ListItem>
                                <asp:ListItem Value="7">Rands</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired23" runat="server" ControlToValidate="txtSumAssrd" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Exchange Rate:</td>
                                <td>
                            <asp:TextBox ID="txtExRate" runat="server" Width="200px" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Invoice Value:</td>
                                <td>
                            <asp:TextBox ID="txtInvoiceVal" runat="server" AutoPostBack="True" Width="201px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired24" runat="server" ControlToValidate="txtInvoiceVal" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Sum Assured:</td>
                                <td>
                                    <asp:TextBox ID="txtSumAssrd" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired9" runat="server" ControlToValidate="txtSumAssrd" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Premium:</td>
                                <td>
                                    <asp:TextBox ID="txtPremium" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired8" runat="server" ControlToValidate="txtPremium" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Premium Rate:</td>
                                <td>
                                    <asp:TextBox ID="txtpremrate" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired10" runat="server" ControlToValidate="txtpremrate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Conveyance:</td>
                                <td>
                            <asp:DropDownList ID="ddlconvey" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Sea</asp:ListItem>
                                <asp:ListItem>Air</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired19" runat="server" ControlToValidate="ddlconvey" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Clause Type:</td>
                                <td>
                            <asp:DropDownList ID="ddlClause" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Cargo Clause A">Cargo Clause A</asp:ListItem>
                                <asp:ListItem Value="Cargo Clause B">Cargo Clause B</asp:ListItem>
                                <asp:ListItem Value="Cargo Clause C">Cargo Clause C</asp:ListItem>
                                <asp:ListItem Value="Bulk Oil Cargo">Bulk Oil Cargo</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlClause" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Description:</td>
                                <td>
                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDesc" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">From:</td>
                                <td>
                                    <asp:TextBox ID="txtfrom" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired21" runat="server" ControlToValidate="txtfrom" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">To:</td>
                                <td>
                                    <asp:TextBox ID="txtto" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired22" runat="server" ControlToValidate="txtto" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Conditions:</td>
                                <td>
                                    <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Height="58px" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired20" runat="server" ControlToValidate="txtCondition" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Comm. Date:</td>
                                <td>
                                    <asp:TextBox ID="txtCommdate" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                                    (MM/dd/yyyy)</td>
                            </tr>
                            <tr>
                                <td style="width: 25px; font-weight: bold;">&nbsp;</td>
                                <td style="width: 121px; font-weight: bold;">Expiry Date:</td>
                                <td>
                                    <asp:TextBox ID="txtExpDate" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                                    (MM/dd/yyyy)</td>
                            </tr>
                            <tr>
                                <td style="width: 25px">&nbsp;</td>
                                <td style="width: 121px"><b>Status:</b></td>
                                <td>
                            <asp:DropDownList ID="ddlstatus" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Activated">Activated</asp:ListItem>
                                <asp:ListItem Value="Suspended">Suspended</asp:ListItem>
                                <asp:ListItem Value="Deactivated">Deactivated</asp:ListItem>
                                
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlstatus" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px">&nbsp;</td>
                                <td style="width: 121px">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnValidate" runat="server" Text="Update" ValidationGroup="RegisterUserValidationGroup" Width="108px"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px">&nbsp;</td>
                                <td style="width: 121px">&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblUsername" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
              HeaderText="Please correct the following errors:" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br /></td>
                </tr>
            </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 112px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </body>
    </html>
</asp:Content>

