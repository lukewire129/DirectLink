using DirectLink.Main.Local.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DirectLink.Main.Local.Extentions
{
    public static class ModelExtentions
    {
        public static List<DropFileBaseModel> Change(this List<DropFileModel> list)
        {
            List<DropFileBaseModel> result = new ();
            foreach(var dropModel in list)
            {
                result.Add (new DropFileBaseModel ()
                {
                    FileName = dropModel.FileName,
                    FileFullName = dropModel.FileFullName,
                });
            }

            return result;
        }
        public static List<DropFileModel> Change(this List<DropFileBaseModel> list)
        {
            List<DropFileModel> result = new ();
            foreach (var dropModel in list)
            {
                result.Add (new DropFileModel ()
                {
                    FileName = dropModel.FileName,
                    FileFullName = dropModel.FileFullName,
                    FileIcon = GetBitmapSource(Icon.ExtractAssociatedIcon (dropModel.FileFullName))
                });
            }

            return result;
        }

        private static BitmapSource GetBitmapSource(Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon (
                   icon.Handle,
                   new Int32Rect (0, 0, icon.Width, icon.Height),
                   BitmapSizeOptions.FromEmptyOptions ());
        }
    }
}
