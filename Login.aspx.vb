Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Data
Partial Class Login
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim mPeriod As String
    Dim strUsername As String
    Dim mPassword As String

    Protected Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        Try
            Dim mPassCode As String = txtUserpwd.Text
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & txtUser.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    AlertWindow("User Records Not Found!!!")
                    Exit Sub
                Else
                    If rdr("Reg_pwd") = mPassCode And rdr("Reg_Account") <> "Administrator" Then
                        If Not IsDBNull(rdr("Reg_Active")) Then
                            SaveLoginAccess(txtUser.Text, txtUserpwd.Text)
                            Response.Redirect("~/UserPortal.aspx")
                        Else
                            AlertWindow("Account Not Activated Yet...")
                        End If
                    Else
                        AlertWindow("Wrong Password!!!")
                        Exit Sub
                    End If
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            AlertWindow(ex.Message)
        Finally
        End Try
    End Sub

    Protected Sub BtnAdmin_Click(sender As Object, e As EventArgs) Handles BtnAdmin.Click
        Try
            Dim mPassCode As String = TxtAdminpwd.Text
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & TxtAdmin.Text & "'  and Reg_Account = 'Administrator'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    ''cnn.Close()
                    AlertWindow("Admin Records Not Found!!!")
                    Exit Sub
                Else
                    If rdr("Reg_pwd") = mPassCode And rdr("Reg_Account") = "Administrator" Then
                        SaveLoginAccess(TxtAdmin.Text, TxtAdminpwd.Text)
                        Response.Redirect("~/MyPortal.aspx")
                    Else
                        AlertWindow("Wrong Password!!!")
                        Exit Sub
                    End If
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            AlertWindow(ex.Message)
        Finally
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SaveLoginAccess("", "")
            txtUser.Focus()
            Session.RemoveAll()
            Session.Clear()
            Session.Abandon()
        End If
    End Sub
    Sub SaveLoginAccess(LoginID As String, pASS As String)
        Try
            Session.Add("mUser", LoginID)
            Session.Add("mpass", pASS)
            ''Session.Add("mDatabase", mData)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AlertWindow(ByVal Message As String)
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        ltlAlert.Text = Message
    End Sub
End Class
