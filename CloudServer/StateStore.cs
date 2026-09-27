using System.IO; using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
namespace CloudServer;
public sealed class StateStore {
 readonly string dir=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"i-NET-PROMO","Cloudservice");
 readonly object gate=new(); public AppState State {get;private set;}=new();
 public StateStore(){Directory.CreateDirectory(dir);Load();if(State.Users.Count==0){State.Users.Add(new UserAccount{UserName="admin",DisplayName="Administrator",IsAdmin=true,PasswordHash=Hash("admin")});Save();}}
 void Load(){var p=Path.Combine(dir,"state.json");if(File.Exists(p)) State=JsonSerializer.Deserialize<AppState>(File.ReadAllText(p))??new();}
 public void Save(){lock(gate)File.WriteAllText(Path.Combine(dir,"state.json"),JsonSerializer.Serialize(State,new JsonSerializerOptions{WriteIndented=true}));}
 public static string Hash(string password){var salt=RandomNumberGenerator.GetBytes(16);var key=Rfc2898DeriveBytes.Pbkdf2(password,salt,150000,HashAlgorithmName.SHA256,32);return Convert.ToBase64String(salt)+"."+Convert.ToBase64String(key);}
 public static bool Verify(string password,string stored){try{var p=stored.Split('.');var salt=Convert.FromBase64String(p[0]);var expected=Convert.FromBase64String(p[1]);var actual=Rfc2898DeriveBytes.Pbkdf2(password,salt,150000,HashAlgorithmName.SHA256,32);return CryptographicOperations.FixedTimeEquals(expected,actual);}catch{return false;}}
}
