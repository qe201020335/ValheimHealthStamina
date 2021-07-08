using System;
using HarmonyLib;

namespace HealthStamina.Patches
{
    [HarmonyPatch(typeof(Console), "InputText")]
    public class ConsolePatch
    {
        private static void Postfix(Console __instance)
        {
            string text = __instance.m_input.text.ToLower().Trim();

            string[] tokens = text.Split();

            if (tokens.Length > 0)
            {
                switch (tokens[0])
                {
                    case "stamina":
                        Stamina(__instance, tokens);
                        break;
                    
                    case "health":
                        Health(__instance, tokens);
                        break;
                    
                    case "heal":
                        Heal(__instance, tokens);
                        break;
                    
                    case "run":
                        Run(__instance, tokens);
                        break;
                    
                    case "jump":
                        Jump(__instance, tokens);
                        break;
                    
                    case "swim":
                        Swim(__instance, tokens);
                        break;
                        
                }
            }
        }

        private static void Run(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    float num = float.Parse(tokens[1]);
                    Storage.runSpeed.Value = num;
                    __instance.Print($"Run speed changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Run speed is {Storage.runSpeed.Value}");
            }
        }

        private static void Jump(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    float num = float.Parse(tokens[1]);
                    Storage.jumpForce.Value = num;
                    __instance.Print($"Jump force changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Jump force is {Storage.jumpForce.Value}");
            }
        }
        
        private static void Swim(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    float num = float.Parse(tokens[1]);
                    Storage.swimSpeed.Value = num;
                    __instance.Print($"Swim speed changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Swim speed is {Storage.swimSpeed.Value}");
            }
        }
        
        private static void Heal(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    int num = int.Parse(tokens[1]);
                    Storage.healModifier.Value = num;
                    __instance.Print($"Heal multiplier changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Heal multiplier is {Storage.healModifier.Value}");
            }
        }
        
        private static void Health(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    int num = int.Parse(tokens[1]);
                    Storage.HealthModifier.Value = num;
                    __instance.Print($"Health Modifier changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Health Modifier is {Storage.HealthModifier.Value}");
            }
        }
        
        private static void Stamina(Console __instance, string[] tokens)
        {
            if (tokens.Length == 2)
            {
                try
                {
                    int num = int.Parse(tokens[1]);
                    Storage.StaminaModifier.Value = num;
                    __instance.Print($"Stamina Modifier changed to {num}");
                }
                catch (Exception e)
                {
                    __instance.Print(e.ToString());
                }
            }
            else
            {
                __instance.Print($"Stamina Modifier is {Storage.StaminaModifier.Value}");
            }
        }
    }
}