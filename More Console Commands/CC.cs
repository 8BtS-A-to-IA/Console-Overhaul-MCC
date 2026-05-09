using RoR2;
using BetterAutoComplete;
using MultiUserTargeting;
using UnityEngine;
using System.Collections.Generic;
using System;
using R2API.Utils;

namespace MiscellaneousConsoleCommands
{
    public class CC
    {

        [ConCommand(commandName = "CODBGValidBACACRI", flags = ConVarFlags.None, helpText = "Prints a list of all valid Auto-Complete Recognition Items.")]
        private static void CCCOValidBACAutoCompleteRecognitionItems(ConCommandArgs args) 
        {
            foreach (string RI in BAC.entryPoint.ACRI)
            {
                MonoBehaviour.print(RI);
            }
        }

        [ConCommand(commandName = "CODBGMUTTest", flags = ConVarFlags.None, helpText = "Purely for testing the MUT feature either for debugging MUT or testing if your query is " +
            "written correctly by printing the username of every user caught by the MUT query.")]
        private static void CCCOMUTTest(ConCommandArgs args)
        {
            MCC.CheckIfInStage();
            List<CharacterBody> characterBodies = MUT.entryPoint.GetPlayerBodiesByName(args.userArgs[0]);//Get multiple character bodies based on the search pattern
            foreach (CharacterBody character in characterBodies)
            {
                MonoBehaviour.print(character.GetUserName());
            }

        }

        [ConCommand(commandName = "CODBGCheats", flags = ConVarFlags.None, helpText = "Returns if cheats are active or not and lets you activate them with " +
            "a 'true' or 'false' as the first parameter. Note that once activated, even when deactivated, the sessions cheats can't be de-activated without" +
            " a game restart. This is hardcoded in and is intentional anyway.")]
        private static void CCCOCheats(ConCommandArgs args)
        {
            if (args.Count > 0 && args.userArgs[0].ToString().Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                MonoBehaviour.print("Activating cheats");
                RoR2.Console.CheatsConVar.instance.SetFieldValue("_boolValue", true);
                RoR2.Console.CheatsConVar.instance.AttemptSetString("1");
                return;
            }
            if (args.Count > 0 && args.userArgs[0].ToString().Equals("False", StringComparison.OrdinalIgnoreCase))
            {
                MonoBehaviour.print("Deactivating cheats");
                RoR2.Console.CheatsConVar.instance.SetFieldValue("_boolValue", false);
                RoR2.Console.CheatsConVar.instance.AttemptSetString("0");
                return;
            }
            MonoBehaviour.print("Cheats are active (session level)? " + RoR2.Console.sessionCheatsEnabled.ToString());
            MonoBehaviour.print("Cheats are active (command level)? " + RoR2.Console.CheatsConVar.instance.boolValue.ToString());
        }

        [ConCommand(commandName = "CODBGClearLocalChat", flags = ConVarFlags.None, helpText = "Clears the chat (locally only).")]
        public static void CCClearChat(ConCommandArgs args)
        {
            Chat.Clear();
            Chat.AddMessage("Chat cleared.");
        }

        [ConCommand(commandName = "CODBGPinging", flags = ConVarFlags.None, helpText = "Toggles the debug pinger (prints in CC what is currently being pinged [local only])")]
        public static void CCCODBGPinging(ConCommandArgs args)
        {
            dbgPinging = !dbgPinging;//print happenes within hooks
        }

        [ConCommand(commandName = "CODBGTogglePrintButtonPress", flags = ConVarFlags.None, helpText = "Toggles printing what key is currently being pressed.")]
        public static void CCCODBGTogglePrintButtonPress(ConCommandArgs args)
        {
            CC.printButtonPress = !CC.printButtonPress;
        }

        [ConCommand(commandName = "CODBGToggleBACDebugging", flags = ConVarFlags.None, helpText = "Toggles debugging for all CO-BAC Console Commands according to the verbos level. " +
            "Verbos 0 (or no paramater input) causes toggle, otherwise only changes verbos level. " +
            "Verbos level 0 = never show, 1 = is always show, 2 = errors only, 3 = quick debug, 4 = detailed debug 5 = overly detailed debug (WARNING: CAUSES LAG)")]
        public static void CCCOToggleBACDebugging(ConCommandArgs args)
        {
            ushort num = 0;
            if (args.userArgs.Count == 1)
            {
                if (!ushort.TryParse(args.userArgs[0], out num))
                {
                    MonoBehaviour.print("COToggleDebugging: Paramater 1 must be an unsigned short.");
                    return;
                }
            }
            if (BAC.debug && num != 0)
            {
                BAC.verbos = (uint)num;
                BAC.Print("verbos is now: " + BAC.verbos, 1);
            }
            if (num == 0)
            {
                BAC.debug = !BAC.debug;
                BAC.Print("debugging activated.", 0);
                if (!BAC.debug)
                {
                    MonoBehaviour.print("debugging deactivated.");
                }
            }
            if (!BAC.debug && num != 0)
            {
                MonoBehaviour.print("Verbos can not be set while debugging is disabled.");
            }
        }

        [ConCommand(commandName = "CODBGToggleMUTDebugging", flags = ConVarFlags.None, helpText = "Toggles debugging for all CO-MUT Console Commands according to the verbos level. " +
            "Verbos 0 (or no paramater input) causes toggle, otherwise only changes verbos level. " +
            "Verbos level 0 = never show, 1 = is always show, 2 = errors only, 3 = quick debug, 4 = detailed debug 5 = overly detailed debug (WARNING: CAUSES LAG)")]
        public static void CCCOToggleMUTDebugging(ConCommandArgs args)
        {
            ushort num = 0;
            if (args.userArgs.Count == 1)
            {
                if (!ushort.TryParse(args.userArgs[0], out num))
                {
                    MonoBehaviour.print("COToggleDebugging: Paramater 1 must be an unsigned short.");
                    return;
                }
            }
            if (MUT.debug && num != 0)
            {
                MUT.verbos = (uint)num;
                MUT.print("verbos is now: " + MUT.verbos, 1);
            }
            if (num == 0)
            {
                MUT.debug = !MUT.debug;
                MUT.print("debugging activated.", 0);
                if (!MUT.debug)
                {
                    MonoBehaviour.print("debugging deactivated.");
                }
            }
            if (!MUT.debug && num != 0)
            {
                MonoBehaviour.print("Verbos can not be set while debugging is disabled.");
            }
        }

        internal static bool dbgPinging = false;
        internal static bool printButtonPress = false;

    }
}
