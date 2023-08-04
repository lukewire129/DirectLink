using DirectLink.Forms.UI.Units;
using Jamesnet.Wpf.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DirectLink.Forms.UI.Views;

public class MainWindow : JamesWindow
{
    static MainWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata (typeof (MainWindow), new FrameworkPropertyMetadata (typeof (MainWindow)));
    }
    public MainWindow()
    {
        WindowStyle = WindowStyle.None;
        ResizeMode = ResizeMode.CanResize;
        AllowsTransparency = true;
    }
    public override void OnApplyTemplate()
    {
        if (GetTemplateChild ("PART_CloseButton") is Button btn)
        {
            btn.Click += (s, e) => Close ();
        }
        if (GetTemplateChild ("PART_DragBar") is DraggableBar bar)
        {
            bar.MouseDown += WindowDragMove;
        }
    }
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed (e);
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            GetWindow (this).DragMove ();
        }
    }
}
