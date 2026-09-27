[Setup]
AppName=i-NET-PROMO Cloudservice Client
AppPublisher=i-NET-PROMO
AppPublisherURL=https://www.i-net-promo.de
AppSupportURL=https://www.i-net-promo.de
AppUpdatesURL=https://www.i-net-promo.de
VersionInfoCompany=i-NET-PROMO
VersionInfoDescription=i-NET-PROMO Cloudservice Client
AppVersion=1.0.0
DefaultDirName={autopf}\i-NET-PROMO\Cloudservice Client
DefaultGroupName=i-NET-PROMO Cloudservice
OutputDir=..\dist
OutputBaseFilename=i-NET-PROMO-Cloudservice-Client-Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayName=i-NET-PROMO Cloudservice Client
SetupLogging=yes
PrivilegesRequired=admin
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
[Files]
Source: "..\publish\client\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion
[Icons]
Name: "{group}\i-NET-PROMO Cloudservice Client"; Filename: "{app}\CloudClient.exe"
Name: "{autodesktop}\i-NET-PROMO Cloudservice Client"; Filename: "{app}\CloudClient.exe"
[Run]
Filename: "{app}\CloudClient.exe"; Description: "i-NET-PROMO Cloudservice Client starten"; Flags: nowait postinstall skipifsilent
