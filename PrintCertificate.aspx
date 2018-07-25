<%@ Page Title="" Language="VB" MasterPageFile="~/PortalMaster.master" AutoEventWireup="false" CodeFile="PrintCertificate.aspx.vb" Inherits="PrintCertificate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 88%; height: 116px;">
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
            <td style="width: 110px; height: 31px;"></td>
            <td style="width: 77px; height: 31px;">User:</td>
            <td style="height: 31px">
                <asp:Label ID="lblUsername" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td style="height: 31px"></td>
            <td style="height: 31px"></td>
        </tr>
        <tr>
            <td style="width: 110px; height: 42px;"></td>
            <td style="width: 77px; height: 42px;">Certificate:</td>
            <td style="height: 42px">
                <asp:TextBox ID="txtCertNo" runat="server" placeholder="Certificate No:"></asp:TextBox>
            </td>
            <td style="height: 42px"></td>
            <td style="height: 42px"></td>
        </tr>
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 77px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Print" Height="29px" Width="124px" BorderStyle="Groove" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <table style="width: 88%">
        <tr>
            <td style="width: 110px">&nbsp;</td>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 155px">
                &nbsp;</td>
            <td style="width: 28px">&nbsp;</td>
            <td style="width: 153px">
                            &nbsp;</td>
            <td>&nbsp;&nbsp;
                </td>
        </tr>
    </table>
    <table style="width: 88%">
        <tr>
            <td style="width: 109px">&nbsp;</td>
            <td style="width: 82px">
                &nbsp;</td>
            <td>
                           
                                &nbsp;</td>
        </tr>
    </table>
     
</asp:Content>

