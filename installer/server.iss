[Setup]
AppName=i-NET-PROMO Cloudservice Server
AppPublisher=i-NET-PROMO
VersionInfoCompany=i-NET-PROMO
VersionInfoDescription=i-NET-PROMO Cloudservice Server
AppVersion=1.0.0
DefaultDirName={autopf}\i-NET-PROMO\Cloudservice Server
DefaultGroupName=i-NET-PROMO Cloudservice
OutputDir=..\dist
OutputBaseFilename=CloudServer-Setup
Compression=lzma2
SolidCompression=yes
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
[Files]
Source: "..\publish\server\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion
[Icons]
Name: "{group}\Cloud Server"; Filename: "{app}\CloudServer.exe"
Name: "{autodesktop}\Cloud Server"; Filename: "{app}\CloudServer.exe"
[Run]
Filename: "{app}\CloudServer.exe"; Description: "Cloud Server starten"; Flags: nowait postinstall skipifsilent
