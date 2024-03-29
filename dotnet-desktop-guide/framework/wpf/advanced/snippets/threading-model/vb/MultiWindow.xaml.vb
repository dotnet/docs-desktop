﻿'<full>
Imports System.Threading

Public Class MultiWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ThreadStatusItem.Content = $"Thread ID: {Thread.CurrentThread.ManagedThreadId}"
    End Sub

    '<delay>
    Private Sub PauseButton_Click(sender As Object, e As RoutedEventArgs)
        Task.Delay(TimeSpan.FromSeconds(5)).Wait()
    End Sub
    '</delay>

    '<buttons>
    Private Sub SameThreadWindow_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New MultiWindow()
        window.Show()
    End Sub

    Private Sub NewThreadWindow_Click(sender As Object, e As RoutedEventArgs)
        Dim newWindowThread = New Thread(AddressOf ThreadStartingPoint)
        newWindowThread.SetApartmentState(ApartmentState.STA)
        newWindowThread.IsBackground = True
        newWindowThread.Start()
    End Sub
    '</buttons>

    '<thread>
    Private Sub ThreadStartingPoint()
        Dim window As New MultiWindow()
        window.Show()

        System.Windows.Threading.Dispatcher.Run()
    End Sub
    '</thread>
End Class
'</full>
