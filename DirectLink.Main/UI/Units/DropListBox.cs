using DirectLink.Main.Local.Model;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;

namespace DirectLink.Main.UI.Units
{
    public class DropListBox : ListBox
    {
        public ICommand DropFileCommand
        {
            get { return (ICommand)GetValue (DropFileCommandProperty); }
            set { SetValue (DropFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DropFileCommandProperty =
            DependencyProperty.Register ("DropFileCommand", typeof (ICommand), typeof (DropListBox), new PropertyMetadata (null));


        static DropListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropListBox), new FrameworkPropertyMetadata(typeof(DropListBox)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DropListBoxItem ();
        }
        public DropListBox()
        {
            AllowDrop = true;
            DragEnter += DropBox_DragEnter;
            DragLeave += DropBox_DragLeave;
            DragOver += DropBox_DragOver;
            Drop += DropBox_Drop;
        }

        private void DropBox_Drop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData (DataFormats.FileDrop);

            ImageSource imageSource = null;
            try
            {
                Icon programIcon = Icon.ExtractAssociatedIcon (data[0]); // 아이콘 추출
                imageSource = Imaging.CreateBitmapSourceFromHIcon (
                   programIcon.Handle,
                   new Int32Rect (0, 0, programIcon.Width, programIcon.Height),
                   BitmapSizeOptions.FromEmptyOptions ());
            }
            catch
            {

            }

            DropFileCommand?.Execute (new DropFileModel ()
            {
                FileName = Path.GetFileName(data[0]),
                FileFullName = data[0],
                FileIcon = imageSource,
            });
        }

        private void DropBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (typeof (ListBoxItem)))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DropBox_DragLeave(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
        }

        private void DropBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}
