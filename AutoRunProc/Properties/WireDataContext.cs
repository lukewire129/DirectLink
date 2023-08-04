using AutoRunProc.Main.Local.ViewModel;
using AutoRunProc.Main.UI.Views;
using Jamesnet.Wpf.Global.Location;

namespace AutoRunProc.Properties;

public class WireDataContext : ViewModelLocationScenario
{
    protected override void Match(ViewModelLocatorCollection items)
    {
        items.Register<MainWindow, MainWindowViewModel> ();
    }
}
