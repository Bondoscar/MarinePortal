Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Configuration
Partial Class PrintCertificate
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
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If txtCertNo.Text <> "" Then
                Session("mCert") = LTrim(txtCertNo.Text)
                Dim url As String = "PushCertSlip.aspx"
                ''Dim s As String = "window.open('" & url + "', 'popup_window', 'width=600,height=400,left=100,top=100,resizable=yes');"
                ''ClientScript.RegisterStartupScript(Me.GetType(), "script", s, False)
                Page.ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('PushCertSlip.aspx','_newtab');", True)
            Else
                lblAlert.Text = "Enter Certificate"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AlertWindow(ByVal Message As String)
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        lblAlert.Text = "alert('" & Message & "')"
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckIfUserAccessStillActive()
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
End Class
