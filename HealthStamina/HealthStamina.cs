using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;

namespace HealthStamina
{
    [BepInPlugin("org.skyqe.plugins.HealthStamina", "Valheim Health and Stamina Booster", "1.0.0.0")]
    public class HealthStamina : BaseUnityPlugin
    {
        private ConfigEntry<bool> testGreeting;
        private ConfigEntry<int> staminaModifier;
        private ConfigEntry<int> healthModifier;
        private ConfigEntry<int> healModifier;
        
        void Awake()
        {
            testGreeting = Config.Bind("Test", "Greeting", false, "Nah");

            staminaModifier = Config.Bind("Modifier", "Stamina", 10, "Stamina Modifier");
            healthModifier = Config.Bind("Modifier", "Health", 5, "Health Modifier");
            healModifier = Config.Bind("Modifier", "Heal", 5, "Heal Modifier");

            Storage.Logger = Logger;

            if (testGreeting.Value)
            {
                Logger.LogInfo("Hello, world!");
            }

            Storage.HealthModifier = healthModifier.Value;
            Storage.StaminaModifier = staminaModifier.Value;
            Storage.healModifier = healModifier.Value;
            
            Logger.LogInfo("Start Patching");
            var harmony = new Harmony("org.skyqe.plugins.HealthStamina");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
            Logger.LogInfo("Patch Done");
            
        }
    }
}
