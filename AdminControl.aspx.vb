Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Data
Partial Class AdminControl
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

    Private Sub mQuery(ByVal strMessage As String)
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from ActivatePolicy where CertificateNo='" & strMessage & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    If Not IsDBNull(rdr("BizAddress")) Then
                        lblAddress.Text = rdr("BizAddress")
                    End If
                    If Not IsDBNull(rdr("Descriptn")) Then
                        txtDesc.Text = rdr("Descriptn")
                    End If
                    If Not IsDBNull(rdr("Compname")) Then
                        lblCompName.Text = rdr("Compname")
                    End If
                    If Not IsDBNull(rdr("Telephone")) Then
                        lblTel.Text = rdr("Telephone")
                    End If
                    If Not IsDBNull(rdr("CommDate")) Then
                        txtCommdate.Text = rdr("CommDate")
                    End If
                    If Not IsDBNull(rdr("ExpiryDate")) Then
                        txtExpDate.Text = rdr("ExpiryDate")
                    End If
                    If Not IsDBNull(rdr("Premium")) Then
                        txtPremium.Text = FormatCurrency(rdr("Premium")).Remove(0, 1)
                    End If
                    If Not IsDBNull(rdr("SumInsured")) Then
                        txtSumAssrd.Text = FormatCurrency(rdr("SumInsured")).Remove(0, 1)
                    End If
                    If Not IsDBNull(rdr("InvoiceVal")) Then
                        txtInvoiceVal.Text = FormatCurrency(rdr("InvoiceVal")).Remove(0, 1)
                    End If
                    If Not IsDBNull(rdr("ForexCurr")) Then
                        ddlCurrency.SelectedValue = rdr("ForexCurr")
                    End If
                    If Not IsDBNull(rdr("ExchangeRt")) Then
                        txtExRate.Text = rdr("ExchangeRt")
                    End If
                    If Not IsDBNull(rdr("Premrt")) Then
                        txtpremrate.Text = rdr("Premrt")
                    End If
                    If Not IsDBNull(rdr("FrmLocatn")) Then
                        txtfrom.Text = rdr("FrmLocatn")
                    End If
                    If Not IsDBNull(rdr("ToLocatn")) Then
                        txtto.Text = rdr("ToLocatn")
                    End If
                    If Not IsDBNull(rdr("ActConvey")) Then
                        ddlconvey.SelectedValue = rdr("ActConvey")
                    End If
                    If Not IsDBNull(rdr("Reg_Clause")) Then
                        ddlClause.SelectedValue = rdr("Reg_Clause")
                    End If
                    If Not IsDBNull(rdr("Reg_Condition")) Then
                        txtCondition.Text = rdr("Reg_Condition")
                    End If
                    If Not IsDBNull(rdr("mstatus")) Then
                        ddlstatus.SelectedValue = rdr("mstatus")
                    End If
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Sub ChkUserFormAccess()
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from Profile_Details where reg_username= '" & CurrectUser & "' and Reg_Account = 'Administrator'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    Response.Redirect("~/MyPortal.aspx")
                Else
                    If rdr("Reg_pwd") = CurrecPass Then
                    Else
                        Response.Redirect("~/MyPortal.aspx")
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
                FillGrid()
            Catch ex As Exception
                ''lblAlert.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub FillGrid()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            StrSqlDatagrid = "SELECT [CertificateNo], [Compname], convert(varchar,(CONVERT(date,Commdate,103)),103) as CommDate FROM ActivatePolicy where ActConvey is not null and mstatus is not null order by CertificateNo desc"
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            grdVendors.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            grdVendors.DataBind()

        Catch ex As Exception
            ''lblAlert.Text = ex.Message
        End Try
    End Sub
    Private Sub FillGridNext()
        Try
            Dim DatabaseConnectDatagrid As SqlDataAdapter
            Dim DisplayDataDatagrid As New DataSet
            Dim StrSqlDatagrid As String
            Dim StrConn As String

            StrSqlDatagrid = "SELECT [CertificateNo], [Compname], convert(varchar,(CONVERT(date,Commdate,103)),103) as CommDate FROM ActivatePolicy where ActConvey is not null and mstatus is not null order by CertificateNo desc"
            StrConn = ConnectionString
            DatabaseConnectDatagrid = New SqlDataAdapter(StrSqlDatagrid, StrConn)
            DatabaseConnectDatagrid.Fill(DisplayDataDatagrid, "dbo.ActivatePolicy")
            grdVendors.DataSource = DisplayDataDatagrid.Tables("dbo.ActivatePolicy").DefaultView
            grdVendors.DataBind()

        Catch ex As Exception
            ''lblAlert.Text = ex.Message
        End Try
    End Sub
    Public Function NewRec() As String
        Using cnn As New SqlConnection(ConnectionString)
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            Dim varautonum As String
            Dim varbr As String
            Dim varNo As String
            cmd = New SqlCommand("SELECT Aulastno,AuSuffix2Code FROM autofile where auclass ='4'", cnn)
            cnn.Open()
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                varbr = Trim(rdr("AuSuffix2Code") & "")
                varautonum = rdr("Aulastno") & ""
                varautonum = varautonum + 1
                varNo = varbr & DB.func7(varautonum)
                cnn.Close()
                strSQL = "UPDATE autofile SET Aulastno='" & varautonum & "'"
                strSQL &= "WHERE AuSuffix2Code='" & varbr & "'"
                NewRec = varNo
                If DB.UpdateDB(strSQL) Then
                End If
            End If
        End Using
    End Function

    Protected Sub btnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        Try
            Using cnn As New SqlConnection(ConnectionString)
                cmd = New SqlCommand("select * from ActivatePolicy where CertificateNo='" & lblAcctno.Text & "'", cnn)
                cnn.Open()
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    ''cnn.Close()
                    lblError.Text = "User Records Not Found!!!"
                    Exit Sub
                Else
                    'Dim CertificateNo As String = NewRec()
                    Dim mAmountsum, mAmountprem, mInvoiceAmt As String
                    mAmountsum = txtSumAssrd.Text.Replace(",", "")
                    mAmountprem = txtPremium.Text.Replace(",", "")
                    mInvoiceAmt = txtInvoiceVal.Text.Replace(",", "")
                    strSQL = "UPDATE ActivatePolicy SET Reg_Addr ='" & lblAddress.Text & "', Reg_Compname ='" & lblCompName.Text & "', mstatus='" & ddlstatus.SelectedValue & "', premium='" & mAmountprem & "', SumInsured='" & mAmountsum & "', FrmLocatn='" & txtfrom.Text & "', ToLocatn='" & txtto.Text & "', ExchangeRt='" & txtExRate.Text & "', ForexCurr='" & ddlCurrency.SelectedValue & "', InvoiceVal='" & mInvoiceAmt & "', " _
                        & " Descriptn='" & txtDesc.Text & "', premrt='" & txtpremrate.Text & "', ActConvey='" & ddlconvey.SelectedValue & "', Reg_Clause='" & ddlClause.SelectedValue & "',  Reg_Condition='" & txtCondition.Text & "'  where CertificateNo='" & lblAcctno.Text & "' and Activedate='" & txtCommdate.Text & "'"
                        DB.UpdateDB(strSQL)
                        'DB.ProcSMS(lblTel.Text, lblCompName.Text, "HO/F/01/B0000044", CertificateNo)
                    lblError.Text = "Certificate Updated Successfully!!!.."
                    lblError.ForeColor = System.Drawing.Color.Green
                    grdVendors.DataBind()
                    FillGrid()
                End If
                cnn.Close()
            End Using
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub

    Protected Sub grdVendors_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdVendors.PageIndexChanging
        grdVendors.PageIndex = e.NewPageIndex
        FillGridNext()
    End Sub

   

    Protected Sub grdVendors_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdVendors.RowCommand
        On Error Resume Next
        If e.CommandName = "Select" Then
            'get the index of the row with the button clicked
            Dim rowIndex As Integer = e.CommandArgument
            'get the key value for the row
            Dim intBrNo As String = grdVendors.DataKeys(rowIndex).Value
            lblAcctno.Text = intBrNo

            Dim row As GridViewRow = grdVendors.Rows(rowIndex)
            Dim cellbranch As TableCell = row.Cells(2)
            Dim mBranch As Date = cellbranch.Text

            mQuery(lblAcctno.Text)

        End If
    End Sub

    
    Protected Sub lblAcctno_TextChanged(sender As Object, e As EventArgs) Handles lblAcctno.TextChanged
        Try
            mQuery(lblAcctno.Text)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
End Class


