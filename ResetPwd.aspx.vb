Imports System.Data.SqlClient
Imports System.Data
Partial Class ResetPwd
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim mPeriod As String
    Dim strUsername As String
    Dim mPassword As String
    Dim DB As New DBUtility()
    Public mUpdatePwd, mDeletePwd, mPassw As String
    Private CurrectUser, CurrecPass, CurrecDB As String

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & txtUsername.Text & "' ", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    lblError.Text = "Username Not found!!."
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    If rdr("Reg_Pwd") = txtOldPwd.Text Then
                        cnn.Close()
                        strSQL = "UPDATE Profile_Details SET Reg_Pwd='" & txtConNewPwd.Text & "' where Reg_Username='" & txtUsername.Text & "'"
                        DB.UpdateDB(strSQL)
                        lblError.Text = "Password Updated Successfully!!."
                        lblError.ForeColor = System.Drawing.Color.Green
                    Else
                        lblError.Text = "Enter correct old password!!."
                        lblError.ForeColor = System.Drawing.Color.Red
                    End If

                End If
                cnn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Sub CheckIfUserAccessStillActive()
        Try
            CurrectUser = Session("mUser")
            CurrecPass = Session("mpass")
            txtUsername.Text = CurrectUser
            If CurrectUser = "" Then
                Response.Redirect("ClientLogin.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                CheckIfUserAccessStillActive()
                ''mQuery()
            Catch ex As Exception
                ''lblAlert.Text = ex.Message
            End Try
        End If
    End Sub
End Class
