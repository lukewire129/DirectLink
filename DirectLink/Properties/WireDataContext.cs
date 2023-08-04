using DirectLink.Forms.Local.ViewModel;
using DirectLink.Forms.UI.Views;
using DirectLink.Main.Local.ViewModels;
using DirectLink.Main.UI.Views;
using Jamesnet.Wpf.Global.Location;

namespace DirectLink.Properties;

public class WireDataContext : ViewModelLocationScenario
{
    protected override void Match(ViewModelLocatorCollection items)
    {
        items.Register<MainWindow, MainWindowViewModel> ();
        items.Register<MainContent, MainViewModel> ();
    }
}
