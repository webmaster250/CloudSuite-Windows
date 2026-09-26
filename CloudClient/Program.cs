using System.Net.Http.Json;
using System.Text.Json;
namespace CloudClient;
internal static class Program { [STAThread] static void Main(){ApplicationConfiguration.Initialize();Application.Run(new ClientApp());}}
public sealed class ClientApp:Form {
 readonly TextBox server=new(){Dock=DockStyle.Top,Text="http://localhost:5050"}; readonly ListBox files=new(){Dock=DockStyle.Fill}; readonly Label status=new(){Dock=DockStyle.Bottom,Height=30,Text="Bereit"}; readonly HttpClient http=new();
 public ClientApp(){Text="Cloud Client";Width=850;Height=600;var b=new Button{Dock=DockStyle.Top,Height=38,Text="Meine Cloud öffnen"};b.Click+=async(s,e)=>await LoadFiles();Controls.Add(files);Controls.Add(status);Controls.Add(b);Controls.Add(server);}
 async Task LoadFiles(){try{status.Text="Verbinde…";var json=await http.GetStringAsync(server.Text.TrimEnd('/')+"/api/files");files.Items.Clear();foreach(var x in JsonDocument.Parse(json).RootElement.EnumerateArray())files.Items.Add((x.GetProperty("directory").GetBoolean()?"📁 ":"📄 ")+x.GetProperty("name").GetString());status.Text="Verbunden";}catch(Exception ex){status.Text="Fehler: "+ex.Message;}}
}
