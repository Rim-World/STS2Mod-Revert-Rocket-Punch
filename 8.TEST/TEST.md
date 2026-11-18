# TEST 索引

测试工件按版本号分目录。当前开发版本：1.1.0。门禁脚本放在 `CI-CD/`，不随版本清理。

## 1.1

| 文件名 | 创建时间 | 是否清理 | 文件大小（KB） | 用途 | 引用和复用 |
|---|---|---|---|---|---|
| `RocketPunchProbe/ProbeMod.cs` | 2026-11-19 00:27 | 否 | 4 | 无头场景探针：`NGame.IsReleaseGame` 后门、`rpprobe` 命令、费用与文本断言 | 是 |
| `RocketPunchProbe/RocketPunchProbe.csproj` | 2026-11-19 00:27 | 否 | 2 | 探针构建与部署到 `mods/RocketPunchProbe/` | 是 |
| `RocketPunchProbe/mod_manifest.json` | 2026-11-19 00:27 | 否 | 1 | 探针清单；`affects_gameplay=false` | 是 |
| `场景-火箭飞拳探针.txt` | 2026-11-19 00:28 | 否 | 1 | ScenarioRunner 脚本：进入战斗、执行 `rpprobe`、等待 3 秒 | 是 |
| `2026-11-19-0032-scenario.stdout` | 2026-11-19 00:31 | 否 | 199 | 第一次场景运行的完整标准输出 | 否 |
| `2026-11-19-0032-scenario-godot.log` | 2026-11-19 00:31 | 否 | 197 | 第一次场景运行的游戏日志副本 | 否 |
| `2026-11-19-0034-scenario.stdout` | 2026-11-19 00:34 | 否 | 200 | 第二次场景运行的标准输出（占位图标版本） | 否 |
| `2026-11-19-0034-scenario-godot.log` | 2026-11-19 00:34 | 否 | 198 | 第二次场景运行的游戏日志副本 | 否 |
| `2026-11-19-0038-scenario.stdout` | 2026-11-19 00:38 | 否 | 200 | 最终构建的场景运行标准输出；含 `[rp-probe] PASS` | 是 |
| `2026-11-19-0038-scenario-godot.log` | 2026-11-19 00:38 | 否 | 198 | 最终构建的游戏日志副本；含 mod 加载、补丁安装、文本与费用记录 | 是 |

## CI-CD

| 文件名 | 创建时间 | 是否清理 | 文件大小（KB） | 用途 | 引用和复用 |
|---|---|---|---|---|---|
| `verify-version.ps1` | 2026-11-19 00:25 | 否 | 2 | 校验 manifest、`CHANGELOG.md`、`7.ChangeLog` 的版本号一致；`build.ps1` 构建前调用 | 是 |

## 说明

- 探针只在测试期间放入游戏 `mods/`，测试后移出；发布包不包含探针。
- 测试使用真实存档。ScenarioRunner 的 `ApplyPreflight` 可能改动进度文件；用户已自行备份存档。
- 无头测试不覆盖视觉排版、动画、音效与多人联机。
