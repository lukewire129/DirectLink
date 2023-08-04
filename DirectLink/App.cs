using DirectLink.Forms.UI.Views;
using Jamesnet.Wpf.Controls;
using System.Windows;

namespace DirectLink;

public class App : JamesApplication
{
    protected override Window CreateShell()
    {
        return new MainWindow ();
    }
}