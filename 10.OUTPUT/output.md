# OUTPUT 索引

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-11-01 | `02-发布包/RevertRocketPunch.v1.0.zip` | 1.0 | 250.7 KB（256,732 B） | 发布用运行包，取自本机 `mods/RevertRocketPunch/`：`RevertRocketPunch.dll` + `.pck` + `.json`（已排除 `.sts2-workshop-uploader/` 等以 `.` 开头的目录） |
| 2026-11-01 | `02-发布包/RevertRocketPunchSourceCode.zip` | 1.0 | 146.3 KB（149,804 B） | 源码包，取自 `9.SRC/RevertRocketPunch/`（排除 `.godot/`、`bin/`、`obj/`、`*.dll`、`*.pck`、`*.pdb`） |

## 说明

- `01-构建产物/`：预留存放本地构建产物，当前为空（构建由 `9.SRC/RevertRocketPunch/build.ps1` 直接输出到游戏 `mods/` 目录）。
- `02-发布包/`：GitHub Release 资产，已在上表登记。
- `03-备份/`：预留，当前为空。
- 本目录除 `output.md` 外全部被根 `.gitignore` 排除，不入库。
