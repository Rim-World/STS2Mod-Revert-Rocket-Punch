# ADR 索引

| 编号 | 日期 | 决策 | 说明 | 链接 |
|---|---|---|---|---|
| 001 | 2026-08-20 | 火箭飞拳回调：单点效果补丁 + RE_ 文本切键 + 卡存在性检查 + 版本门（>=110 生效） | 单点 Prefix 短路 `RocketPunch.AfterCardGeneratedForCombat`；描述切到 `RE_ROCKET_PUNCH.description` 专属键；不做静态形状守卫；`SemVer.Minor >= 110` 才生效 | [001-火箭飞拳回调](001-火箭飞拳回调.md) |
| 002 | 2026-08-20 | 补丁未生效根因：ModLoaded 阶段禁止访问 ModelDb | ModLoaded 早于 `ModelDb.Init()`，原实现在 ModLoaded 检查卡存在性 → 误判 → 跳过 `PatchAll`；修复为无条件 PatchAll + 运行时懒评估 | [002-ModelDb访问时机修复](002-ModelDb访问时机修复.md) |
| 003 | 2026-08-20 | 建立 107 卡牌参考库 + mod 文本对齐官方 107 | 解包 107 pck 本地化 + ilspycmd 反编译效果源码；mod 15 语言逐语言比对（fra/spa 修正 NBSP；zht 保留 111 句式） | [003-107卡牌参考库与文本对齐](003-107卡牌参考库与文本对齐.md) |

> 状态口径：三篇均已完成构建安装；实机验证结论未记录。
