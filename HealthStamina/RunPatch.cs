using HarmonyLib;
using UnityEngine;


namespace HealthStamina
{
    [HarmonyPatch(typeof(Player), "CheckRun")]
    public class RunPatch
    {
        static void Prefix(Vector3 moveDir, float dt, Character __instance)
        {
            /*
            if (__instance.GetType().IsSubclassOf(typeof(Player)) || __instance.GetType() == typeof(Player))
            {
                __instance.m_runSpeed = Storage.runSpeed;
            }
            */
            __instance.m_runSpeed = Storage.runSpeed.Value;
            __instance.m_swimSpeed = Storage.swimSpeed.Value;
            __instance.m_jumpForce = Storage.jumpForce.Value;
        }
    }
}