using BepInExLogger = BepInEx.Logging.ManualLogSource;
using BepInEx;
using BepInEx.Configuration;

namespace HealthStamina
{
    public class Storage
    {
        internal static BepInExLogger Logger;
        internal static ConfigEntry<int> StaminaModifier;
        internal static ConfigEntry<int> HealthModifier;
        internal static ConfigEntry<int> healModifier;
        internal static ConfigEntry<float> runSpeed;
        internal static ConfigEntry<float> jumpForce;
        internal static ConfigEntry<float> swimSpeed;
    }
}