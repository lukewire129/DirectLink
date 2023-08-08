using System.Windows;
using System.Windows.Controls;

namespace DirectLink.Main.UI.Units
{
    public class DropListBoxItem : ListBoxItem
    {
        static DropListBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata (typeof (DropListBoxItem), new FrameworkPropertyMetadata (typeof (DropListBoxItem)));
        }
    }
}
