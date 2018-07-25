Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions

Partial Class PushCertSlip
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String, mCompanyName As String, mStaffId As String
    Dim gnStReportDay, gnStReportYear, gnStReportMonth, gnEnReportDay, gnEnReportYear, gnEnReportMonth, gnReportTitle As String
    Dim crpt As ReportDocument
    Private CurrectUser, CurrecPass, CurrecDB, CertificateNo As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            ''CheckIfUserAccessStillActive()
            mRptConvert()
        End If
    End Sub
    Private Sub mRptConvert()

        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from ActivatePolicy where CertificateNo='" & Trim(Session("mCert")) & "' and mRegNo is null", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    crpt = New ReportDocument
                    crpt.Load(Server.MapPath("CertificatePrint.rpt"))
                    crpt.SetDatabaseLogon("CustOnline", "Custodian@123", "mssql.custodiansme.com,1500", "CUSTODIANONLINE")
                    crpt.SetParameterValue("CertificateNo", Trim(Session("mCert")))
                    crpt.PrintOptions.PaperSize = PaperSize.PaperA4
                    CrystalPremium.ReportSource = crpt
                    crpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "CertificatePrint.rpt")
                    crpt.Refresh()
                Else
                    crpt = New ReportDocument
                    crpt.Load(Server.MapPath("MotorCertificate.rpt"))
                    crpt.SetDatabaseLogon("CustOnline", "Custodian@123", "mssql.custodiansme.com,1500", "CUSTODIANONLINE")
                    crpt.SetParameterValue("CertificateNo", Trim(Session("mCert")))
                    ''crpt.PrintOptions.PaperSize = PaperSize.PaperA4
                    CrystalPremium.ReportSource = crpt
                    crpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "MotorCertificate.rpt")
                    crpt.Refresh()
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
            If CurrectUser = "" Then
                Response.Redirect("Default.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SendMail()

        Dim mail As New MailMessage()
        mail.From = New MailAddress("Oadeojo@CustodianInsurance.com")
        mail.To.Add("Canerobi@CustodianInsurance.com")
        ''mail.Subject = "" & ddlMonth.SelectedItem.Text & " Salary Payslip"
        mail.Body = "Kindly Find Attached This Month PaySlip.."
        Dim lFileName As String = "C:\PaySlip.pdf"
        Dim att As New Attachment(lFileName)
        mail.Attachments.Add(att)
        'send the message
        Dim smtp As New SmtpClient("192.168.10.17") 'SMTP Server
        smtp.Send(mail)
    End Sub
    
End Class
