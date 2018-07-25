Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Partial Class CancelCert
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
    Public mUpdatePwd, mDeletePwd, mPassw, mCert, mCompany, mUnit As String
    Private CurrectUser, CurrecPass, CurrecDB As String

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("SELECT B.Reg_Unitmail, B.Reg_Compname, A.CertificateNo FROM ActivatePolicy   AS A JOIN Profile_Details AS B ON A.mUser = B.Reg_Username   WHERE A.CertificateNo ='" & txtOldPwd.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    lblError.Text = "certificate Number Not found!!."
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    mCert = rdr("CertificateNo")
                    mCompany = rdr("Reg_Compname")
                    mUnit = rdr("Reg_Unitmail")
                    SendCustodianMail(mUnit, mCert, mCompany)
                    lblError.Text = "Certifcate Is under Process to be cancelled within 24Hrs!!."
                    lblError.ForeColor = System.Drawing.Color.Green
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

    Public Sub SendCustodianMail(ByVal mUnitMail As String, ByVal mCertNo As String, ByVal mCompany As String)
        ''Dim ToAddress As String = txtEmail.Text
        Try
            Dim ToAddress As String = mUnitMail & ", COhaka@Custodianinsurance.com, EIsujeh@Custodianinsurance.com " ''
            Dim mm As New MailMessage("noreply@marine.Custodiansme.com", ToAddress)

            Dim m As String
            m = " Dear Team, " & vbCrLf & _
               " Kindly Help Cancel Certificate No: " & mCertNo & vbCrLf & _
               " From " & UCase(mCompany) & vbCrLf & _
               " As this certificate is no longer required or recognised by Us." & vbCrLf & vbCrLf & _
               " Regards " & vbCrLf & _
               " " & UCase(mCompany)

            mm.Subject = "Cerficate Cancellation On Marine Insurance Portal.."
            mm.Body = m
            mm.IsBodyHtml = False
            Dim smtp As New SmtpClient
            smtp.Send(mm)
        Catch ex As Exception

        End Try

    End Sub
End Class
