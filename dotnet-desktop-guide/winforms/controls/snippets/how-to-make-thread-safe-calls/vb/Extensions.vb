Imports System.Runtime.CompilerServices
Imports System.Threading

Module ValueTaskExtensions

    ''' <summary>
    ''' Converts a Func(Of Task) into a Func(Of ValueTask).
    ''' </summary>
    <Extension>
    Public Function AsValueTask(work As Func(Of Task)) As Func(Of ValueTask)
        Return Function()
                   Return New ValueTask(work())
               End Function
    End Function

    ''' <summary>
    ''' Converts a Func(Of Task(Of T)) into a Func(Of ValueTask(Of T)).
    ''' </summary>
    <Extension>
    Public Function AsValueTask(Of T)(work As Func(Of Task(Of T))) As Func(Of ValueTask(Of T))
        Return Function()
                   Return New ValueTask(Of T)(work())
               End Function
    End Function

    ''' <summary>
    ''' Converts a Func(Of CancellationToken, Task) into a Func(Of CancellationToken, ValueTask).
    ''' </summary>
    <Extension>
    Public Function AsValueTask(work As Func(Of CancellationToken, Task)) As Func(Of CancellationToken, ValueTask)
        Return Function(ct As CancellationToken)
                   Return New ValueTask(work(ct))
               End Function
    End Function

    ''' <summary>
    ''' Converts a Func(Of CancellationToken, Task(Of T)) into a Func(Of CancellationToken, ValueTask(Of T)).
    ''' </summary>
    <Extension>
    Public Function AsValueTask(Of T)(work As Func(Of CancellationToken, Task(Of T))) As Func(Of CancellationToken, ValueTask(Of T))
        Return Function(ct As CancellationToken)
                   Return New ValueTask(Of T)(work(ct))
               End Function
    End Function
End Module
