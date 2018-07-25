<%@ Page Title="" Language="VB" MasterPageFile="~/PortalMaster.master" AutoEventWireup="false" CodeFile="Signup.aspx.vb" Inherits="Signup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
     <table style="width: 100%">
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px"><b>Clients Registration </b></td>
             <td>
                            <asp:Label ID="lblAlert" runat="server"></asp:Label>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td>**Kindly Check the User list below before creating a user.**</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td>
                            <asp:Panel ID="Panel1" runat="server" Height="136px" ScrollBars="Both" Width="854px" style="color: #FFFFFF">
                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" Width="836px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"  >
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
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        </asp:GridView>
                            </asp:Panel>
                        </td>
         </tr>
     </table>
     <table style="width: 100%">
         <tr>
             <td style="width: 151px"><b>Login Details:</b></td>
             <td style="width: 126px">&nbsp;</td>
             <td style="width: 241px">&nbsp;</td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Username:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtUsername" runat="server" MaxLength="20" ToolTip="Account Number" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired2" runat="server" ControlToValidate="txtUsername" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Password:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Access Level:</td>
             <td>
                            <asp:DropDownList ID="ddlAccess" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Administrator</asp:ListItem>
                                <asp:ListItem>User</asp:ListItem>
                                <asp:ListItem>Broker</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlAccess" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Confirm Password:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtConNewPwd" runat="server" TextMode="Password" MaxLength="20" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtConNewPwd" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConNewPwd" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                        </td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px"><b>User Details:</b></td>
             <td style="width: 126px">&nbsp;</td>
             <td style="width: 241px">&nbsp;</td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Name:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtCompName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCompName" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                        </td>
             <td style="width: 126px">Business Address:</td>
             <td>
                            <asp:TextBox ID="txtAddress" runat="server" Height="46px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Occupation:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtOccupation" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOccupation" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Mobile No:</td>
             <td>
                            <asp:TextBox ID="txtTelephone" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelephone" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">E-Mail:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtmail" runat="server" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtmail" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Policy No:</td>
             <td>
                            <asp:TextBox ID="txtPolNum" runat="server" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPolNum" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px"><b>Underwriting Details:</b></td>
             <td style="width: 126px">&nbsp;</td>
             <td style="width: 241px">&nbsp;</td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Convey(Air) Rate:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtAirRate" runat="server" Width="200px" >0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtAirRate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Convey(Sea) Rate:</td>
             <td>
                            <asp:TextBox ID="txtSeaRate" runat="server" Width="200px" >0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtSeaRate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Motor(Comp) Rate:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtMotrate" runat="server" Width="200px" >0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtMotrate" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">&nbsp;</td>
             <td>
                            &nbsp;</td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Business Unit:</td>
             <td style="width: 241px">
                            <asp:DropDownList ID="ddlunit" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Bancassurance@Custodianinsurance.com">Bancassurance</asp:ListItem>
                                <asp:ListItem Value="FinancialInstitutions@Custodianinsurance.com">Financial Institutions</asp:ListItem>
                                <asp:ListItem Value="Manufacturing@Custodianinsurance.com">Manufacturing</asp:ListItem>
                                <asp:ListItem Value="PersonalLines@Custodianinsurance.com">Personal Lines</asp:ListItem>
                                <asp:ListItem Value="Trading@Custodianinsurance.com">Trading &amp; Services </asp:ListItem>
                                <asp:ListItem Value="OilandGas@Custodianinsurance.com">Oil &amp; Gas</asp:ListItem>
                                <asp:ListItem Value="Engineering@Custodianinsurance.com">Engineering</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlunit" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Clause Type:</td>
             <td>
                            <asp:DropDownList ID="ddlClause" runat="server" Width="200px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="Cargo Clause A">Cargo Clause A</asp:ListItem>
                                <asp:ListItem Value="Cargo Clause B">Cargo Clause B</asp:ListItem>
                                <asp:ListItem Value="Cargo Clause C">Cargo Clause C</asp:ListItem>
                                <asp:ListItem Value="Bulk Oil Cargo">Bulk Oil Cargo</asp:ListItem>
                                <asp:ListItem>Nil</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlClause" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">Exclusion:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtExclusion" runat="server" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExclusion" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Excess:</td>
             <td>
                            <asp:TextBox ID="txtExcess" runat="server" Width="200px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtExcess" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">*Tax ID No:</td>
             <td style="width: 241px">
                            <asp:TextBox ID="txtTIN" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="regfieldrequired17" runat="server" ControlToValidate="txtTIN" CssClass="failureNotification" ErrorMessage="*" ToolTip="*" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
             <td style="width: 126px">Show Forex value:</td>
             <td>
                 <asp:CheckBox ID="chkforex" runat="server" />
             </td>
         </tr>
         <tr>
             <td style="width: 151px">&nbsp;</td>
             <td style="width: 126px">&nbsp;</td>
             <td style="width: 241px">
                              
                            <asp:Button ID="btnLogin" runat="server" Height="22px" Text="Submit" Width="107px" ValidationGroup="RegisterUserValidationGroup" /> 
                         
                                <asp:Button ID="btnUpdate" runat="server" Height="22px" Text="Update" Width="107px"  /> 
                         
                                </td>
             <td style="width: 126px">&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
     </table>
     <br />
     <script>
         <asp:Literal id="ltlAlert" runat="server" EnableViewState="False"></asp:Literal>
    </script>
</asp:Content>

