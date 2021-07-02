using HarmonyLib;
using UnityEngine;

namespace HealthStamina
{
    [HarmonyPatch(typeof(Character), "Heal")]
    public class HealPatch
    {
        static void Prefix(ref float hp, bool showText, Character __instance)
        {
            
#if DEBUG
            Storage.Logger.LogDebug(__instance.GetType().ToString());
#endif
            
            if (__instance.GetType().IsSubclassOf(typeof(Player)) || __instance.GetType() == typeof(Player))
            {
                Storage.Logger.LogDebug($"Heal {hp}");
                hp *= Storage.healModifier;
                Storage.Logger.LogDebug($"Healed {hp}");
            }
        }
    }
}