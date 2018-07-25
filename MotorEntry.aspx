<%@ Page Title="Motor Certificate." Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="false" CodeFile="MotorEntry.aspx.vb" Inherits="MotorEntry" %>
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
                        <td style="width: 244px" rowspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Files/scib.png" Visible="False" />
                        </td>
                        <td style="width: 298px">**Note: All asterik(*) fields are compulsory.**</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
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
                        <td style="width: 112px">Insured Name:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtAcctNo" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired2" runat="server" ControlToValidate="txtAcctNo" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">PolicyHolder:</td>
                        <td>
                            <asp:TextBox ID="txtCompName" runat="server" Width="200px"></asp:TextBox>
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
                        <td style="width: 124px"><b>Vehicle Details:</b></td>
                        <td style="width: 112px">*Type of Cover</td>
                        <td style="width: 221px">
                            <asp:DropDownList ID="ddlcover" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="C">Comprehensive</asp:ListItem>
                                <asp:ListItem Value="TP">Third Party</asp:ListItem>
                                <asp:ListItem Value="TT">Third Party and Theft</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired19" runat="server" ControlToValidate="ddlcover" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            *Type of Usage:</td>
                        <td>
                            <asp:DropDownList ID="ddlUsage" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="P">Private Motor</asp:ListItem>
                                <asp:ListItem Value="C">Commercial Motor</asp:ListItem>
                                <asp:ListItem Value="M">Motor Cycle</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired14" runat="server" ControlToValidate="ddlUsage" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Make of Vehicle</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtmake" runat="server" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtmake" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            *Chasis No:</td>
                        <td>
                            <asp:TextBox ID="txtChasis" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired16" runat="server" ControlToValidate="txtChasis" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Year of Make:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtYearMake" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired15" runat="server" ControlToValidate="txtYearMake" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            *Reg No:</td>
                        <td>
                            <asp:TextBox ID="txtRegNo" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired17" runat="server" ControlToValidate="txtRegNo" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Policy No:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtPolnum" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired18" runat="server" ControlToValidate="txtPolnum" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                        <td style="width: 124px"><b>Payment Details:</b></td>
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
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired20" runat="server" ControlToValidate="ddlCurrency" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Exchange Rate:</td>
                        <td>
                            <asp:TextBox ID="txtExRate" runat="server" Width="200px" TextMode="Number" AutoPostBack="True"></asp:TextBox>
                            <asp:CheckBox ID="chkloading" runat="server" Text="Apply CI &amp; F Loading" AutoPostBack="True" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Vehicle Value:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtInvoiceVal" runat="server" Width="201px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired21" runat="server" ControlToValidate="txtSumAssured" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Premium
                            Rate:</td>
                        <td>
                            <asp:TextBox ID="txtPremRate" runat="server" Enabled="False" Width="200px" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired13" runat="server" ControlToValidate="txtPremRate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Start Date:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtCommDate" runat="server" Width="200px" ></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="FrmPop" TargetControlID="txtCommDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCommDate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">Cover Period:</td>
                        <td>
                            <asp:DropDownList ID="ddlCoverPeriod" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">Yearly</asp:ListItem>
                                <asp:ListItem Value="2">Half-Yearly</asp:ListItem>
                                <asp:ListItem Value="3">Quaterly</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="regfieldrequired22" runat="server" ControlToValidate="ddlCoverPeriod" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">Insured Value(N):</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtSumAssured" runat="server" AutoPostBack="True" Width="201px" ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired10" runat="server" ControlToValidate="txtSumAssured" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">*Premium(N):</td>
                        <td>
                            <asp:TextBox ID="txtPremium" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPremium" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        &nbsp;
                            <asp:Button ID="BtnCalc" runat="server" BorderStyle="Groove" Text="Prem Calc." />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*End Date </td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txteXPDate" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                             <asp:CalendarExtender ID="txtCommDate0_CalendarExtender" runat="server" PopupButtonID="FrmPop" TargetControlID="txteXPDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txteXPDate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
                        <td style="width: 103px">Trans Date:</td>
                        <td>
                            <asp:TextBox ID="txtApplyDate" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">&nbsp;</td>
                        <td style="width: 124px">&nbsp;</td>
                        <td style="width: 112px">*Credit Note:</td>
                        <td style="width: 221px">
                            <asp:TextBox ID="txtCreditNote" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired23" runat="server" ControlToValidate="txtCreditNote" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 103px">*PRN No:</td>
                        <td>
                            <asp:TextBox ID="txtPRNNote" runat="server" Width="200px"></asp:TextBox>
                        </td>
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
                        <td style="width: 330px">
                            <asp:Label ID="lblCertNo" runat="server"></asp:Label>
                        </td>
                        <td style="width: 337px">
                            <asp:Button ID="BtnSave" runat="server" Text="Submit" ValidationGroup="RegisterUserValidationGroup" Width="151px" BorderStyle="Groove" />
                        &nbsp;<asp:Button ID="BtnPrint" runat="server" Text="Print Certificate" ValidationGroup="RegisterUserValidationGroup" Width="151px" BorderStyle="Groove" Visible="False" />
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
                        <td style="width: 330px">
                            <asp:Label ID="lblbrokermail" runat="server" Visible="False" ></asp:Label>
                        </td>
                        <td style="width: 337px">&nbsp;</td>
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
