Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net

Partial Class ClaimsDownload
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
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
                mRptConvert()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub CheckIfUserAccessStillActive()
        Try
            CurrectUser = Session("mUser")
            CurrecPass = Session("mpass")
            ''lblUsername.Text = CurrectUser
            If CurrectUser = "" Then
                Response.Redirect("ClientLogin.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mRptConvert()
        Dim FilePath As String = Server.MapPath("~/CUSTODIAN_CLAIM.pdf")
        Dim User As New WebClient()
        Dim FileBuffer As [Byte]() = User.DownloadData(FilePath)
        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If
    End Sub
End Class
