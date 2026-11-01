using MegaCrit.Sts2.Core.Debug;
using MegaCrit.Sts2.Core.Logging;
using RevertRocketPunch.Patches;

namespace RevertRocketPunch;

/// <summary>
/// 替换功能总开关：
/// 1) ModelDb 中确有「火箭飞拳」（RocketPunch）；
/// 2) 当前游戏版本 >= v0.110 —— 107/108/109 本就是目标效果（生成状态牌 → 费用归零），不干预；
///    110+ 一律修正为 107 效果（面向未来版本）。
/// min_game_version=0.107.0 由加载器原生保证（低于 0.107.0 不加载）。
/// </summary>
public static class ModConfig
{
    public static bool IsReplaceEnabled => RocketPunchGuard.IsSupported() && IsActiveVersion();

    private static bool? _versionOk;

    /// <summary>
    /// 版本判断（懒求值 + 缓存）：SemVer 未就绪时暂按"生效"放行，下次访问再评估；
    /// 一旦拿到确定的 SemVer 即缓存结论。生效口径：Major=0 且 Minor>=110（含 0.110.x 全部补丁号）。
    /// </summary>
    public static bool IsActiveVersion()
    {
        if (_versionOk.HasValue)
        {
            return _versionOk.Value;
        }

        try
        {
            SemanticVersion? semVer = ReleaseInfoManager.Instance.SemVer;
            if (semVer != null)
            {
                _versionOk = semVer.Major == 0 && semVer.Minor >= 110;
                if (_versionOk.Value)
                {
                    Log.Info($"{ModEntry.ModId}: current version {semVer} is supported; patches enabled.");
                }
                else
                {
                    Log.Info($"{ModEntry.ModId}: current version {semVer} already has the target card effect; patches disabled.");
                }
            }
        }
        catch (Exception e)
        {
            Log.Warn($"{ModEntry.ModId}: failed to read release version ({e.Message}); treating as supported, will retry.");
        }

        return _versionOk ?? true;
    }
}