Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Partial Class ClientSetup
    Inherits System.Web.UI.Page
    Private connectionString As String = ConfigurationSettings.AppSettings("StrConn")
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim SQL As String, strSQL As String
    Dim DB As New DBUtility()
    Public mUpdatePwd, mDeletePwd, mPassw As String
    Dim mEndDate As Date
    Private CurrectUser, CurrecPass, CurrecDB As String

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            'If Not IsNumeric(txtUsername.Text) Then
            '    lblAlert.Text = "Number Values Only!!"
            '    Exit Sub
            'End If
            Using cnn As New SqlConnection(connectionString)
                cmd = New SqlCommand("SELECT * FROM Profile_Details WHERE Reg_Username='" & txtUsername.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    cnn.Close()
                    ''Dim Reg_Pwd As String = DB.NewPwd()  strSQL &= "Reg_CompNo='" & txtTIN.Text & "',"
                    strSQL = "INSERT INTO Profile_Details("
                    strSQL &= "Reg_Compname,Reg_Addr,Reg_Business,Reg_Tel,Reg_Mail,Reg_Date,"
                    strSQL &= "Reg_Username,Reg_Pwd,Reg_Active,Reg_Premrate,Reg_PremrateS,Reg_PremrateM,Reg_Unit,Reg_Unitmail,Reg_Polnum,"
                    strSQL &= "Reg_Clause,Reg_Exclusion,Reg_Excess,Reg_mUser,Reg_CompNo,Reg_ChkForex,Reg_Account)"
                    strSQL &= "VALUES("
                    strSQL &= "'" & UCase(txtCompName.Text) & "',"
                    strSQL &= "'" & UCase(txtAddress.Text) & "',"
                    strSQL &= "'" & UCase(txtOccupation.Text) & "',"
                    strSQL &= "'" & txtTelephone.Text & "',"
                    strSQL &= "'" & txtmail.Text & "',"
                    strSQL &= "'" & Format((Now), "MM/dd/yyyy") & "',"
                    strSQL &= "'" & UCase(txtUsername.Text) & "',"
                    strSQL &= "'" & txtPassword.Text & "',"
                    strSQL &= "'Active',"
                    strSQL &= "'" & txtAirRate.Text & "',"
                    strSQL &= "'" & txtSeaRate.Text & "',"
                    strSQL &= "'" & txtMotrate.Text & "',"
                    strSQL &= "'" & ddlunit.SelectedItem.Text & "',"
                    strSQL &= "'" & ddlunit.SelectedValue & "',"
                    strSQL &= "'" & UCase(txtPolNum.Text) & "',"
                    strSQL &= "'" & ddlClause.SelectedItem.Text & "',"
                    strSQL &= "'" & txtExclusion.Text & "',"
                    strSQL &= "'" & txtExcess.Text & "',"
                    strSQL &= "'" & UCase(lblUsername.Text) & "',"
                    strSQL &= "'" & UCase(txtTIN.Text) & "',"
                    If chkforex.Checked = True Then
                        strSQL &= "'A',"
                    Else
                        strSQL &= "'N',"
                    End If
                    strSQL &= "'" & ddlAccess.SelectedValue & "')"
                    If DB.UpdateDB(strSQL) Then
                        Dim Reg_Username As String = txtUsername.Text
                        Dim Reg_Surname As String = txtCompName.Text
                        Dim Reg_Tel As String = txtTelephone.Text
                        Dim Reg_Pwd As String = txtPassword.Text
                        SendMail()
                        SendClientMail()
                        FillGrid2()
                        AlertWindow("Clients Profile Setup Successfully!!!")
                        lblAlert.ForeColor = System.Drawing.Color.Green
                    Else
                        AlertWindow("User Already Exist!!")
                        lblAlert.ForeColor = System.Drawing.Color.Red
                    End If
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            AlertWindow(ex.Message)
            lblAlert.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub
    Public Sub SendMail()
        Dim ToAddress As String = Lblunitmail.Text & ", " & ddlunit.SelectedValue & ", COhaka@Custodianinsurance.com, EIsujeh@Custodianinsurance.com " ''
        Dim mm As New MailMessage("noreply@marine.Custodiansme.com", ToAddress)

        Dim m As String
        m = "Hello Team, " & vbCrLf & vbCrLf & _
            "A Client, " & txtCompName.Text & " with Username: " & txtUsername.Text & _
            "  Has been successfully registered on the Portal. " & vbCrLf & vbCrLf & _
            "Regards"

        mm.Subject = "New Client On Marine Custodian Portal.."
        mm.Body = m
        mm.IsBodyHtml = False
        Dim smtp As New SmtpClient
        smtp.Send(mm)


    End Sub
    Public Sub SendClientMail()
        Dim ToAddress As String = txtmail.Text
        Dim mm As New MailMessage("noreply@marine.Custodiansme.com", ToAddress)

        Dim m As String
        m = "Hello, " & txtCompName.Text & ". " & vbCrLf & vbCrLf & _
            "Your profile has been created on Custodian Marine Portal successfully; Reset your password after login: " & vbCrLf & vbCrLf & " Kindly Login with Username: " & UCase(txtUsername.Text) & ", Password: " & txtPassword.Text & ", Policy No: " & UCase(txtPolNum.Text) & " , click on the link http://marine.custodiansme.com/ClientLogin.aspx to buy Marine Insurance. " & vbCrLf & vbCrLf & _
            "Regards"

        mm.Subject = "New Client On CustodianSME Portal.."
        mm.Body = m
        mm.IsBodyHtml = False
        Dim smtp As New SmtpClient
        smtp.Send(mm)
    End Sub
    Public Sub CreateMessageAlertInUpdatePanel(ByVal up As UpdatePanel, ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        Dim guidKey As Guid = Guid.NewGuid()
        ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey.ToString(), strScript, True)
    End Sub

    Private Sub mQuery()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where Reg_Username='" & lblUsername.Text & "' and Reg_Account in('Broker') and Reg_Active = 'Active'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    Lblunitmail.Text = rdr("Reg_mail")
                    ddlunit.SelectedValue = rdr("Reg_Unitmail")
                    ddlunit.Enabled = False
                    ''lblEmail.Text = rdr("Reg_mail")
                    ''lblFullName.Text = rdr("Reg_CompName")
                    ''lblNumber.Text = rdr("Reg_Tel")
                    ''lblCateg.Text = rdr("Reg_Account")
                Else
                    ''Response.Redirect("~/ValidateForm.aspx")
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Try
                btnLogin.Attributes.Add("onclick", "if(confirm('Are you sure you want to Submit this Record? Record Saved Permanently.')){}else{return false}")
                btnUpdate.Attributes.Add("onclick", "if(confirm('Are you sure you want to Update this Record? Record Updated Permanently.')){}else{return false}")
                CheckIfUserAccessStillActive()
                ChkUserFormAccess()
                mQuery()
                btnUpdate.Visible = False
                txtExcess.Text = "AS PER POLICY CONDITIONS"
                txtExclusion.Text = "AS PER POLICY CONDITIONS"
                FillGrid2()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Function NewUserdet(muser As String) As String
        Try
            Using cnn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand
                Dim rdr As SqlDataReader
                ''Dim varPol As String
                cmd = New SqlCommand("SELECT * FROM Profile_Details where Reg_Username = '" & muser & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    txtUsername.Text = muser
                    txtCompName.Text = rdr("Reg_Compname")
                    txtAddress.Text = rdr("Reg_Addr")
                    txtOccupation.Text = rdr("Reg_Business")
                    txtTelephone.Text = rdr("Reg_Tel")
                    txtmail.Text = rdr("Reg_Mail")
                    ''txtDOB.Text = Format(rdr("Reg_Date"), "MM/dd/yyyy")
                    txtAirRate.Text = rdr("Reg_Premrate")
                    txtSeaRate.Text = rdr("Reg_PremrateS")
                    If Not IsDBNull(rdr("Reg_PremrateM")) Then
                        txtMotrate.Text = rdr("Reg_PremrateM")
                    End If
                    If Not IsDBNull(rdr("Reg_ChkForex")) Then
                        If rdr("Reg_ChkForex") = "A" Then
                            chkforex.Checked = True
                        ElseIf rdr("Reg_ChkForex") = "N" Then
                            chkforex.Checked = False
                        End If
                    Else
                        chkforex.Checked = False
                    End If

                    txtPolNum.Text = rdr("Reg_Polnum")
                    ddlunit.SelectedValue = rdr("Reg_Unitmail") ''Reg_Convey,Reg_Clause,Reg_Exclusion,Reg_Excess,
                    ddlClause.SelectedValue = rdr("Reg_Clause")
                    ddlAccess.SelectedValue = rdr("Reg_Account")
                    txtExclusion.Text = rdr("Reg_Exclusion")
                    txtExcess.Text = rdr("Reg_Excess")
                    If Not IsDBNull(rdr("Reg_CompNo")) Then
                        txtTIN.Text = rdr("Reg_CompNo")
                    Else

                    End If
                    cnn.Close()
                    btnLogin.Visible = False
                    btnUpdate.Visible = True
                Else
                    btnLogin.Visible = True
                    btnUpdate.Visible = False
                End If
            End Using
        Catch ex As Exception
            AlertWindow(ex.Message)
            ''lblAlert.ForeColor = System.Drawing.Color.Red
        End Try

    End Function

    Private Sub FillGrid2()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            StrSqlDatagrid = "select Reg_Username As UserName,Reg_Compname As Insured,Reg_Business As Business,Reg_Tel As Telephone,convert(varchar,(CONVERT(date,Reg_Date,103)),103) as Date,Reg_Account As Access from dbo.Profile_Details where Reg_mUser = '" & lblUsername.Text & "' and Reg_Account = 'User' and reg_Categ is null order by Reg_Username "
            StrConn = connectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.Profile_Details")
            GridView2.DataSource = DisplayDataDatagrid.Tables("dbo.Profile_Details").DefaultView
            GridView2.DataBind()
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try

    End Sub

    Sub ChkUserFormAccess()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where reg_username= '" & CurrectUser & "' and Reg_Account = 'Broker'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    Response.Redirect("~/UserPortal.aspx")
                Else
                    If rdr("Reg_pwd") = CurrecPass Then
                    Else
                        Response.Redirect("~/UserPortal.aspx")
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
            lblUsername.Text = CurrectUser
            If CurrectUser = "" Then
                Response.Redirect("login.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lnkView_Click(sender As Object, e As EventArgs)
        Dim grdrow As GridViewRow = DirectCast(DirectCast(sender, LinkButton).NamingContainer, GridViewRow)
        Dim PushPaySlip As String = grdrow.Cells(1).Text
        'Dim mActive As String = grdrow.Cells(8).Text
        Try
            NewUserdet(PushPaySlip)
        Catch ex As Exception
            AlertWindow(ex.Message)
        End Try

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Using cnn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand
                Dim rdr As SqlDataReader
                ''Dim varPol As String
                cmd = New SqlCommand("SELECT * FROM Profile_Details where Reg_Username = '" & txtUsername.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    cnn.Close()
                    strSQL = "UPDATE profile_details SET "
                    strSQL &= "Reg_Compname='" & UCase(txtCompName.Text) & "',"
                    strSQL &= "Reg_Addr='" & UCase(txtAddress.Text) & "',"
                    strSQL &= "Reg_Business='" & txtOccupation.Text & "',"
                    strSQL &= "Reg_Tel='" & txtTelephone.Text & "',"
                    strSQL &= "Reg_CompNo='" & txtTIN.Text & "',"
                    If chkforex.Checked = True Then
                        strSQL &= "Reg_ChkForex='A',"
                    Else
                        strSQL &= "Reg_ChkForex='N',"
                    End If
                    strSQL &= "Reg_mail='" & txtmail.Text & "',"
                    strSQL &= "Reg_unit='" & ddlunit.SelectedItem.Text & "',"
                    strSQL &= "Reg_unitmail='" & ddlunit.SelectedValue & "',"
                    strSQL &= "Reg_Account='" & ddlAccess.SelectedValue & "',"
                    ''strSQL &= "Reg_Convey='" & ddlConvey.SelectedValue & "',"
                    strSQL &= "Reg_Clause='" & ddlClause.SelectedValue & "',"
                    strSQL &= "Reg_Polnum='" & txtPolNum.Text & "',"
                    strSQL &= "Reg_PremrateM='" & txtMotrate.Text & "',"
                    strSQL &= "Reg_PremrateS='" & txtSeaRate.Text & "',"
                    strSQL &= "Reg_Premrate='" & txtAirRate.Text & "'"
                    strSQL &= " WHERE Reg_Username ='" & txtUsername.Text & "'"
                    If DB.UpdateDB(strSQL) Then
                        AlertWindow("Client Setup Updated Successfully!!!..")
                        lblAlert.ForeColor = System.Drawing.Color.Green
                    Else
                        AlertWindow("Client Setup cannot be updated!")
                        lblAlert.ForeColor = System.Drawing.Color.Red
                    End If
                End If
            End Using
        Catch ex As Exception
            AlertWindow(ex.Message)
            lblAlert.ForeColor = System.Drawing.Color.Red
        End Try

    End Sub
    Private Sub AlertWindow(ByVal Message As String)
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        ltlAlert.Text = "alert('" & Message & "')"
    End Sub

End Class
