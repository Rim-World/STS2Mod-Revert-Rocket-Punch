# ADR-002：修复「补丁未生效」——ModelDb 访问时机错误

- 日期：2026-08-20
- 状态：已修复（v1.0.1 已构建安装，待实机验证）
- 关联计划：`2.PLANS/001-G-火箭飞拳回调计划.md`
- 关联决策：ADR-001 决策 3（卡存在性检查）

## 背景

用户实机验证反馈：mod 在 mods 菜单可见、已启用、已加载列表存在，但卡面文本与实际效果均保持 111 原版，补丁完全未生效。

## 根因

ModLoaded 阶段访问了尚未初始化的 ModelDb：

- 启动时序（`MegaCrit.Sts2.Core.Helpers/OneTimeInitialization.cs`）：
  1. `ExecuteVeryEarly` → `ModManager.Initialize()` → `CallModInitializer()`（**ModLoaded 在此被调用**）；
  2. `ExecuteEssential` → `LocManager.Initialize()` → `ModelDb.Init()`（**ModelDb 在此之后才初始化**）。
- 原实现 `ModEntry.ModLoaded` 中 `RocketPunchGuard.ValidateCardExists()` 调用 `ModelDb.Card<RocketPunch>()`，此时 `_contentById` 为空字典必然 `KeyNotFoundException` → 被 catch 判为「卡不存在」→ `_cardExists=false` → **直接 return，`Harmony.PatchAll` 从未执行**。
- 后果：所有补丁（效果 Prefix、文本 Postfix）均未安装 → 卡面文本与对局效果全部保持原版，与用户观察完全吻合。
- mod 本身仍显示「已加载」：ModLoaded 正常返回、无异常抛出。

## 决策

1. **ModLoaded 阶段绝不访问 ModelDb**：`ModEntry.ModLoaded` 无条件 `PatchAll`（补丁目标类型/方法引用由编译期保证存在，无需运行时检查）。
2. **卡存在性检查移至运行时懒评估**：`RocketPunchGuard.IsSupported()` 在补丁首次触发时（对局/图鉴，ModelDb 必然已就绪）调用 `ModelDb.Card<RocketPunch>()`；成功 → 缓存 true；失败 → 告警一次 + 暂放行不缓存（与回调王座 `SealedThroneShapeGuard` 先例一致）。
3. 删除 `ValidateCardExists()` 及其在 ModLoaded 的调用点。

## 经验教训（写入 docs 供后续项目复用）

- **任何 mod 的 ModLoaded 中禁止访问 ModelDb / LocManager**（两者在 ExecuteEssential 阶段才初始化，晚于 ModLoaded 的 ExecuteVeryEarly）。
- 与运行期状态相关的检查一律放到补丁运行时首次触发时懒评估。

## 修订记录

- 2026-08-20：根因定位（OneTimeInitialization.cs:59/81 时序证据），修复并重建安装。