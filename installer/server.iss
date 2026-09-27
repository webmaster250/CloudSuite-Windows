[Setup]
AppName=i-NET-PROMO Cloudservice Server
AppPublisher=i-NET-PROMO / Sascha Scheuermann
AppPublisherURL=https://www.i-net-promo.de
AppSupportURL=https://www.i-net-promo.de
AppUpdatesURL=https://www.i-net-promo.de
VersionInfoCompany=i-NET-PROMO
VersionInfoDescription=i-NET-PROMO Cloudservice Server
AppVersion=1.0.0
DefaultDirName={autopf}\i-NET-PROMO\Cloudservice Server
DefaultGroupName=i-NET-PROMO Cloudservice
OutputDir=..\dist
OutputBaseFilename=CloudServer-Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
CloseApplications=yes
RestartApplications=no
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
[Files]
Source: "..\publish\server\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion
[Icons]
Name: "{group}\i-NET-PROMO Cloudservice Server"; Filename: "{app}\CloudServer.exe"
Name: "{autodesktop}\i-NET-PROMO Cloudservice Server"; Filename: "{app}\CloudServer.exe"
[Run]
Filename: "{app}\CloudServer.exe"; Description: "i-NET-PROMO Cloudservice Server starten"; Flags: nowait postinstall skipifsilent
