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
        void Awake()
        {
            testGreeting = Config.Bind("Test", "Greeting", false, "Nah");

            Storage.StaminaModifier = Config.Bind("Modifier", "Stamina", 10, "Stamina Modifier");
            Storage.HealthModifier = Config.Bind("Modifier", "Health", 5, "Health Modifier");
            Storage.healModifier = Config.Bind("Modifier", "Heal", 5, "Heal Modifier");
            Storage.runSpeed = Config.Bind("Modifier", "runSpeed", 20f, "Run speed");
            Storage.jumpForce = Config.Bind("Modifier", "jumpForce", 5f, "Jump Force");
            Storage.swimSpeed = Config.Bind("Modifier", "swimSpeed", 5f, "Swim Speed");
            
            Storage.Logger = Logger;
            if (testGreeting.Value)
            {
                Logger.LogInfo("Hello, world!");
            }

            Logger.LogInfo("Start Patching");
            var harmony = new Harmony("org.skyqe.plugins.HealthStamina");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
            Logger.LogInfo("Patch Done");
            
        }
    }
}
