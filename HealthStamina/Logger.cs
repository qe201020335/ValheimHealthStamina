using BepInExLogger = BepInEx.Logging.ManualLogSource;
using BepInEx;
using BepInEx.Configuration;

namespace HealthStamina
{
    public class Storage
    {
        internal static BepInExLogger Logger;
        internal static int StaminaModifier;
        internal static int HealthModifier;
    }
}