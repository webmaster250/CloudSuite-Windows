[Setup]
AppName=Cloud Server
AppVersion=1.0.0
DefaultDirName={autopf}\CloudServer
DefaultGroupName=Cloud Server
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
