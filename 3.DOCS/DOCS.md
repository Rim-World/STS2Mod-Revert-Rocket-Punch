# DOCS 索引

| 编号 | 日期 | 分类 | 文档 | 说明 |
|---|---|---|---|---|
| 001 | 2026-08-20 | E（证据） | [火箭飞拳版本差异与回调可行性](001-E-火箭飞拳版本差异与回调可行性.md) | 99.1→111 五版本差异证据、111 API 取证、描述文本、参考实现、构建打包要点 |
| 002 | 2026-08-20 | T（任务知识） | [模组运行时初始化时序](002-T-模组运行时初始化时序.md) | 启动三阶段时序实证；铁律：ModLoaded 禁止访问 ModelDb，运行期检查放补丁内懒评估 |
| 003 | 2026-11-19 | E（证据） | [0.111.1 与 0.113.1 兼容性核验](003-E-111.1与113.1兼容性核验.md) | 两版 API 差异、语言文本、双程序集编译、0.113.1 场景探针结果与边界 |
| 004 | 2026-11-01 | T（任务知识） | [仓库整理与临时文件清理](004-T-仓库整理与临时文件清理-2026-11-01.md) | 旧嵌套 git 目录与缓存目录的归档/清理记录；自旧 TMP.md 迁出 |

## 参考库

以下参考库位于本机 `C:\Users\<用户名>\Desktop\Mod\STS2-Reference\`，不在本仓库内：

- `0.STS1-Reference\`：杀戮尖塔 1 参考库（V2.3.4，Java/libGDX 引擎）：24 语言 × 17 表本地化 + CFR 反编译 Java 源码 + 423 卡索引 + 提取脚本。
- `1.STS2-107Reference\`：v0.107.1 卡牌参考库（14 语言全量本地化表 + 107 反编译效果源码 + 全卡索引 + 解包脚本，见 ADR-003；其中 `localization/ind`、`localization/zht` 为 111 残留已标注）。
- `2.STS2-111Reference\`：v0.111.1 卡牌参考库（16 语言全量本地化表 + 111 反编译效果源码 + 全卡索引 + 解包脚本 + `assemblies/sts2.dll`）。
- `3.STS2-113Reference\`：v0.113.0 参考库，已弃用，不参与兼容。
- `4.STS2-113.1Reference\`：v0.113.1 卡牌参考库（17 语言全量本地化表 + 反编译效果源码 + 全卡索引 + `assemblies/sts2.dll`）。

> 版本对照：107 的 `RocketPunch.AfterCardGeneratedForCombat` 为 `SetUntilPlayed(0)`，110+ 为 `AddUntilPlayed(-1)`；0.111.1 与 0.113.1 的 `RocketPunch.cs` 逐字节相同。
> 塔 1 与塔 2 引擎/开发方式完全不同（Java/libGDX vs Godot/C#），详见各参考库 README。
> 早期调研文档中的 `refs/...` 路径为整理前的临时取证目录，现已不存在，仅作证据出处说明保留。

## 目录结构

- `1.PRD/` — 需求与验收索引 `PRD.md`；用户 prompt 存 `用户prompt/`（不入库）
- `2.PLANS/` — 施工计划与索引 `PLANS.md`
- `3.DOCS/` — 调研、维护知识与报告（本目录）
- `4.ADR/` — 架构决策记录与索引 `ADR.md`
- `5.SDD/` — 软件设计文档与索引 `SDD.md`
- `6.SPEC/` — 对外规范与索引 `SPEC.md`
- `7.ChangeLog/` — 分版本变更日志与索引 `ChangeLog.md`
- `8.TEST/` — 测试工件、探针与门禁，索引 `TEST.md`
- `9.SRC/RevertRocketPunch/` — Godot/C# 工程
- `10.OUTPUT/` — 构建与发布包，索引 `OUTPUT.md`
- `TOOLS/scripts/` — 自写脚本（本地化与占位图生成）
- `description/` — 创意工坊/发布文案（中/英）
- `pics/` — 封面与附加截图
