using System;
using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using RevertRocketPunch.Patches;

namespace RevertRocketPunch;

[ModInitializer("ModLoaded")]
public static class ModEntry
{
    public const string ModId = "RevertRocketPunch";

    private static Harmony? _harmony;

    public static void ModLoaded()
    {
        try
        {
            Log.Info($"{ModId}: loading...");

            // 注意：ModLoaded 在 ExecuteVeryEarly 阶段被调用（ModManager.Initialize），
            // 而 ModelDb.Init() 在 ExecuteEssential 阶段才执行，因此此处绝不能访问 ModelDb，
            // 卡存在性检查放在运行时首次触发补丁时懒评估（见 RocketPunchGuard.IsSupported）。
            _harmony = new Harmony(ModId);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Info($"{ModId}: Harmony patches applied (Rocket Punch -> pre-v0.110 behavior)");
        }
        catch (Exception e)
        {
            Log.Error($"{ModId}: failed to apply patches: {e}");
        }
    }
}