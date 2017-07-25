# Instant GameLauncher for SoapBox Servers

## Setup

- Copy *`InstantGameLauncher.exe`* to **NFS: World** Directory (where *`nfsw.exe`* is located).
- Launch *`InstantGameLauncher.exe`*.
- Wait for a MessageBox and click "Yes".
- Edit the file that was opened as of your preference.
- Save the file and relaunch *`InstantGameLauncher.exe`*.

`Hint:` You can get serverlist from https://soapboxrace.world/servers

### Sample configuration

The *`InstantGameLauncher.ini`* structure must be as of example:
```ini
[Configuration]
ServerAddress=http://play.soapboxrace.world/
Username=email@domain.tld
Password=Password
```

#### Multiple Server support

You can rename *`InstantGameLauncher.exe`* to anything you wish, like *`WorldEvolved.exe`* and have 2 of them, config file won't conflict

#### Using different executable with Server

You can add `UseExecutable` to the config file, as of example:
```ini
[Configuration]
...
UseExecutable=nfsw.exe
```
