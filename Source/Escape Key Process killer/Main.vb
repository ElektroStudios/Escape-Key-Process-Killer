' ***********************************************************************
' Assembly         : EscapeKiller
' Author           : Elektro
' Last Modified On : 08-22-2014
' ***********************************************************************
' <copyright file="Main.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

''' <summary>
''' The Main application module.
''' </summary>
Module Main

#Region " Objects "

    ''' <summary>
    ''' Register the hotkey object on the system.
    ''' </summary>
    Private WithEvents Hotkey As New GlobalHotkey(GlobalHotkey.KeyModifier.None, Keys.Escape)

    ''' <summary>
    ''' Determines whether the registered Hotkey is pressed.
    ''' </summary>
    Private HotkeyIsPressed As Boolean = False

    ''' <summary>
    ''' List of KnownErrors to manage.
    ''' </summary>
    Private KnownErrors As New Dictionary(Of String, String) From
    {
        {1, "Too many arguments."},
        {2, "Process not found."},
        {3, "One of the passed parameter is null or empty."},
        {4, "Parameter 'Recursive' has a wrong value."},
        {5, "Parameter 'KillChilds' has a wrong value."},
        {6, "Please specify the application name to kill."},
        {9999, "Unknown Error."}
    }

#End Region

#Region " Properties "

    ''' <summary>
    ''' Indicates the application to kill.
    ''' </summary>
    Private Property AppToKill As String = String.Empty

    ''' <summary>
    ''' Indicates whether to kill all instances of a process, this means recursive kill.
    ''' </summary>
    Private Property RecursiveKill As Boolean = False

    ''' <summary>
    ''' Indicates whether to kill the child processes of a process.
    ''' </summary>
    Private Property KillChilds As Boolean = False

#End Region

#Region " Entry Point "

    ''' <summary>
    ''' Defines the entry point of the application.
    ''' </summary>
    Public Sub Main()
        Console.Title = HelpSection.Title
        ParseArguments()
        KeepOnListen() ' Wait for hotkey press event.
    End Sub

#End Region

#Region " Methods "

    ''' <summary>
    ''' Parses the Arguments passed in this application.
    ''' </summary>
    Private Sub ParseArguments()

        Dim Value As String = String.Empty

        Select Case My.Application.CommandLineArgs.Count

            Case 0
                PrintHelp()

            Case 1 To 3
                For Each Argument As String In My.Application.CommandLineArgs

                    Select Case True

                        Case Argument.StartsWith("/?")
                            PrintHelp()

                        Case String.IsNullOrEmpty(Argument)
                            PrintError(3)

                        Case Argument.StartsWith("/Recursive", StringComparison.InvariantCultureIgnoreCase)
                            If Argument.Equals("/Recursive", StringComparison.InvariantCultureIgnoreCase) Then
                                RecursiveKill = True
                            Else
                                PrintError(4)
                            End If

                        Case Argument.StartsWith("/KillChilds", StringComparison.InvariantCultureIgnoreCase)
                            If Argument.Equals("/KillChilds", StringComparison.InvariantCultureIgnoreCase) Then
                                KillChilds = True
                            Else
                                PrintError(4)
                            End If

                        Case Else
                            AppToKill = Argument.Trim

                    End Select

                Next Argument

            Case Else
                PrintError(1)

        End Select

        If String.IsNullOrEmpty(AppToKill) Then
            PrintError(6)
        Else
            Console.WriteLine(String.Format("Escape Killer is ready, waiting for user-input..."))
        End If

    End Sub

    ''' <summary>
    ''' Keep listenning for the hotkey press event.
    ''' </summary>
    Private Sub KeepOnListen()

        Do Until HotkeyIsPressed ' Until the user press ESCAPE key...
            Application.DoEvents() ' ...Do Nothing.
        Loop
        Select Case RecursiveKill

            Case True
                Console.WriteLine(String.Format("{0} instances of process '{1}' killed successfully.", CStr(KillCount), AppToKill))

            Case False
                Console.WriteLine(String.Format("Process '{0}' killed successfully.", AppToKill))

        End Select

        Environment.Exit(0) ' Exit Succesfully.

    End Sub

    ''' <summary>
    ''' Print the Help section and exits from the application.
    ''' </summary>
    Private Sub PrintHelp()

        Console.WriteLine(HelpSection.Logo)
        Console.WriteLine(HelpSection.Help)

        Environment.Exit(0) ' Exit Succesfully.

    End Sub

    ''' <summary>
    ''' Prints an Error and exits from the application.
    ''' </summary>
    Private Sub PrintError(ByVal ErrorID As Integer)

        Console.WriteLine("[x] ERROR: " & KnownErrors(ErrorID))
        Environment.Exit(ErrorID) ' Exit with given Error-Code.

    End Sub

#End Region

#Region " Event Handlers "

    ''' <summary>
    ''' Handles the Press event of the Hotkey instance.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="ESCAPE_Killer.GlobalHotkey.HotKeyEventArgs"/> instance containing the event data.</param>
    Private Sub HotKey_Press(ByVal sender As Object, ByVal e As GlobalHotkey.HotKeyEventArgs) _
    Handles Hotkey.Press

        HotkeyIsPressed = True
        Hotkey.Unregister()

        Select Case RecursiveKill

            Case True

                If Not Kill.ProcessesOf(ProcessName:=AppToKill, KillChildProcesses:=KillChilds) Then
                    PrintError(2)
                End If

            Case False
                If Not Kill.Process(ProcessName:=AppToKill, KillChildProcesses:=KillChilds) Then
                    PrintError(2)
                End If

        End Select

    End Sub

#End Region

End Module