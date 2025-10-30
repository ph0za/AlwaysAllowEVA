using HarmonyLib;
using UnityEngine;

namespace AlwaysAllowEVA
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class AlwaysAllowEVA : MonoBehaviour
    {
        void Start()
        {
            var harmony = new Harmony("com.phoza.alwayseva");
            harmony.PatchAll();
            Debug.Log("[AlwaysAllowEVA] Patch applied");
        }
    }

    [HarmonyPatch(typeof(FlightEVA))]
    [HarmonyPatch("HatchIsObstructed")]
    public static class Patch_HatchIsObstructed
    {
        static bool Prefix(ref bool __result)
        {
            __result = false; // “not obstructed”
            return false;     // skip original
        }
    }

    [HarmonyPatch(typeof(FlightEVA))]
    [HarmonyPatch("hatchInsideFairing")]
    public static class Patch_HatchInsideFairing
    {
        static bool Prefix(ref bool __result)
        {
            __result = false; // “not inside fairing”
            return false;     // skip original
        }
    }

    [HarmonyPatch(typeof(FlightEVA))]
    [HarmonyPatch("HatchIsObstructedMore")]
    public static class Patch_HatchIsObstructedMore
    {
        static bool Prefix(ref bool __result)
        {
            __result = false; // “not obstructedMore”
            return false;     // skip original
        }
    }
}