<%@ Page Title="" Language="VB" MasterPageFile="~/UserMaster.master" AutoEventWireup="false" CodeFile="MotorBatchUpload.aspx.vb" Inherits="MotorBatchUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

    <table style="width: 82%">
        <tr>
            <td style="width: 133px; height: 12px;"><b>User Details:</b></td>
            <td style="width: 152px; height: 12px; background-color: #CCCCCC;"></td>
            <td style="height: 12px; width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblAlert" runat="server" style="font-size: x-small; color: #FF3300"></asp:Label>
            </td>
            <td rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px" rowspan="4">
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
            <td style="width: 152px; background-color: #CCCCCC;"><b>GSM Number:</b></td>
            <td style="width: 677px; background-color: #CCCCCC;">
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    <table style="width: 82%">
        <tr>
            <td style="width: 132px">&nbsp;</td>
            <td style="width: 165px">&nbsp;</td>
            <td style="width: 235px">&nbsp;</td>
            <td style="width: 125px">&nbsp;</td>
            <td style="width: 120px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 132px">&nbsp;</td>
            <td style="width: 165px">
                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Text="Select/Unselect All" />
                        </td>
            <td style="width: 235px"> <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Groove" ToolTip="Browse Motor Fleet.." />

                        </td>
            <td style="width: 125px">

<asp:Button ID="btnUpload" runat="server" Text="Preview"

            OnClick="btnUpload_Click" BorderStyle="Groove" Width="120px" /></td>
            <td style="width: 120px">
                <asp:Button ID="btnfleetUp" runat="server" BorderStyle="Groove" Text="Upload" Width="120px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width: 82%">
        <tr>
            <td style="width: 134px; height: 9px; color: #FFFFFF;">
                            XXXXXXXXXXXXXXXX</td>
            <td style="height: 9px; color: #800000;">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Updating Statement. Please wait...
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
        </tr>
        <tr>
            <td style="width: 134px">
                            &nbsp;</td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="325px" ScrollBars="Horizontal" Width="945px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DataGrid ID="GridView2" Runat="server" AllowCustomPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="112px" Width="1200px" Font-Size="Small">
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Wrap="True" Mode="NumericPages" />
                                <ItemStyle BackColor="White" ForeColor="#003399" />
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelection" Runat="server" />
                                            <br />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    
                                </Columns>
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:DataGrid>
                            <asp:GridView ID="GridView1" runat="server" AllowCustomPaging="True" DataKeyNames="PO_LINENO" PageSize="50" SelectedIndex="0" Width="922px" Font-Size="Small" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Wrap="True" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" commandname="Select" Text="Select" visible="False" />
                                </Columns>
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;</td>
            <td>
                            <asp:Label ID="Lblpath" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;</td>
            <td>
                            
               
                            
                <asp:Label ID="lblEmail" runat="server" Visible="False"></asp:Label>
                            
               
                            
                            <asp:Label ID="Lblunitmail" runat="server" Enabled="False" Visible="False"></asp:Label>
                            
               
                            
            </td>
        </tr>
</table>
      <script>
          <asp:Literal id="ltlAlert" runat="server" EnableViewState="False"></asp:Literal>
    </script>
</asp:Content>