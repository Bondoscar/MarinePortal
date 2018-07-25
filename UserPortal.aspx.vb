Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Partial Class UserPortal
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
            Catch ex As Exception
                lblAlert.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub lnkView_Click(sender As Object, e As EventArgs)
        CheckIfUserAccessStillActive()
        Dim grdrow As GridViewRow = DirectCast(DirectCast(sender, LinkButton).NamingContainer, GridViewRow)
        Dim PushPaySlip As String = grdrow.Cells(6).Text
        Dim mActive As String = grdrow.Cells(8).Text
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
        Dim PushPaySlip As String = grdrow.Cells(6).Text
        Dim mActive As String = grdrow.Cells(8).Text
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

    Private Sub bindGridView()
        Dim DatabaseConnectDatagrid As SqlDataAdapter
        Dim DisplayDataDatagrid As New DataSet
        Dim StrSqlDatagrid As String
        Dim StrConn As String

        If lblCateg.Text = "Broker" Then
            StrSqlDatagrid = "select CompName As Insured, replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium, PolicyNo, CertificateNo As CertNo, CommDate As PostedDate, mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and mUser = '" & lblUsername.Text & "' order by commdate desc "
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            GridView1.DataBind()
        ElseIf lblCateg.Text = "User" Then
            StrSqlDatagrid = "select CompName As Insured, replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium, PolicyNo, CertificateNo As CertNo, CommDate As PostedDate, mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and AcctNo = '" & lblUsername.Text & "' order by commdate desc "
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            GridView1.DataBind()
        End If
    End Sub


    Private Sub FillGrid()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            If lblCateg.Text = "Broker" Then
                StrSqlDatagrid = "select CompName As Insured, replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium, PolicyNo, CertificateNo As CertNo, convert(varchar,(CONVERT(date,Commdate,103)),103) As PostedDate, mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and mUser = '" & lblUsername.Text & "' order by commdate desc "
                StrConn = ConnectionString
                DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                GridView1.DataBind()
            ElseIf lblCateg.Text = "User" Then
                StrSqlDatagrid = "select CompName As Insured, replace(convert(varchar(128), cast(SumInsured as money), 1), '.00', '') As SumInsured,replace(convert(varchar(128), cast(Premium as money), 1), '.00', '') As Premium, PolicyNo, CertificateNo As CertNo, convert(varchar,(CONVERT(date,Commdate,103)),103) As PostedDate, mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and AcctNo = '" & lblUsername.Text & "' order by commdate desc "
                StrConn = ConnectionString
                DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                GridView1.DataBind()
            End If
            
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
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & lblUsername.Text & "' and Reg_Account in('User','Broker') and Reg_Active = 'Active'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lblEmail.Text = rdr("Reg_mail")
                    lblFullName.Text = rdr("Reg_CompName")
                    lblNumber.Text = rdr("Reg_Tel")
                    lblCateg.Text = rdr("Reg_Account")
                    If rdr("Reg_mUser") = "SCIBNG" Then
                        Image1.Visible = True
                    Else
                        Image1.Visible = False
                    End If

                Else
                    ''Response.Redirect("~/ValidateForm.aspx")
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
        bindGridView()
    End Sub

    
   
End Class
