using UnityEngine;
using HarmonyLib;
using System.Reflection;
using GadgetCore.API;

namespace URP.Patches
{
    [HarmonyPatch(typeof(GameScript))]
    [HarmonyPatch("AddExpN")]
    [HarmonyGadget("URP")]
    public static class Patch_GameScript_AddExpN
    {
        private static int level;

        [HarmonyPrefix]
        public static void Prefix()
        {
            level = GameScript.playerLevel;
        }

        [HarmonyPostfix]
        public static void Postfix(GameScript __instance)
        {
            int levelDif = GameScript.playerLevel - level;
            if (levelDif > 1)
            {
                GameScript.playerLevel -= levelDif - 1;
                for (int i = 1; i < levelDif; i++)
                {
                    typeof(GameScript).GetMethod("LevelUp", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(__instance, new object[] { });
                    GameScript.playerLevel++;
                }
            }
        }
    }
}