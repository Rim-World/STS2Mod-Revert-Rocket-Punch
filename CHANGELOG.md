# Changelog

本文件遵循 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/) 规范，版本号遵循语义化版本。分版本明细见 `5.ChangeLog/`。

## [未发布]

### 变更

- 仓库整理为 AGENTS 十目录结构（`1.ADR` / `2.PLANS` / `3.DOCS` / `4.SDD` / `5.ChangeLog` / `9.SRC` / `10.OUTPUT` / `PRIVACY` / `TMP` / `TOOLS`），补全 README、CHANGELOG、SDD、版本日志与索引文档。
- 文档重命名为三位编号中文文件名；源码与 mod 清单内容保持不变。

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

- `ind` 语言描述未替换（保持官方 111 文案），卡牌效果仍生效。
- mod 清单 `version` 始终为 `1.0`，未随构建标记 v1.0.1 / v1.0.2 递增。
- 实机验证结论未记录；仓库内无自动化测试。
