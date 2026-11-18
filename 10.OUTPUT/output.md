# OUTPUT 索引

仅保留最近三个版本的成品。当前版本：1.1.0。

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-11-19 00:38 | `02-发布包/RevertRocketPunch.v1.1.0.zip` | 1.1.0 | 248,682 B（242.9 KB） | 发布用运行包：`RevertRocketPunch.dll` + `.pck` + `.json`；DLL 以 0.111.1 程序集编译，SHA-256 `506137e6…` |
| 2026-11-19 00:38 | `02-发布包/RevertRocketPunchSourceCode.v1.1.0.zip` | 1.1.0 | 150,363 B（146.8 KB） | 源码包：`9.SRC/RevertRocketPunch/`，排除 `.godot/`、`bin/`、`obj/`、`*.dll`、`*.pck`、`*.pdb` |
| 2026-11-01 | `02-发布包/RevertRocketPunch.v1.0.zip` | 1.0 | 256,732 B（250.7 KB） | 首个发布用运行包；取自当时 `mods/RevertRocketPunch/` |
| 2026-11-01 | `02-发布包/RevertRocketPunchSourceCode.v1.0.zip` | 1.0 | 149,804 B（146.3 KB） | 首个源码包；原文件名无版本号，2026-11-19 重命名 |

## 说明

- `01-构建产物/`：预留存放本地构建产物，当前为空（构建由 `9.SRC/RevertRocketPunch/build.ps1` 直接输出到游戏 `mods/`）。
- `02-发布包/`：GitHub Release 资产，已在上表登记；`.zip` 被根 `.gitignore` 排除，不入库。
- `03-备份/`：预留，当前为空。
- 本目录除 `OUTPUT.md` 外全部被根 `.gitignore` 排除，不入库。
