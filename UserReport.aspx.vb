Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Math
Partial Class UserReport
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim mPeriod As String
    Dim DB As New DBUtility()
    Dim strUsername As String
    Dim mPassword As String
    Public mUpdatePwd, mDeletePwd, mPassw As String
    Private CurrectUser, CurrecPass, CurrecDB As String

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub
    Private Sub FillGrid()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String
            If RadSearch.SelectedValue = "C" Then
                If RadStatus.SelectedValue = "A" Then
                    StrSqlDatagrid = " select Reg_Compname as Insured, Reg_Addr as BusinessAddr, Reg_Business as Occupation, Reg_Tel as Telephone, Reg_Mail As eMail, convert(varchar,(CONVERT(date,Reg_date,103)),103) as Date, Reg_Username as Username from dbo.Profile_Details where Reg_Account = 'User' and Reg_Active = 'Active' and Reg_Date between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by Reg_Date desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
                    GridView1.DataBind()
                ElseIf RadStatus.SelectedValue = "I" Then
                    StrSqlDatagrid = "Reg_Compname As CompanyName, Reg_CompNo As CompanyRegNo, Reg_Addr As BusinessAddr, Reg_Business As Business, Reg_Tel As Telephone, Reg_Mail As eMail, convert(varchar,(CONVERT(date,Reg_date,103)),103) As Reg_Date, convert(varchar,(CONVERT(date,Reg_DOB,103)),103) As DOB, Reg_Username As Username from dbo.Profile_Details where Reg_Account = 'User' and Reg_Active IS NULL and Reg_Date between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by Reg_Date desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
                    GridView1.DataBind()
                End If
            ElseIf RadSearch.SelectedValue = "P" Then
                If RadStatus.SelectedValue = "A" Then
                    StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,SumInsured,Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and CommDate between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by CommDate desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                    GridView1.DataBind()
                ElseIf RadStatus.SelectedValue = "I" Then
                    StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,SumInsured,Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Deactivated'  and CommDate between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by CommDate desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try

    End Sub
    Private Sub bindGridView()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String
            If RadSearch.SelectedValue = "C" Then
                If RadStatus.SelectedValue = "A" Then
                    StrSqlDatagrid = " select Reg_Compname as Insured, Reg_Addr as BusinessAddr, Reg_Business as Occupation, Reg_Tel as Telephone, Reg_Mail As eMail, convert(varchar,(CONVERT(date,Reg_date,103)),103) as Date, Reg_Username as Username from dbo.Profile_Details where Reg_Account = 'User' and Reg_Active = 'Active' and Reg_Date between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by Reg_Date desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
                    GridView1.DataBind()
                ElseIf RadStatus.SelectedValue = "I" Then
                    StrSqlDatagrid = "Reg_Compname As CompanyName, Reg_CompNo As CompanyRegNo, Reg_Addr As BusinessAddr, Reg_Business As Business, Reg_Tel As Telephone, Reg_Mail As eMail, convert(varchar,(CONVERT(date,Reg_date,103)),103) As Reg_Date, convert(varchar,(CONVERT(date,Reg_DOB,103)),103) As DOB, Reg_Username As Username from dbo.Profile_Details where Reg_Account = 'User' and Reg_Active IS NULL and Reg_Date between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by Reg_Date desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
                    GridView1.DataBind()
                End If
            ElseIf RadSearch.SelectedValue = "P" Then
                If RadStatus.SelectedValue = "A" Then
                    StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,SumInsured,Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Activated' and CommDate between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by CommDate desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                    GridView1.DataBind()
                ElseIf RadStatus.SelectedValue = "I" Then
                    StrSqlDatagrid = "select AcctNo As UserName,CompName As Insured,SumInsured,Premium,convert(varchar,(CONVERT(date,Commdate,103)),103) as Date,PolicyNo,CertificateNo,mStatus As Status from dbo.ActivatePolicy where mStatus = 'Deactivated'  and CommDate between '" & txtFrom.Text & "' and '" & txtToDate.Text & "' order by CommDate desc"
                    StrConn = ConnectionString
                    DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
                    DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
                    GridView1.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
                    GridView1.DataBind()
                End If
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                CheckIfUserAccessStillActive()
                ChkUserFormAccess()
                ''mQuery()
                ''FillGrid()
            Catch ex As Exception
                lblAlert.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub btnexcel_Click(sender As Object, e As ImageClickEventArgs) Handles btnexcel.Click
        Try
            If GridView1.Rows.Count.ToString + 1 < 999999 Then
                GridView1.AllowPaging = "False"
                'gv.DataBind()
                Dim tw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=DataExport.xls")
                Response.Charset = ""
                EnableViewState = False
                Controls.Add(frm)
                frm.Controls.Add(GridView1)
                frm.RenderControl(hw)
                Response.Write(tw.ToString())
                Response.End()
            Else
                lblAlert.Text = "Too many rows - Export to Excel not possible"
            End If
        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try
    End Sub
    Sub ChkUserFormAccess()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & lblUsername.Text & "' and Reg_Account = 'Administrator'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    Response.Redirect("~/MyPortal.aspx")
                Else
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        bindGridView()
    End Sub
End Class
