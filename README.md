# WOTModProfileManager
Manage your World of Tanks Mods with Profiles. This allows different Mods for different users.

##How does it work?

Every World of Tanks version has its own MOD folder. 
For Example World of Tanks version 0.9.4 is looking in *"C:\Games\World_of_Tanks\res_mods\0.9.4"* (depending on your installation path) if there are any MODs installaed. 
So the WoT Mod Profile Manager creates a folder for each profile. 
They have always "wotmpm_" as name prefix, followed by the WoT version and your profile name. 
My Profile folder would be named "wotmpm_0.9.4_eferdi".

When you now start the game with the Mod Profile Manager, he will only link the profile folder to the original MOD folder and start the game.

Example:

*"C:\Games\World_of_Tanks\res_mods\wotmpm_0.9.4_eferdi"* gets linked to *"C:\Games\World_of_Tanks\res_mods\0.9.4"*

**No file copy actions are done**, which makes profile switching damn fast.

##What happens with already installed MODs?
Dont worry, if you run the Mod Profile Manager the first time he will detect this and offers you to copy the MOD folder.

##What are the System Requirements?
* Windows 7 or newer (don't try to use it with older versions then windows 7!)
* World of Tanks

