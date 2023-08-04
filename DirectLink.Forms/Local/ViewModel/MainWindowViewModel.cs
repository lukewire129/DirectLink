using DirectLink.Core.Names;
using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;

namespace DirectLink.Forms.Local.ViewModel;

public class MainWindowViewModel : ObservableObject, IViewLoadable
{
    protected readonly IEventAggregator _ea;
    protected readonly IRegionManager _regionManager;
    protected readonly IContainerProvider _containerProvider;

    public MainWindowViewModel(IEventAggregator ea,
                            IRegionManager regionManager,
                            IContainerProvider containerProvider)
    {
        this._ea = ea;
        this._regionManager = regionManager;
        this._containerProvider = containerProvider;
    }
    public void OnLoaded(IViewable view)
    {
        IRegion contentRegion = this._regionManager.Regions[RegionNameManager.MainRegion];
        IViewable currentContent = this._containerProvider.Resolve<IViewable> ("Main");
        if (!contentRegion.Views.Contains (currentContent))
        {
            contentRegion.Add (currentContent);
        }
        contentRegion.Activate (currentContent);
    }
}