Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Math

Partial Class PackagedPolicy
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim s As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim mPeriod As String
    Dim strUsername As String
    Dim i As Double
    Dim DB As New DBUtility()
    Dim mPassword As String
    Public mUpdatePwd, mDeletePwd, mPassw As String
    Private CurrectUser, CurrecPass, CurrecDB, CertificateNo As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                BtnSave.Attributes.Add("onclick", "if(confirm('Are you sure you want to Submit this record? Certificate is Issued Immediately.')){}else{return false}")
                CheckIfUserAccessStillActive()
                mQuery()
                ''If lblCateg.Text = "Broker" Then

                ''End If

                ''txtCommDate.Text = Format((Now), "MM/dd/yyyy")
                txtApplyDate.Text = Format((Now), "MM/dd/yyyy")
            Catch ex As Exception
                lblAlert.Text = ex.Message
            End Try
        End If
    End Sub
    Sub CheckIfUserAccessStillActive()
        Try
            CurrectUser = Session("mUser")
            CurrecPass = Session("mpass")
            ''txtAcctNo.Text = UCase(CurrectUser)
            If CurrectUser = "" Then
                Response.Redirect("Login.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mQuery()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & CurrectUser & "' and Reg_Account in ('User','Broker') and Reg_Active = 'Active'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    If rdr("Reg_Account") = "User" Then
                        txtAcctNo.Text = UCase(CurrectUser)
                        txtEmail.Text = rdr("reg_mail")
                        txtBizLocation.Text = rdr("reg_Addr")
                        txtCompName.Text = rdr("Reg_CompName")
                        txtOccupation.Text = rdr("Reg_Business")
                        txtTelephone.Text = rdr("Reg_Tel")
                        ''txtPremRate.Text = rdr("Reg_Premrate")
                        ''ddlconvey.SelectedValue = rdr("Reg_Convey")
                        ddlClause.SelectedValue = rdr("Reg_Clause")
                        txtPolnum.Text = rdr("Reg_PolNum")
                        lblUsername.Text = rdr("Reg_mUser")
                        lblCateg.Text = rdr("Reg_Account")
                        txtTIN.Text = rdr("Reg_CompNo")
                    ElseIf rdr("Reg_Account") = "Broker" Then
                        txtAcctNo.Text = ""
                        lblCateg.Text = rdr("Reg_Account")
                        lblUsername.Text = rdr("Reg_Username")
                        lblClient.Visible = True
                        ddlclient.Visible = True
                        fillClient()
                        ''txtEmail.Enabled = True
                        ''txtBizLocation.Enabled = True
                        ''txtCompName.Enabled = True
                        ''txtOccupation.Enabled = True
                        ''txtTelephone.Enabled = True
                        ''txtPremRate.Enabled = False
                        ''ddlconvey.Enabled = True
                        ''ddlClause.Enabled = True
                        txtPremRate.Text = 0
                        txtPolnum.Enabled = True
                    End If
                    txtExclusion.Text = "AS PER POLICY CONDITIONS"
                    txtExcess.Text = "AS PER POLICY CONDITIONS"
                    Lblunitmail.Text = rdr("Reg_Unitmail")
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If ChkSign.Checked = False Then
                lblAlert.Text = "Check Signature Box below before the Submit!!!"
                lblAlert.ForeColor = System.Drawing.Color.Red
                Exit Sub
            End If



            Dim mSumAmount, mPremAmt, mInvoice As String
            mInvoice = txtInvoiceVal.Text.Replace(",", "")
            mSumAmount = txtSumAssured.Text.Replace(",", "")
            mPremAmt = txtPremium.Text.Replace(",", "")
            Using cnn As New SqlConnection(ConnectionString)
                Dim AcctNo As String = txtAcctNo.Text
                Dim CommDate As Date = Format((Now), "MM/dd/yyyy") ''Date.ParseExact(txtCommDate.ToString(), "dd/mm/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)

                ''Dim PolicyNo As String = NewPol()
                Dim ClauseCondition As String = NewCondition()
                Dim ActiveDate As Date = txtCommDate.Text
                Dim ExpiryDate As Date = Now.AddMonths(3)

                If ActiveDate < CommDate Then
                    lblAlert.Text = "Your Commencement Date CANNOT be backdated. Please review before Submit!!!"
                    lblAlert.ForeColor = System.Drawing.Color.Red
                    Exit Sub
                End If

                cmd = New SqlCommand("SELECT * FROM ActivatePolicy WHERE CertificateNo='" & CertificateNo & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    cnn.Close()
                    ''Dim Reg_Pwd As String = DB.NewPwd()
                    CertificateNo = "01-" & NewRec()
                    lblCertNo.Text = CertificateNo
                    strSQL = "INSERT INTO ActivatePolicy("
                    strSQL &= "AcctNo,Reg_Business,CompName,Telephone,BizAddress,PolicyNo,SumInsured,Premium,CommDate,ActConvey,ExchangeRt,ForexCurr,InvoiceVal,"
                    strSQL &= "PremRt,TIN,FrmLocatn,ToLocatn,Descriptn,CertificateNo,ActiveDate,ExpiryDate,mStatus,Reg_Clause,Reg_Exclusion,Reg_Excess,Reg_Condition,mUser,ChkSign)"
                    strSQL &= "VALUES("
                    strSQL &= "'" & txtAcctNo.Text & "',"
                    strSQL &= "'" & UCase(txtOccupation.Text) & "',"
                    strSQL &= "'" & UCase(txtCompName.Text) & "',"
                    strSQL &= "'" & UCase(txtTelephone.Text) & "',"
                    strSQL &= "'" & UCase(txtBizLocation.Text) & "',"
                    strSQL &= "'" & txtPolnum.Text & "',"
                    strSQL &= "'" & Math.Round(Val(mSumAmount), 2) & "'," '
                    strSQL &= "'" & Math.Round(Val(mPremAmt), 2) & "'," ''Math.Round(sngBMI, 2)
                    strSQL &= "'" & txtCommDate.Text & "',"
                    strSQL &= "'" & ddlconvey.SelectedValue & "',"
                    If ddlCurrency.SelectedValue = "1" Then
                        strSQL &= "'0',"
                    Else
                        strSQL &= "'" & txtExRate.Text & "',"
                    End If
                    strSQL &= "'" & ddlCurrency.SelectedValue & "',"
                    strSQL &= "'" & Math.Round(Val(mInvoice), 2) & "',"
                    strSQL &= "'" & txtPremRate.Text & "',"
                    strSQL &= "'" & UCase(txtTIN.Text) & "',"
                    strSQL &= "'" & UCase(txtFrom.Text) & "',"
                    strSQL &= "'" & UCase(txtTo.Text) & "',"
                    strSQL &= "'" & UCase(txtDesc.Text) & "',"
                    strSQL &= "'" & UCase(CertificateNo) & "',"
                    strSQL &= "'" & ActiveDate & "',"
                    strSQL &= "'" & ExpiryDate & "',"
                    strSQL &= "'Activated',"
                    strSQL &= "'" & ddlClause.SelectedItem.Text & "',"
                    strSQL &= "'" & txtExclusion.Text & "',"
                    strSQL &= "'" & UCase(txtExcess.Text) & "',"
                    strSQL &= "'" & UCase(ClauseCondition) & "',"
                    strSQL &= "'" & lblUsername.Text & "',"
                    strSQL &= "'A')"
                    If DB.UpdateDB(strSQL) Then
                        LblAlert.Text = "Certificate Saved Successfully!!!.."
                        SendClientMail()
                        SendCustodianMail()
                        LblAlert.ForeColor = System.Drawing.Color.Green
                        BtnSave.Visible = False
                        BtnPrint.Visible = True
                    End If
                Else
                    LblAlert.Text = "Certificate Already Exist!!."
                    LblAlert.ForeColor = System.Drawing.Color.Red
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            lblAlert.Text = ex.Message
        End Try
    End Sub
    Public Sub SendClientMail()
        Try
            Dim ToAddress As String = txtEmail.Text ''& ", COhaka@Custodianinsurance.com,Marine@Custodianinsurance.com,Oadeojo@Custodianinsurance.com"
            Dim mm As New MailMessage("noreply@marine.Custodiansme.com", ToAddress)

            Dim m As String
            m = " Dear Client, " & vbCrLf & _
               " Client/Insured:   " & txtCompName.Text & ". " & vbCrLf & _
               " Certificate No:    " & CertificateNo & vbCrLf & _
               " Policy No:             " & txtPolnum.Text & vbCrLf & _
               " Conveyance:        " & ddlconvey.SelectedValue & vbCrLf & _
               " Currency:        " & ddlCurrency.SelectedItem.Text & vbCrLf & _
               " Exchange Rate:        " & txtExRate.Text & vbCrLf & _
               " Clause Type:        " & ddlClause.SelectedValue & vbCrLf & _
               " From:                     " & txtFrom.Text & vbCrLf & _
               " To:                          " & txtTo.Text & vbCrLf & _
               " Sum Insured:       " & FormatCurrency(txtSumAssured.Text).Remove(0, 1) & vbCrLf & _
               " Invoice SumIns:    " & txtInvoiceVal.Text & vbCrLf & _
               " Premium:             " & FormatCurrency(txtPremium.Text).Remove(0, 1) & vbCrLf & _
               " Rate:                     " & txtPremRate.Text & vbCrLf & vbCrLf & _
               " has been generated on Custodian Marine Portal successfully, Kindly print your Certificate." & vbCrLf & vbCrLf & _
               " Regards " & vbCrLf & _
               " Custodian and Allied Insurance Ltd."

            mm.Subject = "New Certificate On Marine Insurance Portal.."
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
            Dim ToAddress As String = Lblunitmail.Text & ", COhaka@Custodianinsurance.com, EIsujeh@Custodianinsurance.com " ''
            Dim mm As New MailMessage("noreply@marine.Custodiansme.com", ToAddress)

            Dim m As String
            m = " Dear All, " & vbCrLf & _
               " Client/Insured:   " & txtCompName.Text & ". " & vbCrLf & _
               " Certificate No:    " & CertificateNo & vbCrLf & _
               " Policy No:             " & txtPolnum.Text & vbCrLf & _
               " Conveyance:        " & ddlconvey.SelectedValue & vbCrLf & _
               " Currency:        " & ddlCurrency.SelectedItem.Text & vbCrLf & _
               " Exchange Rate:        " & txtExRate.Text & vbCrLf & _
               " Clause Type:        " & ddlClause.SelectedValue & vbCrLf & _
               " From:                     " & txtFrom.Text & vbCrLf & _
               " To:                          " & txtTo.Text & vbCrLf & _
               " Sum Insured:       " & FormatCurrency(txtSumAssured.Text).Remove(0, 1) & vbCrLf & _
               " Invoice SumIns:    " & txtInvoiceVal.Text & vbCrLf & _
               " Premium:             " & FormatCurrency(txtPremium.Text).Remove(0, 1) & vbCrLf & _
               " Rate:                     " & txtPremRate.Text & vbCrLf & vbCrLf & _
            " has been generated on Custodian Marine Portal successfully. " & vbCrLf & vbCrLf & _
            " Regards " & vbCrLf & _
            " Custodian and Allied Insurance Ltd."

            mm.Subject = "New Certificate On Marine Insurance Portal.."
            mm.Body = m
            mm.IsBodyHtml = False
            Dim smtp As New SmtpClient
            smtp.Send(mm)
        Catch ex As Exception

        End Try

    End Sub

    Public Function NewRec() As String
        Using cnn As New SqlConnection(ConnectionString)
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            Dim varautonum As String
            Dim varbr As String
            Dim varNo As String
            cmd = New SqlCommand("SELECT Aulastno,AuSuffix2Code FROM autofile where auclass ='44'", cnn)
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
    Public Function ConveyRate() As String
        Using cnn As New SqlConnection(ConnectionString)
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & txtAcctNo.Text & "'", cnn)
            cnn.Open()
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                If ddlconvey.SelectedValue = "Air" Then
                    txtPremRate.Text = rdr("Reg_Premrate") & ""
                ElseIf ddlconvey.SelectedValue = "Sea" Then
                    txtPremRate.Text = rdr("Reg_PremrateS") & ""
                End If
                cnn.Close()
            End If
        End Using
    End Function
    Public Function NewPol() As String
        Using cnn As New SqlConnection(ConnectionString)
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            Dim varPol As String
            cmd = New SqlCommand("SELECT PolicyNo FROM autofile where auclass ='44'", cnn)
            cnn.Open()
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                varPol = Trim(rdr("PolicyNo") & "")
                cnn.Close()
                NewPol = varPol
            End If
        End Using
    End Function

    Private Sub fillClient()
        ''On Error Resume Next
        With ddlclient
            .ClearSelection()
            .DataSource = DB.fillClients(lblUsername.Text)
            .DataTextField = "Reg_Compname"
            .DataValueField = "Reg_Username"
            .DataBind()
            .Items.Insert(0, "")
            .SelectedIndex = 0
        End With
    End Sub

    Public Function NewCondition() As String
        If ddlClause.SelectedValue <> "Bulk Oil Cargo" Then
            Using cnn As New SqlConnection(ConnectionString)
                Dim cmd As New SqlCommand
                Dim rdr As SqlDataReader
                Dim varCon As String
                cmd = New SqlCommand("SELECT Cargo_Conditions FROM Cargo_Clause where Category_Type ='" & ddlconvey.SelectedValue & "' and Category_Clause ='" & ddlClause.SelectedValue & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    varCon = rdr("Cargo_Conditions")
                    cnn.Close()
                    NewCondition = varCon
                End If
            End Using
        Else
            Using cnn As New SqlConnection(ConnectionString)
                Dim cmd As New SqlCommand
                Dim rdr As SqlDataReader
                Dim varCon As String
                cmd = New SqlCommand("SELECT Cargo_Conditions FROM Cargo_Clause where Category_Type ='Sea' and Category_Clause ='" & ddlClause.SelectedValue & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    varCon = rdr("Cargo_Conditions")
                    cnn.Close()
                    NewCondition = varCon
                End If
            End Using
        End If

    End Function
    Private Function mForexCalc(ByVal mSumInsured As String) As String
        Try
            Dim mAmount As String = mSumInsured
            If ddlCurrency.SelectedValue = 1 Then
                If chkloading.Checked = True Then
                    mForexCalc = Val(mAmount) + (mAmount * 10 / 100) * 1
                    txtSumAssured.Text = FormatCurrency(mForexCalc).Remove(0, 1)
                Else
                    mForexCalc = mAmount
                    txtSumAssured.Text = FormatCurrency(mForexCalc).Remove(0, 1)
                End If
            Else
                If chkloading.Checked = True Then
                    mForexCalc = Val(mAmount + (mAmount * 10 / 100)) * Val(txtExRate.Text)
                    txtSumAssured.Text = FormatCurrency(mForexCalc).Remove(0, 1)
                Else
                    mForexCalc = Val(mAmount) * Val(txtExRate.Text)
                    txtSumAssured.Text = FormatCurrency(mForexCalc).Remove(0, 1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub premCalculator()
        Try
            Dim mAmount As String
            mAmount = txtInvoiceVal.Text.Replace(",", "")
            mAmount = mForexCalc(mAmount)
            Dim mPrem As Decimal = mAmount * txtPremRate.Text / 100
            If lblUsername.Text = "NNPC MARINE" Or lblUsername.Text = "NNPC MARINE-2" Then
                txtPremium.Text = FormatCurrency(mPrem).Remove(0, 1)
            Else
                If lblUsername.Text = "TIBROKERS" Then
                    If mPrem <= 10000 Then
                        txtPremium.Text = FormatCurrency(10000).Remove(0, 1)
                    ElseIf mPrem > 10000 Then
                        txtPremium.Text = FormatCurrency(mPrem).Remove(0, 1)
                    End If
                Else
                    If mPrem <= 5000 Then
                        txtPremium.Text = FormatCurrency(5000).Remove(0, 1)
                    ElseIf mPrem > 5000 Then
                        txtPremium.Text = FormatCurrency(mPrem).Remove(0, 1)
                    End If
                End If

            End If
            txtInvoiceVal.Text = FormatCurrency(txtInvoiceVal.Text).Remove(0, 1)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtSumAssured_TextChanged(sender As Object, e As EventArgs) Handles txtSumAssured.TextChanged
        Try
            premCalculator()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtPremRate_TextChanged(sender As Object, e As EventArgs) Handles txtPremRate.TextChanged
        Try
            premCalculator()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlclient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlclient.SelectedIndexChanged
        mQuery1()
    End Sub

    Private Sub mQuery1()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & ddlclient.SelectedValue & "' and Reg_Account in ('User') and Reg_Active = 'Active'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    If rdr("Reg_Account") = "User" Then
                        txtAcctNo.Text = ddlclient.SelectedValue
                        txtEmail.Text = rdr("reg_mail")
                        txtBizLocation.Text = rdr("reg_Addr")
                        txtCompName.Text = rdr("Reg_CompName")
                        txtOccupation.Text = rdr("Reg_Business")
                        txtTelephone.Text = rdr("Reg_Tel")
                        'txtPremRate.Text = rdr("Reg_Premrate")
                        ''ddlconvey.SelectedValue = rdr("Reg_Convey")
                        ddlClause.SelectedValue = rdr("Reg_Clause")
                        txtPolnum.Text = rdr("Reg_PolNum")
                        lblUsername.Text = rdr("Reg_mUser")
                        lblCateg.Text = rdr("Reg_Account")
                        txtTIN.Text = rdr("Reg_CompNo")
                    ElseIf rdr("Reg_Account") = "Broker" Then
                        txtAcctNo.Text = ""
                        lblCateg.Text = rdr("Reg_Account")
                        lblUsername.Text = rdr("Reg_Username")
                        lblClient.Visible = True
                        ddlclient.Visible = True
                        fillClient()
                        ''txtEmail.Enabled = True
                        ''txtBizLocation.Enabled = True
                        ''txtCompName.Enabled = True
                        ''txtOccupation.Enabled = True
                        ''txtTelephone.Enabled = True
                        txtPremRate.Enabled = True
                        ''ddlconvey.Enabled = True
                        ''ddlClause.Enabled = True
                        txtPolnum.Enabled = True
                    End If
                    txtExclusion.Text = "AS PER POLICY CONDITIONS"
                    txtExcess.Text = "AS PER POLICY CONDITIONS"
                    Lblunitmail.Text = rdr("Reg_Unitmail")
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlconvey_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlconvey.SelectedIndexChanged
        Try
            ConveyRate()
        Catch ex As Exception
            LblAlert.Text = ex.Message
        End Try
    End Sub

    Protected Sub chkloading_CheckedChanged(sender As Object, e As EventArgs) Handles chkloading.CheckedChanged
        Try
            premCalculator()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub txtExRate_TextChanged(sender As Object, e As EventArgs) Handles txtExRate.TextChanged
        Try
            premCalculator()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Try

            If ddlCurrency.SelectedValue = 1 Then
                txtExRate.Text = ""
                txtExRate.Enabled = False
                premCalculator()
            Else
                premCalculator()
                txtExRate.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub txtInvoiceVal_TextChanged(sender As Object, e As EventArgs) Handles txtInvoiceVal.TextChanged
        Try

            If ddlCurrency.SelectedValue = 1 Then
                txtExRate.Text = ""
                txtExRate.Enabled = False
                premCalculator()
            Else
                premCalculator()
                txtExRate.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            Session("mCert") = lblCertNo.Text
            Dim url As String = "PushCertSlip.aspx"
            ''Dim s As String = "window.open('" & url + "', 'popup_window', 'width=600,height=400,left=100,top=100,resizable=yes');"
            ''ClientScript.RegisterStartupScript(Me.GetType(), "script", s, False)
            Page.ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('PushCertSlip.aspx','_newtab');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class
