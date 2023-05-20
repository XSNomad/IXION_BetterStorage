using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using BulwarkStudios.Stanford.Torus.Buildings;

namespace IXION_BetterStorage;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

        foreach (var patchedMethod in harmony.GetPatchedMethods())
        {
            Log.LogInfo($"Patched: {patchedMethod.DeclaringType?.FullName}:{patchedMethod}");
        }
    }
}
public class MoreStorage
{
    [HarmonyPatch(typeof(BuildingActionTotalCapacity), nameof(BuildingActionTotalCapacity.GetTotalCapacityStockpile))]
    public class BuildingActionTotalCapacity_GetTotalCapacityStockpile_Patch
    {
        public static void Postfix(ref int __result)
        {
            if (__result == 100) __result *= 2;
        }
    }
}