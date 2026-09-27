using System.IO; using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
namespace CloudServer;
public sealed class StateStore {
 readonly string dir=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"i-NET-PROMO","Cloudservice");
 readonly object gate=new(); public AppState State {get;private set;}=new();
 public StateStore(){Directory.CreateDirectory(dir);Load();}
 static AppState ReadState(string path){var state=JsonSerializer.Deserialize<AppState>(File.ReadAllText(path));return state??throw new InvalidDataException("Serverstatus enthält keine gültigen Daten.");}
 void Load(){var p=Path.Combine(dir,"state.json");var backup=p+".bak";if(!File.Exists(p)){if(!File.Exists(backup))return;try{State=ReadState(backup);File.Copy(backup,p,true);return;}catch(Exception recovery){throw new InvalidDataException("Die Hauptkonfiguration fehlt und die Sicherung ist beschädigt.",recovery);}}try{State=ReadState(p);}catch(Exception primary){if(!File.Exists(backup))throw new InvalidDataException("Serverstatus ist beschädigt und es ist keine Sicherung vorhanden.",primary);try{State=ReadState(backup);File.Copy(backup,p,true);}catch(Exception recovery){throw new InvalidDataException("Serverstatus und Sicherung sind beschädigt.",new AggregateException(primary,recovery));}}}
 public void Save(){lock(gate){var path=Path.Combine(dir,"state.json");var temp=path+".tmp";var backup=path+".bak";var json=JsonSerializer.Serialize(State,new JsonSerializerOptions{WriteIndented=true});File.WriteAllText(temp,json);if(File.Exists(path))File.Replace(temp,path,backup,true);else File.Move(temp,path);}}
 public static string Hash(string password){var salt=RandomNumberGenerator.GetBytes(16);var key=Rfc2898DeriveBytes.Pbkdf2(password,salt,150000,HashAlgorithmName.SHA256,32);return Convert.ToBase64String(salt)+"."+Convert.ToBase64String(key);}
 public static bool Verify(string password,string stored){try{var p=stored.Split('.');var salt=Convert.FromBase64String(p[0]);var expected=Convert.FromBase64String(p[1]);var actual=Rfc2898DeriveBytes.Pbkdf2(password,salt,150000,HashAlgorithmName.SHA256,32);return CryptographicOperations.FixedTimeEquals(expected,actual);}catch{return false;}}
}
