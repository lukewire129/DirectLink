using DirectLink.Main.Local.Model;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            DropFileCommand?.Execute (new DropFileModel ()
            {
                FileName = data[0]
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
