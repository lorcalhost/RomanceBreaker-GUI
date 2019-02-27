Public Class frmMain

    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2
    Private Const WM_NCHITTEST As Integer = &H84

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)

        If m.Msg = WM_NCHITTEST AndAlso m.Result = HTCLIENT Then
            m.Result = HTCAPTION
        End If
    End Sub

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
    Private waBae = False

    Private Sub Reset_Inputs()
        msngrUsernameInput = False
        msngrPasswordInput = False
        msngrBaeInput = False
        smsBaeInput = False
        tlgrmUsernameInput = False
        tlgrmPhoneInput = False
        tlgrmApiIDInput = False
        tlgrmApiHashInput = False
        tlgrmBaeInput = False
        waBae = False
    End Sub

    Private Sub btnWhatsapp_Click() Handles btnWhatsapp.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.FixedSingle
        currentMode = 4
        Reset_Inputs()
    End Sub

    Private Sub btnTelegram_Click() Handles btnTelegram.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.FixedSingle
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 3
        Reset_Inputs()

        pnlDefault.Visible = False
        pnlMessenger.Visible = False
        pnlTelegram.Visible = True
    End Sub

    Private Sub btnSms_Click() Handles btnSms.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.FixedSingle
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 2
        Reset_Inputs()
    End Sub

    Private Sub btnMessenger_Click() Handles btnMessenger.Click
        btnMessenger.BorderStyle = BorderStyle.FixedSingle
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
        currentMode = 1
        Reset_Inputs()

        pnlDefault.Visible = False
        pnlMessenger.Visible = True
        pnlTelegram.Visible = False
    End Sub

    Private Sub btnGithub_Click() Handles btnGithub.Click
        Process.Start("https://github.com/lorcalhost/RomanceBreaker")
    End Sub

    Private Sub lblGithub_Click() Handles lblGithub.Click
        btnGithub_Click()
    End Sub

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

            If currentMode Like 1 Then
                If msngrUsernameInput And msngrPasswordInput And msngrBaeInput Then
                    Dim user As String = msngrUsername.Text
                    Dim pass As String = msngrPassword.Text
                    Dim bae As String = msngrBae.Text
                    console.run("python %programfiles%\RomanceBreaker\messengerRB.py " & user & " " & pass & " " & bae)
                Else
                    MsgBox("Username, Password or Bae field are not complete!")
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
    End Sub

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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub msngrUsername_TextChanged(sender As Object, e As EventArgs) Handles msngrUsername.TextChanged
        If (msngrUsername.Text Is "") Then
            msngrUsernameInput = False
        Else
            msngrUsernameInput = True
        End If
    End Sub

    Private Sub msngrPassword_TextChanged() Handles msngrPassword.TextChanged
        If (msngrPassword.Text Is "") Then
            msngrPasswordInput = False
        Else
            msngrPasswordInput = True
        End If
    End Sub

    Private Sub msngrBae_TextChanged(sender As Object, e As EventArgs) Handles msngrBae.TextChanged
        If (msngrBae.Text Is "") Then
            msngrBaeInput = False
        Else
            msngrBaeInput = True
        End If
    End Sub

    Private Sub btnEdit_Click() Handles btnEdit.Click
        console.run("notepad %programfiles%\RomanceBreaker\config.py")
    End Sub

    Private Sub lblEdit_Click() Handles lblEdit.Click
        btnEdit_Click()
    End Sub

    Private Sub lblTlgrmInstructions_Click() Handles lblTlgrmInstructions.Click
        Process.Start("https://my.telegram.org")
        MsgBox("Go to ‘API development tools’ and fill out the form.\nCreate an app\nYou will get the api_id and api_hash parameters required for user authorization (to put in the config.py file)")
    End Sub

End Class