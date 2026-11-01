# STS2Mod-回调飞拳（RevertRocketPunch）

把《杀戮尖塔 2》故障机器人的「火箭飞拳」回调为 v0.110 之前的版本：每当你生成状态牌时，此牌的耗能将在下一次打出前降为 0，而不是减少 1。

An STS2 mod that reverts Defect's "Rocket Punch" to its pre-v0.110 behavior: whenever you create a Status, this card's cost becomes 0 until played, instead of being reduced by 1.

## 功能

- **效果回调**：`RocketPunch.AfterCardGeneratedForCombat` 被补丁接管，命中「牌主生成状态牌」后执行 `EnergyCost.SetUntilPlayed(0)`，与 v0.107.1 原版语义一致。
- **文本回调**：卡面描述切换到模组专属键 `RE_ROCKET_PUNCH.description`，提供 15 种语言；`ind` 不替换，保持官方 111 文案。
- **不新增卡牌**：直接修改原卡的行为与描述，卡名、卡图、数值（2 费攻击、13(+1) 伤害、抽 1(+1) 张）不变。
- **自动降级**：游戏版本低于 0.110 或卡牌缺失时不介入，不报错、不崩溃。

## 兼容性

| 项 | 说明 |
|---|---|
| 游戏版本 | `min_game_version = 0.107.0`；补丁仅在 `SemVer.Major == 0 && Minor >= 110` 时启用 |
| 依赖 | 无。`0Harmony` 与 `sts2.dll` 仅作编译期引用（`Private=false`） |
| 其他 mod | 不与覆写官方 `ROCKET_PUNCH.description` 键的 mod 抢键；不保证与盗版/修改版/移动版/老旧版本的兼容性 |

## 安装

1. 安装并启用游戏 mod 加载器（游戏自带的 mods 目录机制）。
2. 把 `RevertRocketPunch/` 目录（含 `RevertRocketPunch.dll`、`RevertRocketPunch.pck`、`RevertRocketPunch.json`）放入 `<游戏目录>/mods/`。
3. 启动游戏，在 mods 菜单中启用本 mod。

发布包见 [Releases](https://github.com/Rim-World/STS2Mod-Revert-Rocket-Punch/releases)。

## 构建

前置：.NET 9 SDK、Godot 4.5.1 mono、本机已安装《杀戮尖塔 2》（提供 `sts2.dll` 与 `0Harmony.dll` 引用）。

```powershell
cd 9.SRC/RevertRocketPunch
./build.ps1
```

脚本依次执行 `dotnet build -c Debug` → Godot `--headless --import` → `--export-pack "Windows Desktop"` → 拷贝 dll/pdb/json 到 `C:/Game/Steam/steamapps/common/Slay the Spire 2/mods/RevertRocketPunch/`。路径均在 `build.ps1` 顶部与 `RevertRocketPunch.csproj` 的 `Sts2Path` 中配置。

## 目录结构

```
STS2Mod-回调飞拳/
├── 1.ADR/          架构决策记录与索引 ADR.md
├── 2.PLANS/        施工计划与索引 PLANS.md
├── 3.DOCS/         调研与知识文档，索引 DOCS.md
├── 4.SDD/          软件设计文档，索引 SDD.md
├── 5.ChangeLog/    分版本变更日志，索引 ChangeLog.md
├── 9.SRC/          源码（Godot/C# 工程 RevertRocketPunch）
├── 10.OUTPUT/      构建产物与发布包（output.md 索引，其余不入库）
├── PRIVACY/        机密信息（PRIVACY.md 索引，不入库）
├── TMP/            临时与过程文件（TMP.md 索引，其余不入库）
├── TOOLS/          自写脚本，TOOLS.md 索引
├── description/    创意工坊/发布文案（中/英）
└── pics/           封面与附加截图
```

## 文档索引

- [ADR 索引](1.ADR/ADR.md) — 三篇决策记录：补丁策略、ModelDb 访问时机、107 参考库与文本对齐
- [计划索引](2.PLANS/PLANS.md) — 火箭飞拳回调施工计划与施工记录
- [知识索引](3.DOCS/DOCS.md) — 版本差异证据、运行时初始化时序
- [设计文档](4.SDD/001-总体设计.md) — 模块划分、补丁策略、数据流、异常处理、构建与测试
- [版本日志](5.ChangeLog/ChangeLog.md)（单文件版见 [CHANGELOG.md](CHANGELOG.md)）
- [工具索引](TOOLS/TOOLS.md) — 本地化与占位图生成脚本

## 版本

当前版本 **1.0**，详细变更见 [CHANGELOG.md](CHANGELOG.md)。

## 致谢

- 感谢《杀戮尖塔 2》制作组对 mod 生态的支持，以及 Baselib 作者提供的文档。
- 本 mod 使用 Opencode + DeepSeek V4 Flash（0731 GA）完成。

## 开源地址

<https://github.com/Rim-World/STS2Mod-Revert-Rocket-Punch>
