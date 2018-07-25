<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PushCertSlip.aspx.vb" Inherits="PushCertSlip" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate</title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="CrystalPremium" runat="server" AutoDataBind="true" />

    
    </div>
    </form>
</body>
</html>
