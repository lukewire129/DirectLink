﻿using System.Windows.Media.Imaging;

namespace DirectLink.Main.Local.Model;

public class DropFileModel
{
    public string FileName { get; set; }
    public string FileFullName { get; set; }
    public BitmapSource FileIcon { get; set; }
}
