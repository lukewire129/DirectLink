using AutoRunProc.Main.UI.Views;
using Jamesnet.Wpf.Controls;
using System.Windows;

namespace AutoRunProc;

public class App : JamesApplication
{
    protected override Window CreateShell()
    {
        return new MainWindow ();
    }
}
