# Advanced Mod Packer for SCS Games

*Currectly supported games: ETS2 and ATS, v1.37 and newer.*

This tool aims to automate the final steps before you publish your mod. It can pack both Steam Workshop and non-Steam Workshop variants. You can pack a single mod or you can specify a group of mods that will be packed in one go, but will still remain as separate mods. You can also pack a group of mods into a single package. When packing, it uses two passes to cut down the package size while allowing you to pack sounds, which cannot be compressed by default. It has been built on Smarty's compression script and made mode user-friendly.

![AMP4SCS' main menu](https://dl.dropboxusercontent.com/s/x2udhpfwmd44cnp/amp4scs.png?dl=0)

## Requirements:
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [7zip](https://www.7-zip.org/)

## Usage

This tool is template based and requires your mod files in folders, not archives. Also, all files have to be in game ready format. All templates are normal `.txt` files and belong in the `templates` folder (on the same level as .exe), valid example below:
<pre>
[pack_thingamajig]
group="DBus Vehicles"
name="Bolloré Bluebus"
zip_name="bollore_bluebus_40"
path1="S:\Docs\Euro Truck Simulator 2\mod\Bluebus"
path2="S:\Docs\Euro Truck Simulator 2\mod\Bluebus_def"
steam_path="S:\Docs\Euro Truck Simulator 2\mod_released\a_Steam\Bollore_Bluebus_s"
nosteam_path="S:\Docs\Euro Truck Simulator 2\mod_released\a_TMP\Bollore_Bluebus"

[include_in_manifest]
compatible_versions[]: "1.41.*"
  compatible_versions[]: "1.40.*"
  display_name: "Bolloré Bluebus SE"
[end]

include_at="#"

</pre>

`[pack_thingamajig]` tells the program this is a template<br>
`group=""` makes this mod part of a group<br>
`name=""` mod name for the AMP UI<br>
`zip_name=""` name of the final .zip, Steam Workshop versions will have `_s` appended at the end of the name automatically<br>
`pathX=""`first path to your mod, where X is a number counting from 1, if no valid number is found, loop ends and program progresses<br>
`steam_path=""` path where the final Steam Workhop package will be copied to, if invalid or empty package won't be created<br>
`nosteam_path=""` path where the final non-Steam Workhop package will be copied to, if invalid or empty package won't be created<br>
`[include_in_manifest]` block of text that will be included in the manifest.sii of the non-Steam Workshop version, it will appear as formmated here<br>
`[end]` ends the block of text for manifest inclusion<br>
`include_at="#"` this character will be replaced with the contents of `[include_in_manifest]`<br>
