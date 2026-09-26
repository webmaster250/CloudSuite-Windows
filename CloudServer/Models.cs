namespace CloudServer;
public sealed class UserAccount { public string Id {get;set;}=Guid.NewGuid().ToString("N"); public string UserName {get;set;}=""; public string DisplayName {get;set;}=""; public string PasswordHash {get;set;}=""; public bool IsAdmin {get;set;} public long QuotaBytes {get;set;}=10737418240; public List<string> GroupIds {get;set;}=new(); }
public sealed class CloudGroup { public string Id {get;set;}=Guid.NewGuid().ToString("N"); public string Name {get;set;}=""; }
public sealed class StorageAssignment { public string Id {get;set;}=Guid.NewGuid().ToString("N"); public string Name {get;set;}=""; public string Path {get;set;}=""; public string Role {get;set;}="Personal"; public string? UserId {get;set;} public string? GroupId {get;set;} public long QuotaBytes {get;set;} }
public sealed class AppState { public List<UserAccount> Users {get;set;}=new(); public List<CloudGroup> Groups {get;set;}=new(); public List<StorageAssignment> Storage {get;set;}=new(); }
