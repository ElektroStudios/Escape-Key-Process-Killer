# Escape Key Process killer (EscKeyProcKill.exe)

### Command-line application to terminate a specified running process when you press ESCAPE key

[screenshot](/Images/app.ico)

------------------

## 👋 Introduction

This is a simple command-line application that waits on background until you press the ESCAPE key on your keyboard to terminate the specified process.

## 📝 Requirements

- Microsoft Windows OS.

## 🤖 Getting started

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

## 🔄 Change Log

Explore the complete list of changes, bug fixes, and improvements across different releases by clicking [here](/Docs/CHANGELOG.md).

## ⚠️ Disclaimer:

This Work (the repository and the content provided in) is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the Work or the use or other dealings in the Work.

## 💪 Contributing

Your contribution is highly appreciated!. If you have any ideas, suggestions, or encounter issues, feel free to open an issue by clicking [here](https://github.com/ElektroStudios/Escape-Key-Process-Killer/issues/new/choose). 

Your input helps make this Work better for everyone. Thank you for your support! 🚀

## 💰 Beyond Contribution 

This work is distributed for educational purposes and without any profit motive. However, if you find value in my efforts and wish to support and motivate my ongoing work, you may consider contributing financially through the following options:

 - ### Paypal:
    You can donate any amount you like via **Paypal** by clicking on this button:

    [![Donation Account](Images/Paypal_Donate.png)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E4RQEV6YF5NZY)

 - ### Envato Market:
   If you are a .NET developer, you may want to explore '**DevCase Class Library for .NET**', a huge set of APIs that I have on sale.
   Almost all reusable code that you can find across my works is condensed, refined and provided through DevCase Class Library.

    Check out the product:
    
   [![DevCase Class Library for .NET](Images/DevCase_Banner.png)](https://codecanyon.net/item/elektrokit-class-library-for-net/19260282)

<u>**Your support means the world to me! Thank you for considering it!**</u> 👍
