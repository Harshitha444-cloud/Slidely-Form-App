Public Class ViewSubmissionsForm

    Private submissions As New List(Of Submission)()
    Private currentIndex As Integer = 0

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call API to fetch submissions when the form loads
        FetchSubmissions()
    End Sub

    Private Sub FetchSubmissions()
        ' Implement API call to fetch submissions from backend
        ' You will handle how to retrieve submissions and populate 'submissions' list
        ' For now, let's simulate some data for demonstration
        submissions.Add(New Submission("John Doe", "john.doe@example.com", "1234567890", "https://github.com/johndoe", "00:15:30"))
        submissions.Add(New Submission("Jane Smith", "jane.smith@example.com", "9876543210", "https://github.com/janesmith", "01:20:45"))

        DisplaySubmission(currentIndex)
    End Sub

    Private Sub DisplaySubmission(index As Integer)
        If index >= 0 AndAlso index < submissions.Count Then
            Dim submission = submissions(index)
            txtName.Text = submission.Name
            txtEmail.Text = submission.Email
            txtPhone.Text = submission.Phone
            txtGitHub.Text = submission.GitHubLink
            txtStopwatchTime.Text = submission.StopwatchTime
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

End Class

' Class to represent a submission
Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GitHubLink As String
    Public Property StopwatchTime As String ' Assuming this is in HH:mm:ss format

    Public Sub New(name As String, email As String, phone As String, githubLink As String, stopwatchTime As String)
        Me.Name = name
        Me.Email = email
        Me.Phone = phone
        Me.GitHubLink = githubLink
        Me.StopwatchTime = stopwatchTime
    End Sub
End Class
