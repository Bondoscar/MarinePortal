Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration
Imports System.Data.OleDb
Imports System
Imports System.IO

Partial Class MotorBatchUpload
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
    Dim mFl_InsName, mFl_PolHolder, mFl_PolNum, mFl_TypeCover, mFl_TypeUsage, mFl_VehMake, mFl_VehYrMake, mFl_VehChassis, mFl_RegNo, mFl_CommDate As String
    Dim mFl_Expdate, mFl_SumIns, mFl_Rate, mFl_Premium, mFl_CreditNote, mFl_PRNNo, mFl_Username, mFl_UploadDate, mFl_CertificateNo As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                btnfleetUp.Attributes.Add("onclick", "if(confirm('Are you sure you want to Load this Fleet(s)? Certificate is Issued Immediately. PLEASE WAIT UPLOAD CAN TAKE SOMETIME!!!..')){}else{return false}")
                CheckIfUserAccessStillActive()
                mQuery()
            Catch ex As Exception
                AlertWindow(ex.Message)
            End Try
        End If
    End Sub
    Sub CheckIfUserAccessStillActive()
        Try
            CurrectUser = Session("mUser")
            CurrecPass = Session("mpass")
            lblUsername.Text = UCase(CurrectUser)
            If CurrectUser = "" Then
                Response.Redirect("Login.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mQuery()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & lblUsername.Text & "' and Reg_Account = 'Broker' and Reg_Active = 'Active'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lblEmail.Text = rdr("Reg_mail")
                    lblFullName.Text = rdr("Reg_CompName")
                    lblNumber.Text = rdr("Reg_Tel")
                    lblCateg.Text = rdr("Reg_Account")
                    Lblunitmail.Text = rdr("Reg_Unitmail")
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

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try
            'If FileUpload1.HasFile Then
            '    Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            '    Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            '    Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            '    Dim FilePath As String = Server.MapPath("Files/" & FileUpload1.FileName)
            '    FileUpload1.SaveAs(Server.MapPath("Files/" & FileUpload1.FileName))
            '    ''FileUpload1.SaveAs(FilePath)
            '    Import_To_Grid(FilePath, Extension, "Yes")
            'End If

            If FileUpload1.HasFile Then
                Dim strFileNameOnly As String
                Dim intFileNameLength As Integer
                Dim strFileNamePath As String
                Dim Extension As String = Path.GetExtension(FileUpload1.FileName)
                strFileNamePath = Server.MapPath("Files/" & FileUpload1.FileName)
                intFileNameLength = InStr(1, StrReverse(strFileNamePath), "\")
                strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)
                FileUpload1.SaveAs(Server.MapPath("Files/" & FileUpload1.FileName))
                Import_To_Grid(strFileNamePath, Extension, "Yes")
            End If
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try

    End Sub

    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Try
            Dim conStr As String = ""
            Select Case Extension
                Case ".xls"
                    'Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString()
                    Exit Select
                Case ".xlsx"
                    'Excel 07
                    conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString()
                    Exit Select
            End Select
            conStr = String.Format(conStr, FilePath, isHDR)
            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim dt As New DataTable()
            cmdExcel.Connection = connExcel
            'Get the name of First Sheet
            connExcel.Open()
            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
            connExcel.Close()
            'Read Data from First Sheet
            connExcel.Open()
            cmdExcel.CommandText = "SELECT * From [" & SheetName & "] WHERE PREMIUM IS NOT NULL "
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            connExcel.Close()
            'Bind Data to GridView
            GridView2.Caption = Path.GetFileName(FilePath)
            GridView2.DataSource = dt
            GridView2.DataBind()
        Catch ex As Exception
            AlertWindow(ex.Message)
            'AlertWindow("Please Upload Fleet(s) Sample excel format(.xls, .xlsx !!!.)")
        End Try
    End Sub

    Protected Sub chkSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelect.CheckedChanged
        Dim i As Double
        If chkSelect.Checked = True Then
            For i = 0 To GridView2.Items.Count - 1
                Dim Checkbox As CheckBox = CType(GridView2.Items(i).FindControl("chkSelection"), CheckBox)
                ''Dim QtyText As TextBox = CType(GridView2.Items(i).FindControl("txtQtyReq"), TextBox)
                Checkbox.Checked = True
                ''QtyText.Enabled = True
                ''QtyText.Text = GridView2.Items(i).Cells(10).Text
                ''If QtyText.Text > GridView2.Items(i).Cells(10).Text Then
                ''QtyText.ForeColor = Drawing.Color.Red
                ''End If
            Next
        Else
            For i = 0 To GridView2.Items.Count - 1
                Dim Checkbox As CheckBox = CType(GridView2.Items(i).FindControl("chkSelection"), CheckBox)
                ''Dim QtyText As TextBox = CType(GridView2.Items(i).FindControl("txtQtyReq"), TextBox)
                Checkbox.Checked = False
                ''QtyText.Text = ""
                ''QtyText.Enabled = False
            Next
        End If
    End Sub


    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            Dim FileName As String = GridView1.Caption
            Dim Extension As String = Path.GetExtension(FileName)
            Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            Import_To_Grid(FilePath, Extension, "Yes")
            GridView1.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            ''StrSqlDatagrid = "select LINE_NO AS PO_LINENO, CONTRACT, PART_NO, REMARKS AS WDR, Project_id AS PROJECT_ID, QTY_REQ, ROWVERSION AS STATUS_DATE, ROWSTATE, MRF_LINE_NO AS LINE_NO from IFSAPP.C_E_MATERIAL_REQ_LINE_TAB where MRF = '" & txteMRFID.Text & "' ORDER BY PO_LINENO"

            StrConn = ConfigurationSettings.AppSettings("Strconn")
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "IFSAPP.C_E_MATERIAL_REQ_LINE_TAB")
            GridView1.DataSource = DisplayDataDatagrid.Tables("IFSAPP.C_E_MATERIAL_REQ_LINE_TAB").DefaultView
            GridView1.DataBind()
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try
    End Sub
    Protected Sub btnfleetUp_Click(sender As Object, e As EventArgs) Handles btnfleetUp.Click
        Try
            ''strSQL = "Delete from FleetUpload"
            ''DB.UpdateDB(strSQL)

            Dim i As Double
            For i = 0 To GridView2.Items.Count - 1
                Dim Checkbox As CheckBox = CType(GridView2.Items(i).FindControl("chkSelection"), CheckBox)

                If Checkbox.Controls.Count - 0 Then
                    AlertWindow("Please Check the Line Item(s) to hold")
                    Exit Sub
                End If

                If Checkbox.Checked = True Then
                    'Dim QtyText As TextBox = CType(GridView2.Items(i).FindControl("txtQtyReq"), TextBox)
                    mFl_InsName = Trim(GridView2.Items(i).Cells(1).Text)
                    mFl_PolHolder = Trim(GridView2.Items(i).Cells(2).Text)
                    mFl_PolNum = Trim(GridView2.Items(i).Cells(3).Text)
                    mFl_TypeCover = DB.funcCoverType(UCase(GridView2.Items(i).Cells(4).Text))
                    mFl_TypeUsage = DB.funcUsage(UCase(GridView2.Items(i).Cells(5).Text))
                    mFl_VehMake = Trim(GridView2.Items(i).Cells(6).Text)
                    mFl_VehYrMake = GridView2.Items(i).Cells(7).Text
                    mFl_VehChassis = GridView2.Items(i).Cells(8).Text
                    mFl_RegNo = GridView2.Items(i).Cells(9).Text
                    mFl_CommDate = CDate(GridView2.Items(i).Cells(10).Text)
                    mFl_Expdate = CDate(GridView2.Items(i).Cells(11).Text)
                    mFl_SumIns = GridView2.Items(i).Cells(12).Text.Replace(",", "")
                    mFl_Rate = GridView2.Items(i).Cells(13).Text.Replace(",", "")
                    mFl_Premium = GridView2.Items(i).Cells(14).Text.Replace(",", "")
                    mFl_CreditNote = GridView2.Items(i).Cells(15).Text
                    mFl_PRNNo = GridView2.Items(i).Cells(16).Text
                    mFl_Username = lblUsername.Text
                    mFl_UploadDate = CDate(Now)
                    mFl_CertificateNo = "02-" & NewRec()
                    Try
                        ''cmd.Parameters.AddWithValue("due_date_", CDate(lbldate.Text).AddDays(4))

                        Using cnn As New SqlConnection(ConnectionString)
                            Dim strSQL As String

                            cmd = New SqlCommand("SELECT * FROM ActivatePolicy WHERE mRegNo='" & mFl_RegNo & "' AND ExpiryDate > '" & mFl_CommDate & "'", cnn)
                            cnn.Open()
                            rdr = cmd.ExecuteReader
                            If Not rdr.Read Then
                                cnn.Close()
                                '' strSQL &= "AcctNo,PolicyNo,SumInsured,Premium,CommDate,mCovertype,mTypeUsage,"
                                ''strSQL &= "mYearmake,mChassis,mRegNo,mVehiclemake,CertificateNo,ActiveDate,ExpiryDate,mStatus,Reg_Condition,mUser,mCreditNote,mPRN,ChkSign)"

                                strSQL = "INSERT INTO ActivatePolicy("
                                strSQL &= "AcctNo, CertificateNo, mStatus, ChkSign, CompName, PolicyNo, mCovertype, mTypeUsage, mVehiclemake, mYearmake, mChassis, mRegNo, ActiveDate, "
                                strSQL &= "ExpiryDate, SumInsured, PremRt, Premium, mCreditNote, mPRN, mUser, CommDate)"
                                strSQL &= "VALUES (@AcctNo, @CertificateNo, @mStatus, @ChkSign, @CompName, @PolicyNo, @mCovertype, @mTypeUsage, @mVehiclemake, @mYearmake, @mChassis, @mRegNo, @ActiveDate, "
                                strSQL &= "@ExpiryDate, @SumInsured, @Rate, @Premium, @mCreditNote, @mPRN, @mUser, @CommDate)"
                                Dim cmd As New SqlCommand(strSQL, cnn)
                                cmd.Parameters.AddWithValue("@AcctNo", mFl_InsName)
                                cmd.Parameters.AddWithValue("@CertificateNo", mFl_CertificateNo)
                                cmd.Parameters.AddWithValue("@mStatus", "Activated")
                                cmd.Parameters.AddWithValue("@ChkSign", "A")
                                cmd.Parameters.AddWithValue("@CompName", mFl_PolHolder)
                                cmd.Parameters.AddWithValue("@PolicyNo", mFl_PolNum)
                                cmd.Parameters.AddWithValue("@mCovertype", mFl_TypeCover)
                                cmd.Parameters.AddWithValue("@mTypeUsage", mFl_TypeUsage)
                                cmd.Parameters.AddWithValue("@mVehiclemake", mFl_VehMake)
                                cmd.Parameters.AddWithValue("@mYearmake", mFl_VehYrMake)
                                cmd.Parameters.AddWithValue("@mChassis", mFl_VehChassis)
                                cmd.Parameters.AddWithValue("@mRegNo", mFl_RegNo)
                                cmd.Parameters.AddWithValue("@ActiveDate", mFl_CommDate)
                                cmd.Parameters.AddWithValue("@ExpiryDate", mFl_Expdate)
                                cmd.Parameters.AddWithValue("@SumInsured", mFl_SumIns)
                                cmd.Parameters.AddWithValue("@Rate", mFl_Rate)
                                cmd.Parameters.AddWithValue("@Premium", mFl_Premium)
                                cmd.Parameters.AddWithValue("@mCreditNote", mFl_CreditNote)
                                cmd.Parameters.AddWithValue("@mPRN", mFl_PRNNo)
                                cmd.Parameters.AddWithValue("@mUser", mFl_Username)
                                cmd.Parameters.AddWithValue("@CommDate", mFl_UploadDate)
                                Try
                                    cnn.Open()
                                    Dim Recnt As Integer = cmd.ExecuteNonQuery()
                                    If Recnt = 1 Then
                                        SendClientMail()
                                        SendCustodianMail()
                                        AlertWindow("Fleet(s) Loaded Successfully!!!..")
                                    Else
                                        AlertWindow("Fleet(s) Not Loaded Successfully!!!..")
                                    End If
                                Catch ex As Exception
                                    Throw ex
                                Finally
                                    cnn.Close()
                                End Try
                            Else
                                AlertWindow("Fleet(s) No: '" & mFl_RegNo & "' Already Exist/Policy Still in Force, UnCheck Vehicle and Reload!!!..")
                                Exit Sub
                            End If
                        End Using
                    Catch ex As Exception
                        AlertWindow(ex.Message)
                        'Exit For
                    Finally

                    End Try
                Else
                    ''AlertWindow("Select/Check Fleet(s) to be Loaded!!!..")
                End If
            Next
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try
    End Sub

    Public Sub SendClientMail()
        Try
            ''Dim ToAddress As String = "Oadeojo@Custodianinsurance.com"
            Dim ToAddress As String = lblEmail.Text ''& ", Oadeojo@Custodianinsurance.com"
            Dim mm As New MailMessage("noreply@Custodiansme.com", ToAddress)
            Dim m As String
            m = " Dear Client, " & vbCrLf & _
               " PolicyHolder:   " & mFl_PolNum & ". " & vbCrLf & _
               " Insured:        " & mFl_InsName & ". " & vbCrLf & _
               " Certificate No:    " & mFl_CertificateNo & vbCrLf & _
               " Policy No:             " & mFl_PolNum & vbCrLf & _
               " Reg No:             " & mFl_RegNo & vbCrLf & _
               " Type of Usage:        " & mFl_TypeUsage & vbCrLf & _
               " Currency:        " & "NAIRA" & vbCrLf & _
               " Cover Type:        " & mFl_TypeCover & vbCrLf & _
               " Vehicle Make:        " & mFl_VehMake & vbCrLf & _
               " Chassis No:        " & mFl_VehChassis & vbCrLf & _
               " Start Date:        " & Format(CDate(mFl_CommDate), "dd-MMM-yyyy") & vbCrLf & _
               " End Date:        " & Format(CDate(mFl_Expdate), "dd-MMM-yyyy") & vbCrLf & _
               " Renewal Date:        " & Format(CDate(mFl_Expdate).AddDays(1), "dd-MMM-yyyy") & vbCrLf & _
               " Sum Insured:       " & FormatCurrency(mFl_SumIns).Remove(0, 1) & vbCrLf & _
               " Vehicle Value:    " & FormatCurrency(mFl_SumIns).Remove(0, 1) & vbCrLf & _
               " Premium:             " & FormatCurrency(mFl_Premium).Remove(0, 1) & vbCrLf & _
               " Rate:                     " & mFl_Rate & "%" & vbCrLf & vbCrLf & _
               " has been generated on Custodian Motor Portal successfully, Kindly print your Certificate." & vbCrLf & vbCrLf & _
               " Regards " & vbCrLf & _
               " Custodian and Allied Insurance Ltd."

            mm.Subject = "New Certificate On Motor Insurance Portal.."
            mm.Body = m
            mm.IsBodyHtml = False
            Dim smtp As New SmtpClient
            smtp.Send(mm)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub SendCustodianMail()
        ''Dim ToAddress As String = txtEmail.Text
        Try
            ''Dim ToAddress As String = "OAdeojo@Custodianinsurance.com" ''
            Dim ToAddress As String = Lblunitmail.Text & ", COhaka@Custodianinsurance.com, EIsujeh@Custodianinsurance.com " ''
            Dim mm As New MailMessage("noreply@Custodiansme.com", ToAddress)

            Dim m As String
            m = " Dear Team, " & vbCrLf & _
               " PolicyHolder:   " & mFl_PolNum & ". " & vbCrLf & _
               " Insured:        " & mFl_InsName & ". " & vbCrLf & _
               " Certificate No:    " & mFl_CertificateNo & vbCrLf & _
               " Policy No:             " & mFl_PolNum & vbCrLf & _
               " Reg No:             " & mFl_RegNo & vbCrLf & _
               " Type of Usage:        " & mFl_TypeUsage & vbCrLf & _
               " Currency:        " & "NAIRA" & vbCrLf & _
               " Cover Type:        " & mFl_TypeCover & vbCrLf & _
               " Vehicle Make:        " & mFl_VehMake & vbCrLf & _
               " Chassis No:        " & mFl_VehChassis & vbCrLf & _
               " Start Date:        " & Format(CDate(mFl_CommDate), "dd-MMM-yyyy") & vbCrLf & _
               " End Date:        " & Format(CDate(mFl_Expdate), "dd-MMM-yyyy") & vbCrLf & _
               " Renewal Date:        " & Format(CDate(mFl_Expdate).AddDays(1), "dd-MMM-yyyy") & vbCrLf & _
               " Sum Insured:       " & FormatCurrency(mFl_SumIns).Remove(0, 1) & vbCrLf & _
               " Vehicle Value:    " & FormatCurrency(mFl_SumIns).Remove(0, 1) & vbCrLf & _
               " Premium:             " & FormatCurrency(mFl_Premium).Remove(0, 1) & vbCrLf & _
               " Rate:                     " & mFl_Rate & "%" & vbCrLf & vbCrLf & _
               " has been generated on Custodian Motor Portal successfully, Kindly print your Certificate." & vbCrLf & vbCrLf & _
               " Regards " & vbCrLf & _
               " Custodian and Allied Insurance Ltd."

            mm.Subject = "New Certificate On Motor Insurance Portal.."
            mm.Body = m
            mm.IsBodyHtml = False
            Dim smtp As New SmtpClient
            smtp.Send(mm)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AlertWindow(ByVal Message As String)
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        ltlAlert.Text = "alert('" & Message & "')"
    End Sub
    Public Function NewRec() As String
        Using cnn As New SqlConnection(ConnectionString)
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            Dim varautonum As String
            Dim varbr As String
            Dim varNo As String
            cmd = New SqlCommand("SELECT Aulastno,AuSuffix2Code FROM autofile where auclass ='77'", cnn)
            cnn.Open()
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                varbr = Trim(rdr("AuSuffix2Code") & "")
                varautonum = rdr("Aulastno") & ""
                varautonum = varautonum + 1
                varNo = DB.func7(varautonum)
                cnn.Close()
                strSQL = "UPDATE autofile SET Aulastno='" & varautonum & "'"
                strSQL &= "WHERE AuSuffix2Code='" & varbr & "'"
                NewRec = varNo
                If DB.UpdateDB(strSQL) Then
                End If
            End If
        End Using
    End Function
End Class
