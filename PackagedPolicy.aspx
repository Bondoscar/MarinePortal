<%@ Page Title="" Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="PackagedPolicy.aspx.vb" Inherits="PackagedPolicy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
        <table class="auto-style4" >
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 94px">&nbsp;</td>
                        <td style="width: 163px"><b>Generate Certificate:</b></td>
                        <td>
                            <asp:Label ID="LblAlert" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>

                <table style="width: 100%">
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 146px">&nbsp;</td>
                        <td style="width: 298px">**Note: All asterik(*) fields are compulsory.**</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 146px">&nbsp;</td>
                        <td style="width: 298px">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblClient" runat="server" Text="Find Client:" Font-Bold="True" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddlclient" runat="server" Width="250px" AutoPostBack="True" Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px"><b>User Details: </b></td>
                        <td style="width: 112px">Úsername</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtAcctNo" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired2" runat="server" ControlToValidate="txtAcctNo" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Insured Name:</td>
                        <td>
                            <asp:TextBox ID="txtCompName" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired4" runat="server" ControlToValidate="txtCompName" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Occupation:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtOccupation" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired3" runat="server" ControlToValidate="txtOccupation" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            &nbsp;</td>
                        <td style="width: 103px">
                            Telephone:</td>
                        <td>
                            <asp:TextBox ID="txtTelephone" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired6" runat="server" ControlToValidate="txtTelephone" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Email Address:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtEmail" runat="server" Enabled="False" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired7" runat="server" ControlToValidate="txtEmail" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            Address:</td>
                        <td>
                            <asp:TextBox ID="txtBizLocation" runat="server" TextMode="MultiLine" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired9" runat="server" ControlToValidate="txtBizLocation" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">&nbsp;</td>
                        <td style="width: 221px">
                            &nbsp;</td>
                        <td style="width: 103px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px"><b>Goods Details:</b></td>
                        <td style="width: 112px">Conveyance:</td>
                        <td style="width: 221px">
                            <asp:DropDownList ID="ddlconvey" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Sea</asp:ListItem>
                                <asp:ListItem>Air</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired19" runat="server" ControlToValidate="ddlconvey" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            *Description:</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired14" runat="server" ControlToValidate="txtDesc" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Exclusion:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtExclusion" runat="server" Enabled="False" Width="200px" >AS PER POLICY CONDITIONS</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExclusion" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            Clause Type:</td>
                        <td>
                            <asp:DropDownList ID="ddlClause" runat="server" Enabled="False" Width="200px">
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
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*From:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtFrom" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired15" runat="server" ControlToValidate="txtFrom" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            *To:</td>
                        <td>
                            <asp:TextBox ID="txtTo" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired16" runat="server" ControlToValidate="txtTo" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Tax ID No:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtTIN" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired17" runat="server" ControlToValidate="txtTIN" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            Policy No:</td>
                        <td>
                            <asp:TextBox ID="txtPolnum" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired18" runat="server" ControlToValidate="txtPolnum" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Excess</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtExcess" runat="server" Width="200px" >AS PER POLICY CONDITIONS</asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired22" runat="server" ControlToValidate="txtExcess" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">&nbsp;</td>
                        <td style="width: 221px">&nbsp;</td>
                        <td style="width: 103px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px"><b>Payment details:</b></td>
                        <td style="width: 112px">Currency:</td>
                        <td style="width: 221px">
                            <asp:DropDownList ID="ddlCurrency" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">Naira</asp:ListItem>
                                <asp:ListItem Value="2">Dollar</asp:ListItem>
                                <asp:ListItem Value="3">Pounds</asp:ListItem>
                                <asp:ListItem Value="4">Euros</asp:ListItem>
                                <asp:ListItem Value="5">Lakhs</asp:ListItem>
                                <asp:ListItem Value="6">Yens</asp:ListItem>
                                <asp:ListItem Value="7">Rands</asp:ListItem>
                                <asp:ListItem Value="8">RMB</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired20" runat="server" ControlToValidate="ddlCurrency" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Exchange Rate:</td>
                        <td>
                            <asp:TextBox ID="txtExRate" runat="server" Width="200px"  AutoPostBack="True"></asp:TextBox>
                            <asp:CheckBox ID="chkloading" runat="server" Text="Apply CI &amp; F Loading" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Invoice Value:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtInvoiceVal" runat="server" AutoPostBack="True" Width="201px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired21" runat="server" ControlToValidate="txtSumAssured" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Premium
                            Rate:</td>
                        <td>
                            <asp:TextBox ID="txtPremRate" runat="server" Enabled="False" AutoPostBack="True" Width="200px" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired13" runat="server" ControlToValidate="txtPremRate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Insured Value(N):</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtSumAssured" runat="server" AutoPostBack="True" Width="201px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired10" runat="server" ControlToValidate="txtSumAssured" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">*Premium(N):</td>
                        <td>
                            <asp:TextBox ID="txtPremium" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPremium" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Trans Date:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtApplyDate" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                        </td>
                        <td style="width: 103px">*Start Date:</td>
                        <td>
                            <asp:TextBox ID="txtCommDate" runat="server" Width="200px" ></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FrmPop" TargetControlID="txtCommDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCommDate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            (MM/dd/yyyy)</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">&nbsp;</td>
                        <td style="width: 221px">
                            &nbsp;</td>
                        <td style="width: 103px">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 96px">&nbsp;</td>
                        <td>
                            <b>NB: Premium rate should be agreed with custodian before issue of certificate.</b></td>
                    </tr>
                    <tr>
                        <td style="width: 96px">&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ChkSign" runat="server" Text="Customer understands and accept all the policy terms, conditions and exceptions associated with this marine insurance." Font-Size="Small" /></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 335px">
                            <asp:Label ID="lblCertNo" runat="server"></asp:Label>
                        </td>
                        <td style="width: 321px">
                            <asp:Button ID="BtnSave" runat="server" Text="Submit" ValidationGroup="RegisterUserValidationGroup" Width="151px" BorderStyle="Groove" />
                            <asp:Button ID="BtnPrint" runat="server" Text="Print Certificate" ValidationGroup="RegisterUserValidationGroup" Width="151px" BorderStyle="Groove" Visible="False" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Lblunitmail" runat="server" Enabled="False" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblUsername" runat="server" Visible="False"></asp:Label>
                        &nbsp;
                <asp:Label ID="lblCateg" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 335px">
                            &nbsp;</td>
                        <td style="width: 321px">&nbsp;</td>
                        <td>
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    <script>
        <asp:Literal id="ltlAlert" runat="server" EnableViewState="False"></asp:Literal>
    </script>
    
</asp:Content>

