Public Class frmMain

    Private Sub btnWhatsapp_Click(sender As Object, e As EventArgs) Handles btnWhatsapp.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub btnTelegram_Click(sender As Object, e As EventArgs) Handles btnTelegram.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.FixedSingle
        btnWhatsapp.BorderStyle = BorderStyle.None
    End Sub

    Private Sub btnSms_Click(sender As Object, e As EventArgs) Handles btnSms.Click
        btnMessenger.BorderStyle = BorderStyle.None
        btnSms.BorderStyle = BorderStyle.FixedSingle
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
    End Sub

    Private Sub btnMessenger_Click(sender As Object, e As EventArgs) Handles btnMessenger.Click
        btnMessenger.BorderStyle = BorderStyle.FixedSingle
        btnSms.BorderStyle = BorderStyle.None
        btnTelegram.BorderStyle = BorderStyle.None
        btnWhatsapp.BorderStyle = BorderStyle.None
        lblDefault.Visible = True

        pnlDefault.Visible = False
        pnlMessenger.Visible = True
    End Sub

    Private Sub btnGithub_Click(sender As Object, e As EventArgs) Handles btnGithub.Click
        Process.Start("https://github.com/lorcalhost/RomanceBreaker")
    End Sub

    Private Sub lblGithub_Click(sender As Object, e As EventArgs) Handles lblGithub.Click
        Process.Start("https://github.com/lorcalhost/RomanceBreaker")
    End Sub

    Private Sub btnOff_Click(sender As Object, e As EventArgs) Handles btnOff.Click
        btnOff.Visible = False
        btnOn.Visible = True
        lblOnOff.Text = "Stop"
    End Sub

    Private Sub btnOn_Click(sender As Object, e As EventArgs) Handles btnOn.Click
        btnOff.Visible = True
        btnOn.Visible = False
        lblOnOff.Text = "Start"
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        If IO.Directory.Exists(appDataPath + "\Python\Python37") = False Then
            MsgBox("Python 3.7 was not found on this machine, install it before running RomanceBreaker!")
            Process.Start("https://www.python.org/downloads/")
            Application.Exit()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Dim msngrUsernameInput = False
    Dim msngrPasswordInput = False
    Dim msngrBaeInput = False

    Private Sub msngrUsername_TextChanged(sender As Object, e As EventArgs) Handles msngrUsername.TextChanged
        If (msngrUsername.Text Is "") Then
            msngrUsernameInput = False
        Else
            msngrUsernameInput = True
        End If
    End Sub

    Private Sub msngrPassword_TextChanged(sender As Object, e As EventArgs) Handles msngrPassword.TextChanged
        If (msngrUsername.Text Is "") Then
            msngrPasswordInput = False
        Else
            msngrPasswordInput = True
        End If
    End Sub
End Class
