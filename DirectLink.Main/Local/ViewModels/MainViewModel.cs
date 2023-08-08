using DirectLink.Main.Local.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System.Collections.ObjectModel;
using Jamesnet.Wpf.Controls;
using System.IO;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using DirectLink.Core.Utility;

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
                var objs = Base64String.Get<DropFileModel>(data);
                this.DropFiles = new ObservableCollection<DropFileModel> (objs);
            }
        }

        [RelayCommand]
        private void DropFile(DropFileModel dropFile)
        {
            this.DropFiles.Add (dropFile);
            Save (this.DropFiles.ToList ());
        }

        private void Save(List<DropFileModel> objs)
        {
            string base64 = Base64String.Get (objs);
            using (StreamWriter sw = File.CreateText ("data.txt"))
                sw.Write (base64);
        }
    }
}
