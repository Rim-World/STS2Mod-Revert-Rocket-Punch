# Changelog

本文件遵循 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/) 规范，版本号遵循语义化版本。分版本明细见 `7.ChangeLog/`。

## [1.1.0] - 2026-11-19

### 新增

- 0.111.1 与 0.113.1 双版本兼容：发布 DLL 以 0.111.1 程序集为编译基线，同一份 DLL 在 0.113.1 运行。
- `ind` 卡面描述（`RE_ROCKET_PUNCH.description`），描述改为「menjadi 0」，与回调后的效果一致。
- `8.TEST/CI-CD/verify-version.ps1`：构建前校验 manifest、`CHANGELOG.md` 与 `7.ChangeLog/ChangeLog.md` 的版本号一致。
- PRD、SPEC、TEST 索引与版本化临时文件目录，补齐 AGENTS.md 要求的十目录结构。

### 变更

- `build.ps1` 支持 `-Sts2DataDir`，可用参考库中的 0.111.1 程序集编译；构建前自动运行版本门禁。
- 支持语言从 15 种增至 16 种：新增 `ind`。`ara` 不切键，因为 0.113.1 官方阿拉伯语文本已经表达「降为 0」。
- manifest `version` 升至 `1.1.0`。

### 修复

- 修复 `ind` 语言下「效果已回调、文本仍写减少 1」的不一致。
- 本地化生成脚本的输出路径从旧的 `src/` 改为 `9.SRC/`；`fra`、`spa` 的 NBSP 在脚本中固化，重跑不再丢失。

### 验证

- 0.113.1 无头场景探针通过：火箭飞拳费用 2 → 0 → 0；描述键为 `RE_ROCKET_PUNCH.description`，`zht` 文本为「降為 0」。
- 0.111.1/0.113.1 双程序集编译均为 0 警告 0 错误，成员引用集合一致。

### 已知问题

- 0.111.1 运行验证需用户切换 Steam 分支后手动完成；本机当前安装为 0.113.1。
- `ara` 依赖 0.113.1 官方文本保持「降为 0」语义；游戏更新后需复核。

## [1.0] - 2026-08-21

### 新增

- `RevertRocketPunch` mod：把「火箭飞拳」从 v0.110 起的「生成状态牌 → 耗能减少 1」回调为 v0.110 之前的「生成状态牌 → 耗能降为 0」（`SetUntilPlayed(0)`）。
- 15 语言卡面描述（`RE_ROCKET_PUNCH.description`）：deu / eng / esp / fra / ita / jpn / kor / pol / ptb / rus / spa / tha / tur / zhs / zht。
- 卡存在性守卫与版本门：`Minor >= 110` 才生效；卡牌缺失或版本低于 0.110 时不介入。

### 修复

- 修复 `ModLoaded` 阶段访问 `ModelDb` 导致 `PatchAll` 从未执行、补丁完全无效的问题；卡存在性检查改为运行时懒评估。

### 变更

- fra / spa 描述改用官方 107 的不换行空格（NBSP），其余语言与官方 107 文本一致；`zht` 因 107 无官方文本，采用 111 官方繁中句式。

### 已知问题

- `ind` 语言描述未替换（保持官方 111 文案），卡牌效果仍生效。已在 1.1.0 修复。
- mod 清单 `version` 始终为 `1.0`，未随构建标记 v1.0.1 / v1.0.2 递增。已在 1.1.0 修正。
- 实机验证结论未记录；仓库内无自动化测试。1.1.0 起补充无头探针与测试索引。
