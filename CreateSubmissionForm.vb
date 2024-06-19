Imports System.Diagnostics

Public Class CreateSubmissionForm

    Private stopwatch As New Stopwatch()

    Public Sub New()
        InitializeComponent()
        ' Initialize other components or settings here if needed
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable KeyPreview to capture key events at the form level
        Me.KeyPreview = True

        ' Set btnSave as the default button (Enter key will trigger its Click event)
        Me.AcceptButton = btnSubmit

        ' Initialize stopwatch
        stopwatch = New Stopwatch()
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Check for Ctrl + S shortcut to submit the form
        If e.Control AndAlso e.KeyCode = Keys.S Then
            ' Call your submit logic
            SubmitForm()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Handle btnSave Click event (submit form)
        SubmitForm()
    End Sub

    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        ' Handle btnStartStop Click event (start/stop stopwatch)
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
    End Sub

    Private Sub SubmitForm()
        ' Validate form inputs (optional)

        ' Get form data
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhone.Text
        Dim githubLink As String = txtGitHub.Text
        Dim stopwatchTime As String = stopwatch.Elapsed.ToString("hh\:mm\:ss")

        ' Example validation - ensure required fields are filled
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter Name and Email.")
            Return
        End If

        ' Call API or save to database (placeholder for actual submission logic)
        Dim success As Boolean = SubmitToBackend(name, email, phone, githubLink, stopwatchTime)

        If success Then
            MessageBox.Show("Submission successful.")
            ResetForm()
        Else
            MessageBox.Show("Submission failed. Please try again.")
        End If
    End Sub

    Private Function SubmitToBackend(name As String, email As String, phone As String, githubLink As String, stopwatchTime As String) As Boolean
        ' Placeholder for actual API call or database submission logic
        ' Simulate success for demonstration
        Return True
    End Function

    Private Sub ResetForm()
        ' Clear form fields or reset necessary states
        txtName.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""
        txtGitHub.Text = ""
        stopwatch.Reset()
    End Sub

End Class
