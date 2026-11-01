using HarmonyLib;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace RevertRocketPunch.Patches;

/// <summary>
/// 描述切键：本地化文件新增 RE_ROCKET_PUNCH.description 键（模组专属前缀，
/// 避免与其他 mod 覆写官方 ROCKET_PUNCH.description 键冲突），由这里切换到新键。
/// 描述为 107 语义模板（「降为 0 / to 0」，与 111 官方模板逐字同构），
/// 数字由卡自身 DynamicVars 渲染（13/14 伤害、1/2 抽牌，与 111 相同）。
/// 仅对已提供本地化的 15 语言切键；其余语言（如 ind）保持官方键，避免 LocException。
/// </summary>
[HarmonyPatch(typeof(CardModel), "Description", MethodType.Getter)]
public static class RocketPunchDescriptionPatch
{
    private static void Postfix(CardModel __instance, ref LocString __result)
    {
        if (__instance is RocketPunch && ModConfig.IsReplaceEnabled && IsSupportedLanguage())
        {
            __result = new LocString("cards", "RE_ROCKET_PUNCH.description");
        }
    }

    private static bool IsSupportedLanguage()
    {
        string? lang = LocManager.Instance?.Language;
        return lang switch
        {
            "deu" or "eng" or "esp" or "fra" or "ita" or "jpn" or "kor" or "pol"
                or "ptb" or "rus" or "spa" or "tha" or "tur" or "zhs" or "zht" => true,
            _ => false,
        };
    }
}