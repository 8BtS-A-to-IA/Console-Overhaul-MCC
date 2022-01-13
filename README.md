![console overhaul](https://github.com/8BitShadow/media-resources/blob/main/console%20overhaul.png?raw=true)
# Miscellaneous Console Commands
## About
"Miscellaneous Console Commands" is an expansion mod for the console overhaul modpack which provides some debugging commands both specifically for M.U.T, B.A.C. and TSBind, and general modding. All commands added by Console Overhaul allays begin with the prefix 'CO', making searching through Console Overhals' commands easy.

## Usage
To use one of the commands; write them in the console command in-game (some require being in a single/muilti-player match to function correctly):
- CODBGValidBACACRI: Prints a list of all valid Auto-Complete Recognition Items.
- CODBGMUTTest (string): Tests the MUT feature, either for debugging MUT or testing if your query is written correctly. If successful; prints the username of each returned player.
- CODBGCheats {boolean}: Returns if cheats are active or not when run with no parameters, otherwise activates/deactivates cheats. Note that once activated, even when later deactivated, the sessions cheats can't be de-activated without a game restart. This is hardcoded in and is intentional anyway.
- CODBGClearLocalChat: Clears the chat (locally).
- CODBGPinging: Toggles the debug pinger (prints in CC what is currently being pinged (locally))
- CODBGTogglePrintButtonPress: Toggles printing what key is currently being pressed.
- CODBGToggleBACDebugging {unsigned-short}: Toggles debugging for all B.A.C. Console Commands according to the verbos level.
  - Verbose level 0 (or no parameter input) = causes toggle & never show.
  - Verbose level 1 = always show
  - Verbose level 2 = errors only
  - Verbose level 3 = quick debug
  - Verbose level 4 = detailed debug
  - Verbose level 5 = overly detailed debug (WARNING: CAUSES LAG)
- CODBGToggleMUTDebugging {unsigned-short}: Toggles debugging for all M.U.T. Console Commands according to the verbos level.
  - Verbose level 0 (or no parameter input) = causes toggle & never show.
  - Verbose level 1 = always show
  - Verbose level 2 = errors only
  - Verbose level 3 = quick debug
  - Verbose level 4 = detailed debug
  - Verbose level 5 = overly detailed debug (WARNING: CAUSES LAG)
  
{} = optional parameter, () = required parameter

## due to an issue with uploading files directly into the repo via the github website, the files have been temporarily placed into a .zip file.

## development
### How can I develop for this project?
After cloning the repository and ensuring you have any version of [VS 2017/2019](https://visualstudio.microsoft.com/) installed, you should be able to simply open the `.snl` file to open the project in VS.
<br><br>
Before posting a merge request, please ensure you've:
- Adequately checked for 'top level' bugs
- Provided enough commenting/sudo-code for other contributers to quickly understand the process (if necessary)

For the sake of documenting bugfixes, when posting a merge request, please ensure you detail any changes by:
- Describing what was changed (in the head)
- How the changes where made (in the 'extended description')
  - If the merge request only adds new code and does not edit any pre-existing code, feel free to only fill the head.

### How do I compile and run this?
There are no special steps to building and compiling the code, simply press 'run' in <abbr title="Visual Studio">VS</abbr>.<br>
If you do not have the [export helper (todo)]() installed; simply press 'Ok' if an error appears saying "A project with an Output Type of Class Library cannot be started directly". Visual Studio will have the `.dll` file you need generated in `bin>Debug` for VS 2017 or `bin>Debug>netstandard2.0` for VS 2019, simply copy the `.dll` file into the BepInEx `plugins` folder and start RoR2.<br>
If you have the exporter helper tool setup correctly; after pressing 'run' in VS, simply start <abbr title="Risk of Rain 2">RoR2</abbr>.

### How can I help without any programming 'know-how'?
Simply install the mod/modpack from [the modpacks main page](https://github.com/8BtS-A-to-IA/Console-Overhaul) and play. If you encounter any issues make sure to log it and provide as much relevant detail as possible in the relevant mods' `issue` page--or the main page if you don't know which mod is the problem--after checking if the same issue has not already been encountered, you can use the formatting guide to help with this.<br>
Don't worry about if you predict the wrong mod as the cause, it's more important to just have the report out there.

## Change log:
<details>
    <summary>V1.0.0 (unreleased):</summary>
  
  - none yet!
</details>
