using RoR2;
using RoR2.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace MiscellaneousConsoleCommands
{
    class Hooks
    {

        internal static void InitializeHooks() 
        {
            On.RoR2.PingerController.SetCurrentPing += PingController_SetCurrentPing;
            On.RoR2.Console.Update += Console_Update;
        }

        internal static void DisableHooks() 
        {
            On.RoR2.PingerController.SetCurrentPing -= PingController_SetCurrentPing;
            On.RoR2.Console.Update -= Console_Update;
        }

        /// <summary>
        /// Prints in the console what is currently being pinged [local only] if debug pinging is active.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="s"></param>
        /// <param name="pingInfo"></param>
        internal static void PingController_SetCurrentPing(On.RoR2.PingerController.orig_SetCurrentPing o, PingerController s, PingerController.PingInfo pingInfo)
        {
            o.Invoke(s, pingInfo);
            if (CC.dbgPinging)
            {
                MonoBehaviour.print(pingInfo.targetGameObject.name);
            }
        }

        /// <summary>
        /// When printButtonPress is true; this will print what key is currently being pressed. For debugging CO-Bind.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="s"></param>
        public static void Console_Update(On.RoR2.Console.orig_Update o, RoR2.Console s) 
        {
            o.Invoke(s);
            Event current = Event.current;

            if (CC.printButtonPress && current.isKey && ConsoleWindow.instance)
            {//if a button has been pressed, we're displaying the debug info and console is instantiated
                Trace.TraceInformation("Detected key code: " + current.keyCode);
            }
        }

    }
}
