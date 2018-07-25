Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Configuration

Partial Class MyPortal
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim mPeriod As String
    Dim strUsername As String
    Dim mPassword As String
    Public mUpdatePwd, mDeletePwd, mPassw As String
    Private CurrectUser, CurrecPass, CurrecDB As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                CheckIfUserAccessStillActive()
                mQuery()
                FillGrid()
                FillGrid2()
            Catch ex As Exception
                lblAlert.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub lnkView_Click(sender As Object, e As EventArgs)
        Dim grdrow As GridViewRow = DirectCast(DirectCast(sender, LinkButton).NamingContainer, GridViewRow)
        Dim PushPaySlip As String = grdrow.Cells(8).Text
        Dim mActive As String = grdrow.Cells(9).Text
        If mActive = "Activated" Then
            Session("mCert") = PushPaySlip
            Dim url As String = "PushCertSlip.aspx"
            ''Dim s As String = "window.open('" & url + "', 'popup_window', 'width=600,height=400,left=100,top=100,resizable=yes');"
            ''ClientScript.RegisterStartupScript(Me.GetType(), "script", s, False)
            Page.ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('PushCertSlip.aspx','_newtab');", True)
        Else
            lblAlert.Text = "Certificate Not Active!!!"
        End If

    End Sub

    Protected Sub lnkView1_Click(sender As Object, e As EventArgs)
        CheckIfUserAccessStillActive()
        Dim grdrow As GridViewRow = DirectCast(DirectCast(sender, LinkButton).NamingContainer, GridViewRow)
        Dim PushPaySlip As String = grdrow.Cells(8).Text
        Dim mActive As String = grdrow.Cells(9).Text
        If mActive = "Activated" Then
            Session("mCert") = PushPaySlip
            Dim url As String = "DebitNoteSlip.aspx"
            ''Dim s As String = "window.open('" & url + "', 'popup_window', 'width=600,height=400,left=100,top=100,resizable=yes');"
            ''ClientScript.RegisterStartupScript(Me.GetType(), "script", s, False)
            Page.ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('DebitNoteSlip.aspx','_newtab');", True)
        Else
            lblAlert.Text = "Certificate Not Active!!!"
        End If

    End Sub
    
    Private Sub FillGrid()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            StrSqlDatagrid = "select Reg_Username As Username, Reg_Compname Insured, Reg_Account as Access_Level, Reg_PolNum as PolicyNo, Reg_Premrate as Rate,Reg_Convey as Conveyance, Reg_clause as Clause_Type, Reg_Active as Status from dbo.Profile_Details where  Reg_Account in ('User', 'Broker') AND Reg_Premrate is not null"
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
            GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
            GridView1.DataBind()

        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try

    End Sub
    Private Sub FillGridDet()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            StrSqlDatagrid = "select Reg_Username As Username, Reg_Compname Insured, Reg_Account as Access_Level, Reg_PolNum as PolicyNo, Reg_Premrate as Rate,Reg_Convey as Conveyance, Reg_clause as Clause_Type, Reg_Active as Status from dbo.Profile_Details where  Reg_Account in ('User', 'Broker') AND Reg_Premrate is not null"
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
            GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
            GridView1.DataBind()

        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try

    End Sub

    Private Sub FillGrid2Det()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String
            ''replace(convert(varchar(128), cast(Premium as money), 1), '.00', '')  ,
            StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' order by CertificateNo desc "
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            GridView2.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            GridView2.DataBind()
        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try

    End Sub
    Private Sub FillGrid2()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String
            ''replace(convert(varchar(128), cast(Premium as money), 1), '.00', '')  ,
            StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' order by CertificateNo desc "
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            GridView2.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            GridView2.DataBind()
        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try

    End Sub
    
    Sub CheckIfUserAccessStillActive()
        Try
            CurrectUser = Session("mUser")
            CurrecPass = Session("mpass")
            lblUsername.Text = CurrectUser
            If CurrectUser = "" Then
                Response.Redirect("Login.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mQuery()
        Try
             Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & lblUsername.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lblEmail.Text = rdr("Reg_mail")
                    lblFullName.Text = rdr("Reg_CompName")
                    lblNumber.Text = rdr("Reg_Tel")
                    ''lblCateg.Text = "Customer"
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AlertWindow(ByVal Message As String)
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        lblAlert.Text = "alert('" & Message & "')"
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        FillGridDet()
    End Sub

    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        FillGrid2Det()
    End Sub
End Class
