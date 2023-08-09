using Newtonsoft.Json;
using System.Windows.Media;

namespace DirectLink.Main.Local.Model;

public class DropFileModel
{
    public string FileName { get; set; }
    public string FileFullName { get; set; }
    [JsonProperty (NullValueHandling = NullValueHandling.Ignore)]
    public ImageSource FileIcon { get; set; }
}
