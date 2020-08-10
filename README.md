# HadesSaveManager
Unofficial Save Manager for the video game Hades

# Description

The HadesSaveManager tool is used to import and export saves for Hades. You can
use it to create snapshots of your run at various stages, and reload those
snapshots at any time.

One immediate benefit of this is that it allows you to practice a boss fight
that you have trouble with. Another benefit is the ability to create a routed
run, which follows an exact pre-determined path through the game. An example
of this is the world record for the Nighty Night patch, which can be found
[here.](https://www.speedrun.com/hades/run/zx24768m)

# Installation

The HadesSaveManager is a portable executable, which means it does not require
direct installation on your PC. However, it does require the .NET Framework.
When you first try to run the SaveManager, your PC wil prompt you to install
.NET, if necessary.

# Usage

![HSM UI Example](/img/ui.png)

The Save Manger is a single window, with inputs for:
 - Profile: The profile number that you are using for your save in Hades

 - Save Folder: The location of your save folder on your PC. By default,
this is `C:\Users\<username>\My Documents\Saved Games\Hades`

 - Route Folder: The location you want to save your snapshots

Once you fill in the above information, you can type a snapshot name, and click
Create. This will create a file with the .hsm extension in the folder you
provided.

To load a snapshot, use the dropdown to select the snapshot and then click
Load.

Only one 'run' can be managed per folder. To manage multiple runs, you will
need to select multiple folders. The manager will warn you if you are going
to overwrite a seed.

It is strongly recommended that you never overwrite a seed, as this will
invalidate any snapshots you have created for that run. Instead, you should
create a new folder for the new run.

# License

Distributed under the MIT License. See LICENSE for more information.

# Contact

Museus [Twitch](https://twitch.tv/Museus7) [Email](museus@protonmail.com)