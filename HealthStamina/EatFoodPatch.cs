﻿using HarmonyLib;
using UnityEngine;

namespace HealthStamina
{
    [HarmonyPatch(typeof(Player), "EatFood")]
    public class EatFoodPatch
    {
        
        
        static void Prefix(ItemDrop.ItemData item)
        {
            Storage.Logger.LogDebug($"Eat {item.m_shared.m_name}");
            Storage.Logger.LogDebug($"{item.m_shared.m_food}, {item.m_shared.m_foodStamina}");
            item.m_shared.m_food *= Storage.HealthModifier;
            item.m_shared.m_foodStamina *= Storage.StaminaModifier;
        }

        static void Postfix(ItemDrop.ItemData item)
        {
            Storage.Logger.LogDebug($"Eaten {item.m_shared.m_name}");
            Storage.Logger.LogDebug($"{item.m_shared.m_food}, {item.m_shared.m_foodStamina}");
            item.m_shared.m_food /= Storage.HealthModifier;
            item.m_shared.m_foodStamina /= Storage.StaminaModifier;
        }
    }
}