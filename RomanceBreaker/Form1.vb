Public Class frmMain

    'Making borderless form draggable'
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2
    Private Const WM_NCHITTEST As Integer = &H84

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)

        If m.Msg = WM_NCHITTEST AndAlso m.Result = HTCLIENT Then
            m.Result = HTCAPTION
        End If
    End Sub

    'Checking Python environment installation'
    Private Sub frmMain_Load() Handles MyBase.Load
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        If IO.Directory.Exists(appDataPath + "\Python\Python37") = False Then
            MsgBox("Python 3.7 was not found on this machine, install it before running RomanceBreaker!")
            Process.Start("https://www.python.org/downloads/")
            Application.Exit()
        Else
            console.run("pip3 install fbchat bs4 telethon selenium pyperclip", vbHide)
        End If
    End Sub

    'Close Processes function'
    Private Sub killProcesses()
        For Each proc As Process In Process.GetProcessesByName("Python")
            proc.Kill()
        Next
        For Each proc As Process In Process.GetProcessesByName("chromedriver")
            proc.Kill()
        Next
    End Sub

    'Constants'
    Private console = CreateObject("WScript.Shell")
    Private currentMode = 0
    Private msngrUsernameInput = False
    Private msngrPasswordInput = False
    Private msngrBaeInput = False
    Private smsBaeInput = False
    Private tlgrmUsernameInput = False
    Private tlgrmPhoneInput = False
    Private tlgrmApiIDInput = False
    Private tlgrmApiHashInput = False
    Private tlgrmBaeInput = False
    Private waBaeInput = False

    'Copyright label'
    Private Sub copytightLbl_Click() Handles copytightLbl.Click
        Process.Start("https://github.com/lorcalhost/")
    End Sub
    'GitHub button'
    Private Sub btnGithub_Click() Handles btnGithub.Click
        Process.Start("https://github.com/lorcalhost/RomanceBreaker")
    End Sub

    Private Sub lblGithub_Click() Handles lblGithub.Click
        btnGithub_Click()
    End Sub

    'Edit button'
    Private Sub btnEdit_Click() Handles btnEdit.Click
        console.run("notepad " & Application.StartupPath() & "\config.py")
    End Sub

    Private Sub lblEdit_Click() Handles lblEdit.Click
        btnEdit_Click()
    End Sub

    'On/Off button'
    Private Sub btnOff_Click() Handles btnOff.Click
        If currentMode Like 0 Then
            MsgBox("Select a mode first!")
        Else
            btnOff.Visible = False
            btnOn.Visible = True
            lblOnOff.Text = "Stop"
            btnMessenger.Enabled = False
            btnSms.Enabled = False
            btnTelegram.Enabled = False
            btnWhatsapp.Enabled = False
            btnEdit.Enabled = False
            lblEdit.Enabled = False

            If currentMode = 1 Then
                If msngrUsernameInput And msngrPasswordInput And msngrBaeInput Then
                    Dim user As String = msngrUsername.Text
                    Dim pass As String = msngrPassword.Text
                    Dim bae As String = msngrBae.Text
                    console.run("python " & Application.StartupPath() & "\messengerRB.py " & user & " " & pass & " " & bae)
                Else
                    MsgBox("All fields must not be empty!")
                    btnOn_Click()
                End If
            ElseIf currentMode = 2 Then
                If smsBaeInput Then
                    MsgBox("A popup view of Google Messages will now open,\nScan the QR code in the page via your app\nDon't close the popup")
                    Dim bae As String = smsBae.Text
                    console.run("python " & Application.StartupPath() & "\smsRB.py " & bae, vbHide)
                Else
                    MsgBox("All fields must not be empty!")
                    btnOn_Click()
                End If

            ElseIf currentMode = 3 Then
                If tlgrmUsernameInput And tlgrmPhoneInput And tlgrmApiIDInput And tlgrmApiHashInput And tlgrmBaeInput Then
                    Dim user As String = tlgrmUsername.Text
                    Dim phone As String = tlgrmPhone.Text
                    Dim apid As String = tlgrmAPI_ID.Text
                    Dim apihash As String = tlgrmAPI_HASH.Text
                    Dim bae As String = tlgrmBae.Text
                    console.run("python " & Application.StartupPath() & "\telegramRB.py " & user & " " & apid & " " & apihash & " " & phone & " " & bae)
                Else
                    MsgBox("All fields must not be empty!")
                    btnOn_Click()
                End If
            ElseIf currentMode = 4 Then
                If waBaeInput Then
                    MsgBox("A popup view of WhatsApp web will now open,\nScan the QR code in the page via your app\nDon't close the popup")
                    Dim bae As String = waBae.Text
                    console.run("python " & Application.StartupPath() & "\whatsappRB.py " & bae, vbHide)
                Else
                    MsgBox("All fields must not be empty!")
                    btnOn_Click()
                End If
            End If
        End If
    End Sub

    Private Sub btnOn_Click() Handles btnOn.Click
        btnOff.Visible = True
        btnOn.Visible = False
        lblOnOff.Text = "Start"
        btnMessenger.Enabled = True
        btnSms.Enabled = True
        btnTelegram.Enabled = True
        btnWhatsapp.Enabled = True
        btnEdit.Enabled = True
        lblEdit.Enabled = True
        killProcesses()
    End Sub

    'Window close button'
    Private Sub btnClose_Click() Handles btnClose.Click
        killProcesses()
        Application.Exit()
    End Sub

    'Window minimize button'
    Private Sub btnMinimize_Click() Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'Mode selection buttons'
    Private Sub btnWhatsapp_Click() Handles btnWhatsapp.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.FixedSingle
        currentMode = 4

        pnlDefault.Visible = False
        pnlMessenger.Visible = False
        pnlSms.Visible = False
        pnlTelegram.Visible = False
        pnlWa.Visible = True
    End Sub

    Private Sub btnTelegram_Click() Handles btnTelegram.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.FixedSingle
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 3

        pnlDefault.Visible = False
        pnlMessenger.Visible = False
        pnlSms.Visible = False
        pnlTelegram.Visible = True
        pnlWa.Visible = False
    End Sub

    Private Sub btnSms_Click() Handles btnSms.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.FixedSingle
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 2

        pnlDefault.Visible = False
        pnlMessenger.Visible = False
        pnlSms.Visible = True
        pnlTelegram.Visible = False
        pnlWa.Visible = False
    End Sub

    Private Sub btnMessenger_Click() Handles btnMessenger.Click
        btnMessenger.BorderStyle = BorderStyle.FixedSingle
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 1

        pnlDefault.Visible = False
        pnlMessenger.Visible = True
        pnlSms.Visible = False
        pnlTelegram.Visible = False
        pnlWa.Visible = False
    End Sub

    'Messenger form'
    Private Sub msngrUsername_TextChanged() Handles msngrUsername.TextChanged
        If (msngrUsername.Text = "Username") Then
            msngrUsernameInput = False
        Else
            msngrUsernameInput = True
        End If
    End Sub

    Private Sub msngrUsername_GotFocus() Handles msngrUsername.GotFocus
        If (msngrUsername.Text = "Username") Or (msngrUsername.Text = "") Then
            msngrUsername.Text = ""
        End If
    End Sub

    Private Sub msngrUsername_LostFocus() Handles msngrUsername.LostFocus
        If msngrUsername.Text = "" Then
            msngrUsername.Text = "Username"
        End If
    End Sub

    Private Sub msngrPassword_TextChanged() Handles msngrPassword.TextChanged
        If (msngrPassword.Text = "Password") Then
            msngrPasswordInput = False
        Else
            msngrPasswordInput = True
        End If
    End Sub

    Private Sub msngrPassword_GotFocus() Handles msngrPassword.GotFocus
        If (msngrPassword.Text = "Password") Or (msngrPassword.Text = "") Then
            msngrPassword.Text = ""
            msngrPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub msngrPassword_LostFocus() Handles msngrPassword.LostFocus
        If msngrPassword.Text = "" Then
            msngrPassword.Text = "Password"
            msngrPassword.PasswordChar = ""
        End If
    End Sub

    Private Sub msngrBae_TextChanged() Handles msngrBae.TextChanged
        If (msngrBae.Text = "Bae's username") Then
            msngrBaeInput = False
        Else
            msngrBaeInput = True
        End If
    End Sub

    Private Sub msngrBae_GotFocus() Handles msngrBae.GotFocus
        If (msngrBae.Text = "Bae's username") Or (msngrBae.Text = "") Then
            msngrBae.Text = ""
        End If
    End Sub

    Private Sub msngrBae_LostFocus() Handles msngrBae.LostFocus
        If msngrBae.Text = "" Then
            msngrBae.Text = "Bae's username"
        End If
    End Sub

    'Telegram form'
    Private Sub lblTlgrmInstructions_Click() Handles lblTlgrmInstructions.Click
        Process.Start("https://my.telegram.org")
        MsgBox("Go to ‘API development tools’ and fill out the form.\nCreate an app\nYou will get the api_id and api_hash parameters required for user authorization (to put in the config.py file)")
    End Sub

    Private Sub tlgrmUsername_TextChanged() Handles tlgrmUsername.TextChanged
        If (tlgrmUsername.Text = "Username") Then
            tlgrmUsernameInput = False
        Else
            tlgrmUsernameInput = True
        End If
    End Sub

    Private Sub tlgrmUsername_GotFocus() Handles tlgrmUsername.GotFocus
        If (tlgrmUsername.Text = "Username") Or (tlgrmUsername.Text = "") Then
            tlgrmUsername.Text = ""
        End If
    End Sub

    Private Sub tlgrmUsername_LostFocus() Handles tlgrmUsername.LostFocus
        If tlgrmUsername.Text = "" Then
            tlgrmUsername.Text = "Username"
        End If
    End Sub

    Private Sub tlgrmPhone_TextChanged() Handles tlgrmPhone.TextChanged
        If (tlgrmPhone.Text = "Phone number") Then
            tlgrmPhoneInput = False
        Else
            tlgrmPhoneInput = True
        End If
    End Sub

    Private Sub tlgrmPhone_GotFocus() Handles tlgrmPhone.GotFocus
        If (tlgrmPhone.Text = "Phone number") Or (tlgrmPhone.Text = "") Then
            tlgrmPhone.Text = ""
        End If
    End Sub

    Private Sub tlgrmPhone_LostFocus() Handles tlgrmPhone.LostFocus
        If tlgrmPhone.Text = "" Then
            tlgrmPhone.Text = "Phone number"
        End If
    End Sub

    Private Sub tlgrmAPI_ID_TextChanged() Handles tlgrmAPI_ID.TextChanged
        If (tlgrmAPI_ID.Text = "API_ID") Then
            tlgrmApiIDInput = False
        Else
            tlgrmApiIDInput = True
        End If
    End Sub

    Private Sub tlgrmAPI_ID_GotFocus() Handles tlgrmAPI_ID.GotFocus
        If (tlgrmAPI_ID.Text = "API_ID") Or (tlgrmAPI_ID.Text = "") Then
            tlgrmAPI_ID.Text = ""
        End If
    End Sub

    Private Sub tlgrmAPI_ID_LostFocus() Handles tlgrmAPI_ID.LostFocus
        If tlgrmAPI_ID.Text = "" Then
            tlgrmAPI_ID.Text = "API_ID"
        End If
    End Sub

    Private Sub tlgrmAPI_HASH_TextChanged() Handles tlgrmAPI_HASH.TextChanged
        If (tlgrmAPI_HASH.Text = "API_HASH") Then
            tlgrmApiHashInput = False
        Else
            tlgrmApiHashInput = True
        End If
    End Sub

    Private Sub tlgrmAPI_HASH_GotFocus() Handles tlgrmAPI_HASH.GotFocus
        If (tlgrmAPI_HASH.Text = "API_HASH") Or (tlgrmAPI_HASH.Text = "") Then
            tlgrmAPI_HASH.Text = ""
        End If
    End Sub

    Private Sub tlgrmAPI_HASH_LostFocus() Handles tlgrmAPI_HASH.LostFocus
        If tlgrmAPI_HASH.Text = "" Then
            tlgrmAPI_HASH.Text = "API_HASH"
        End If
    End Sub

    Private Sub tlgrmBae_TextChanged() Handles tlgrmBae.TextChanged
        If (tlgrmBae.Text = "Bae's username") Then
            tlgrmBaeInput = False
        Else
            tlgrmBaeInput = True
        End If
    End Sub

    Private Sub tlgrmBae_GotFocus() Handles tlgrmBae.GotFocus
        If (tlgrmBae.Text = "Bae's username") Or (tlgrmBae.Text = "") Then
            tlgrmBae.Text = ""
        End If
    End Sub

    Private Sub tlgrmBae_LostFocus() Handles tlgrmBae.LostFocus
        If tlgrmBae.Text = "" Then
            tlgrmBae.Text = "Bae's username"
        End If
    End Sub

    'SMS form'
    Private Sub smsBae_TextChanged() Handles smsBae.TextChanged
        If (smsBae.Text = "Bae's contact name") Then
            smsBaeInput = False
        Else
            smsBaeInput = True
        End If
    End Sub

    Private Sub smsBae_GotFocus() Handles smsBae.GotFocus
        If (smsBae.Text = "Bae's contact name") Or (smsBae.Text = "") Then
            smsBae.Text = ""
        End If
    End Sub

    Private Sub smsBae_LostFocus() Handles smsBae.LostFocus
        If smsBae.Text = "" Then
            smsBae.Text = "Bae's contact name"
        End If
    End Sub

    'WhatsApp form'
    Private Sub waBae_TextChanged() Handles waBae.TextChanged
        If (waBae.Text = "Bae's contact name") Then
            waBaeInput = False
        Else
            waBaeInput = True
        End If
    End Sub

    Private Sub waBae_GotFocus() Handles waBae.GotFocus
        If (waBae.Text = "Bae's contact name") Or (waBae.Text = "") Then
            waBae.Text = ""
        End If
    End Sub

    Private Sub waBae_LostFocus() Handles waBae.LostFocus
        If waBae.Text = "" Then
            waBae.Text = "Bae's contact name"
        End If
    End Sub

End Class