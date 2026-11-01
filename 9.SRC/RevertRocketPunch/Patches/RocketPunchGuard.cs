using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace RevertRocketPunch.Patches;

/// <summary>
/// 卡存在性检查：确认 ModelDb 中确实存在「火箭飞拳」（RocketPunch）才会启用补丁。
/// 由 ModConfig.IsReplaceEnabled 在运行时首次触发补丁时调用，懒求值 + 缓存。
/// 注意：ModLoaded 阶段（ExecuteVeryEarly）ModelDb 尚未 Init()，绝不能在此时访问 ModelDb。
/// 未来版本删除该卡 → 补丁禁用 + Log.Warn，游戏保持原版行为。
/// </summary>
public static class RocketPunchGuard
{
    private static bool? _modelOk;

    private static bool _warned;

    public static bool IsSupported()
    {
        if (_modelOk.HasValue)
        {
            return _modelOk.Value;
        }

        try
        {
            _ = ModelDb.Card<RocketPunch>();
            _modelOk = true;
            Log.Info($"{ModEntry.ModId}: RocketPunch found in ModelDb; patches enabled.");
        }
        catch
        {
            // ModelDb 尚未就绪（理论上运行时不发生）时暂不拦截，下次访问再评估；
            // 若已就绪但确实没有该卡（未来版本删除），同样暂放行并仅告警一次。
            MarkUnsupported("RocketPunch was not found in ModelDb");
            return true;
        }

        return _modelOk.Value;
    }

    private static void MarkUnsupported(string reason)
    {
        if (!_warned)
        {
            _warned = true;
            Log.Warn($"{ModEntry.ModId}: {reason}; patches will not modify behavior.");
        }
    }
}