using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace RevertRocketPunch.Patches;

/// <summary>
/// 将火箭飞拳（Rocket Punch）在 v0.110+ 的「生成状态牌 → 费用 -1」（AddUntilPlayed(-1)）
/// 回调为 v0.107.1 及之前的「生成状态牌 → 费用归零」（SetUntilPlayed(0)）。
/// 三次守卫（creator / card.Owner / card.Type == Status）与 107 原版一致；
/// 补丁体完全自包含，全部路径短路（命中即改，未命中即等价于 107 守卫分支）。
/// </summary>
[HarmonyPatch(typeof(RocketPunch), "AfterCardGeneratedForCombat")]
public static class RocketPunchGeneratedStatusPatch
{
    public static bool Prefix(RocketPunch __instance, CardModel card, Player? creator, ref Task __result)
    {
        if (!ModConfig.IsReplaceEnabled)
        {
            return true;
        }

        if (creator != __instance.Owner || card.Owner != __instance.Owner || card.Type != CardType.Status)
        {
            __result = Task.CompletedTask;
            return false;
        }

        __instance.EnergyCost.SetUntilPlayed(0);
        __result = Task.CompletedTask;
        return false;
    }
}