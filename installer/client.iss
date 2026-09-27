[Setup]
AppName=i-NET-PROMO Cloudservice Client
AppPublisher=i-NET-PROMO
VersionInfoCompany=i-NET-PROMO
VersionInfoDescription=i-NET-PROMO Cloudservice Client
AppVersion=1.0.0
DefaultDirName={autopf}\i-NET-PROMO\Cloudservice Client
DefaultGroupName=i-NET-PROMO Cloudservice
OutputDir=..\dist
OutputBaseFilename=CloudClient-Setup
Compression=lzma2
SolidCompression=yes
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
[Files]
Source: "..\publish\client\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion
[Icons]
Name: "{group}\Cloud Client"; Filename: "{app}\CloudClient.exe"
Name: "{autodesktop}\Cloud Client"; Filename: "{app}\CloudClient.exe"
[Run]
Filename: "{app}\CloudClient.exe"; Description: "Cloud Client starten"; Flags: nowait postinstall skipifsilent
