using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DirectLink.Core.Utility;
using DirectLink.Main.Local.Extentions;
using DirectLink.Main.Local.Model;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DirectLink.Main.Local.ViewModels
{
    public partial class MainViewModel : ObservableBase, IViewLoadable
    {
        [ObservableProperty]
        private ObservableCollection<DropFileModel> dropFiles;
        public MainViewModel() 
        {
            this.DropFiles = new ();
        }
        public void OnLoaded(IViewable view)
        {
            if (File.Exists ("data.txt") == false)
                return;

            using (StreamReader sw = File.OpenText ("data.txt"))
            {
                string data = sw.ReadToEnd ();
                var objs = Base64String.Get<DropFileBaseModel> (data);
                this.DropFiles = new ObservableCollection<DropFileModel> (objs.Change());
            }
        }

        [RelayCommand]
        private void DropFile(DropFileModel dropFile)
        {
            this.DropFiles.Add (dropFile);
            Save (this.DropFiles.ToList ().Change());
        }

        private void Save(List<DropFileBaseModel> objs)
        {
            string base64 = Base64String.Get (objs);
            using (StreamWriter sw = File.CreateText ("data.txt"))
                sw.Write (base64);
        }
    }
}
