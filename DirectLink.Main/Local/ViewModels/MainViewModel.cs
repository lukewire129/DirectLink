using DirectLink.Main.Local.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System.Collections.ObjectModel;

namespace DirectLink.Main.Local.ViewModels
{
    public partial class MainViewModel : ObservableBase
    {
        [ObservableProperty]
        private ObservableCollection<DropFileModel> dropFiles;
        public MainViewModel() 
        {
            this.DropFiles = new ();
        }
        [RelayCommand]
        private void DropFile(DropFileModel dropFile)
        {
            this.DropFiles.Add (dropFile);
        }
    }
}
