''' <summary>
''' Kills a process.
''' </summary>
Module Kill

    ''' <summary>
    ''' Indicates the amount of killed instances.
    ''' </summary>
    Friend KillCount As Integer = 0I

    ' Kill Process
    ' ( By Elektro )
    '
    ' Instructions:
    ' 1. Add a reference to "System.Management".
    '
    ' Usage Examples:
    ' MsgBox(KillProcess("notepad"))
    ' MsgBox(KillProcess("notepad.exe"))
    ' Process.Start("CMD.exe") : MsgBox(KillProcess(Process.GetCurrentProcess().ProcessName, KillChildProcesses:=True))
    '
    ''' <summary>
    ''' Kills the first ocurrence a running process.
    ''' </summary>
    ''' <param name="ProcessName">
    ''' Indicates the process name to find.
    ''' </param>
    ''' <param name="KillChildProcesses">
    ''' Indicates wether the child processes of the parent process should be killed.
    ''' </param>
    ''' <returns><c>true</c> if process is found and killed succeeds, <c>false</c> otherwise.</returns>
    Friend Function [Process](ByVal ProcessName As String,
                                 Optional ByVal KillChildProcesses As Boolean = False) As Boolean

        If ProcessName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
            ProcessName = ProcessName.Remove(ProcessName.Length - ".exe".Length)
        End If

        Dim WMIQuery As String = "Select * From Win32_Process Where ParentProcessID={0}"

        Using p As Process = Diagnostics.Process.GetProcessesByName(ProcessName).FirstOrDefault

            Select Case p IsNot Nothing

                Case True

                    If KillChildProcesses Then ' Kill it's children processes.

                        Using Childs As New Management.ManagementObjectSearcher(String.Format(WMIQuery, CStr(p.Id)))

                            For Each mo As Management.ManagementObject In Childs.[Get]()

                                [Process](mo("Name"), KillChildProcesses:=True)
                                p.Kill()

                            Next mo

                        End Using ' Childs
                        Return True

                    Else
                        p.Kill()
                        Return True

                    End If ' KillChildProcesses

                Case Else
                    Return False

            End Select

        End Using

    End Function

    ' Kill Processes Of
    ' ( By Elektro )
    '
    ' Instructions:
    ' 1. Add a reference to "System.Management".
    '
    ' Usage Examples:
    ' MsgBox(KillProcessesOf("notepad"))
    ' MsgBox(KillProcessesOf("notepad.exe"))
    ' Process.Start("CMD.exe") : MsgBox(KillProcessesOf(Process.GetCurrentProcess().ProcessName, KillChildProcesses:=True))
    '
    ''' <summary>
    ''' Kills all the ocurrences of a running process.
    ''' </summary>
    ''' <param name="ProcessName">
    ''' Indicates the process name to find.
    ''' </param>
    ''' <param name="KillChildProcesses">
    ''' Indicates wether the child processes of the parent process should be killed.
    ''' </param>
    ''' <returns><c>true</c> if process is found and killed succeeds, <c>false</c> otherwise.</returns>
    Friend Function ProcessesOf(ByVal ProcessName As String,
                                Optional ByVal KillChildProcesses As Boolean = False) As Boolean

        If ProcessName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
            ProcessName = ProcessName.Remove(ProcessName.Length - ".exe".Length)
        End If

        Dim Processes As Process() = Diagnostics.Process.GetProcessesByName(ProcessName)
        If Processes.Count = 0 Then
            Return False
        End If

        For Each p As Process In Processes

            Select Case KillChildProcesses
                Case False
                    Try
                        p.Kill()
                        KillCount += 1
                    Catch ex As System.ComponentModel.Win32Exception
                    End Try

                Case True

                    [Process](ProcessName, KillChildProcesses)
            End Select

        Next p

        Return True

    End Function

End Module
