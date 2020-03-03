Imports System.Management ' Imports libraries for System Managment. Needed for brigtness control and sign-off.
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Shutdown
        System.Diagnostics.Process.Start("shutdown", "-s -t 00")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Restart
        System.Diagnostics.Process.Start("shutdown", "-r -t 00")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Sleep/Log Out
        System.Diagnostics.Process.Start("shutdown", "-l")
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll ' Brightness slider
        'These 3 lines start instances and objects needed to contol brightness,
        Dim mclass As New ManagementClass("WmiMonitorBrightnessMethods")
        mclass.Scope = New ManagementScope("\\.\root\wmi")
        Dim instances As ManagementObjectCollection = mclass.GetInstances
        'These lines are what actually do things, like send +1 birhgtness to the System.Managment Profile.
        For Each instance As ManagementObject In instances
            Dim timeout As ULong = 1
            Dim brightness As UShort = CUShort(TrackBar1.Value * 10)
            Dim args As Object() = New Object() {timeout, brightness}
            instance.InvokeMethod("WmiSetBrightness", args)
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show("SystemHub Version 1 by GibbieMonster/BlockArchitech - Help my horrible code by submitting a pull request to GitHub", "About SystemHub")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("Contributers - GibbieMonster/BlockArchitech - Sign your name here!", "Awesome People Who Made This Project Possible")
    End Sub
End Class
