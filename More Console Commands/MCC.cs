using BepInEx;
using R2API.Utils;
using RoR2;

namespace MiscellaneousConsoleCommands
{

    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.ML.MCC", "Console Overhaul: Miscellaneous Console Commands", "1.0")]
    [R2APISubmoduleDependency(nameof(CommandHelper))]
    [BepInDependency(MUTDep)]
    [BepInDependency(BACDep)]

    public class MCC : BaseUnityPlugin
    {
        private const string MUTDep = "com.ML.MUT";
        private const string BACDep = "com.ML.BAC";

        public void Awake()
        {
            CommandHelper.AddToConsoleWhenReady();
            Hooks.InitializeHooks();
        }

        public void OnDisable() 
        {
            Hooks.DisableHooks();//drop hooks
        }

        /// <summary>
        /// Checks if the local player is currently playing the game.
        /// </summary>
        public static void CheckIfInStage()
        {
            if (!Stage.instance)
            {
                throw new ConCommandException("This command cannot be used while not in a mission.");
            }
        }

    }
}
