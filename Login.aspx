<%@ Page Title="Client LogIn"  Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Login</title>
  
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
<link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

      <link rel="stylesheet" href="assets/css/style.css">
<style>
body {
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
  <div class="pen-title">
  <a href="Default.aspx"><img src="assets/Img/newlogo.png" alt="Marine"></a>
</div>
  
</div>
<!-- Form Module-->
<div class="module form-module">
  <div class="toggle"><i class="fa fa-times fa-pencil"></i>
    <div class="tooltip">Admin</div>
  </div>
  <div class="form">
     <h2>User/Broker Login</h2>
           <asp:TextBox ID="txtUser" runat="server" placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="txtUserpwd" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
      <asp:Button ID="btnUser" runat="server" Text="Login" />  
      <asp:Literal id="ltlAlert" runat="server" EnableViewState="False" ></asp:Literal>
      </div>
 
  <div class="form">
    <h2>Admin Login</h2>
          <asp:TextBox ID="TxtAdmin" runat="server" placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="TxtAdminpwd" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
      <asp:Button ID="BtnAdmin" runat="server" Text="Login" /> 
      </div>
    
</div>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
       
    <script src="js/index.js"></script>
    </form>
</body>
</html>
