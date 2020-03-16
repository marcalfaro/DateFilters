Public Class Form1
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub f_FilterDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDate.SelectedIndex = 0
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDate.SelectedIndexChanged

        'dtpFrom.Enabled = IIf(cboDate.SelectedIndex = 1, True, False)
        'dtpTo.Enabled = IIf(cboDate.SelectedIndex = 1, True, False)

        Select Case cboDate.SelectedIndex
            Case 0, 1  'Today / Date Range
                dtpFrom.Value = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
                dtpTo.Value = Now

            Case 2  'As on Date
                dtpFrom.Value = New Date(1900, 1, 1)
                dtpTo.Value = Now

            Case 3  'Current Month
                dtpFrom.Value = New Date(Now.Year, Now.Month, 1, 0, 0, 0)
                dtpTo.Value = Now

            Case 4  'Last Month
                dtpFrom.Value = New Date(Now.Year, Now.Month - 1, 1, 0, 0, 0)
                dtpTo.Value = New Date(Now.Year, Now.Month - 1, System.DateTime.DaysInMonth(Now.Year, Now.Month - 1), 23, 59, 59)

            Case 5  'Current Week

                Dim fdw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 1)
                Dim ldw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 7)

                dtpFrom.Value = fdw
                dtpTo.Value = New Date(ldw.Year, ldw.Month, ldw.Day, 23, 59, 59)

            Case 6  'Last Week

                Dim fdw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 1).AddDays(-7)
                Dim ldw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 7).AddDays(-7)

                dtpFrom.Value = fdw
                dtpTo.Value = New Date(ldw.Year, ldw.Month, ldw.Day, 23, 59, 59)

            Case 7  'Current Year
                dtpFrom.Value = New Date(Now.Year, 1, 1, 0, 0, 0)
                dtpTo.Value = Now

            Case 8  'Last Year
                dtpFrom.Value = New Date(Now.Year - 1, 1, 1, 0, 0, 0)
                dtpTo.Value = New Date(Now.Year, 1, 1, 23, 59, 59).AddDays(-1)
        End Select
    End Sub
End Class
