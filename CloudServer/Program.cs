using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace CloudServer;
internal static class Program {
 [STAThread] static void Main() {
  ApplicationConfiguration.Initialize();
  var app=new ServerApp();
  Task.Run(()=>app.RunApiAsync());
  Application.Run(app);
 }
}
public sealed class ServerApp:Form {
 readonly ListBox drives=new(){Dock=DockStyle.Fill}; readonly TextBox root=new(){Dock=DockStyle.Top,PlaceholderText="Cloud-Datenordner"}; readonly Label status=new(){Dock=DockStyle.Bottom,Height=30,Text="Server bereit auf Port 5050"};
 public ServerApp(){
  Text="Cloud Server"; Width=900; Height=600;
  var choose=new Button{Text="Ordner auswählen",Dock=DockStyle.Top,Height=38};
  choose.Click+=(s,e)=>{using var d=new FolderBrowserDialog();if(d.ShowDialog()==DialogResult.OK)root.Text=d.SelectedPath;};
  Controls.Add(drives);Controls.Add(status);Controls.Add(choose);Controls.Add(root);
  foreach(var d in DriveInfo.GetDrives().Where(x=>x.IsReady)) drives.Items.Add($"{d.Name}  {d.DriveFormat}  Frei: {d.AvailableFreeSpace/1073741824:N0} GB / {d.TotalSize/1073741824:N0} GB");
 }
 public async Task RunApiAsync(){
  var listener=new HttpListener(); listener.Prefixes.Add("http://localhost:5050/"); listener.Start();
  while(true){var c=await listener.GetContextAsync(); try {
   var p=c.Request.Url?.AbsolutePath??"/";
   if(p=="/api/health"){await Write(c,200,"application/json","{\"status\":\"ok\"}");continue;}
   if(p=="/api/files"){
    var baseDir=string.IsNullOrWhiteSpace(root.Text)?Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"CloudServer","Data"):root.Text;
    Directory.CreateDirectory(baseDir); var data=JsonSerializer.Serialize(Directory.EnumerateFileSystemEntries(baseDir).Select(x=>new {name=Path.GetFileName(x),directory=Directory.Exists(x)}));
    await Write(c,200,"application/json",data);continue;
   }
   await Write(c,404,"text/plain","Not found");
  }catch(Exception ex){await Write(c,500,"text/plain",ex.Message);}
  }
 }
 static async Task Write(HttpListenerContext c,int code,string type,string body){var b=System.Text.Encoding.UTF8.GetBytes(body);c.Response.StatusCode=code;c.Response.ContentType=type;c.Response.ContentLength64=b.Length;await c.Response.OutputStream.WriteAsync(b);c.Response.Close();}
}