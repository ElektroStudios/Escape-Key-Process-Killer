' ***********************************************************************
' Author           : Elektro
' Last Modified On : 12-04-2013
' ***********************************************************************
' <copyright file="Help.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

''' <summary>
''' Contains the CommandLine-Interface Help things.
''' </summary>
Public Class HelpSection

    ''' <summary>
    ''' Indicates the application title.
    ''' </summary>
    Public Shared ReadOnly Title As String =
        "Escape Key Process Killer .:: By ElektroStudios ::."

    ''' <summary>
    ''' Indicates the application logotype.
    ''' </summary>
    Public Shared ReadOnly Logo As String = <a><![CDATA[
___________ __________________     _____ _____________________
\_   _____//   _____/\_   ___ \   /  _  \\______   \_   _____/
 |    __)_ \_____  \ /    \  \/  /  /_\  \|     ___/|    __)_ 
 |        \/        \\     \____/    |    \    |    |        \
/_______  /_______  / \______  /\____|__  /____|   /_______  /
        \/        \/         \/         \/                 \/ 
 ____  __.__.__  .__                                          
|    |/ _|__|  | |  |   ___________                           
|      < |  |  | |  | _/ __ \_  __ \                          
|    |  \|  |  |_|  |_\  ___/|  | \/                          
|____|__ \__|____/____/\___  >__|            By ElektroStudios
        \/                 \/     
        
https://github.com/ElektroStudios/Escape-Key-Process-Killer
]]></a>.Value

    ''' <summary>
    ''' Indicates the application help.
    ''' </summary>
    Public Shared ReadOnly Help As String = <a><![CDATA[
[+] Syntax:

    EscKeyProcKill.exe [SWITCHES] [PROCESS NAME]

[+] Switches:

    /Recursive  | Terminate all the occurrences of processes that matches [PROCESS NAME].
                | If this switch is not specified, only the first occurrence of process is terminated.
                |
    /KillChilds | Terminate the specified process and any created child process.
                |
    /?          | Shows this help.

[+] Examples:

    EscKeyProcKill.exe "notepad.exe"
    (Terminate the first occurrence of a process that matches the name "Notepad.exe")

    EscKeyProcKill.exe /Recursive "notepad.exe"
    (Terminate all the occurrences of processes that matches the name "notepad.exe")

    EscKeyProcKill.exe /KillChilds "notepad.exe"
    (Terminate the first occurrence of a process that matches the name "notepad.exe",
     and also terminate any child process created by the process.)

    EscKeyProcKill.exe /Recursive /KillChilds "notepad.exe"
    (Terminate all the occurrences of processes that matches the name "notepad.exe",
     and also terminate any child process created by the processes.)

]]></a>.Value

End Class