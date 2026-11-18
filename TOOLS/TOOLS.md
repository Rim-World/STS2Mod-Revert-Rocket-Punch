# TOOLS 索引

| 时间 | 工具/脚本 | 用途 | 版本 | 大小 | 来源 | 安装方式/依赖 |
|---|---|---|---|---|---|---|
| 2026-08-20（2026-11-19 更新） | `scripts/gen-rocketpunch-localization.py` | 生成 16 语言 `9.SRC/RevertRocketPunch/RevertRocketPunch/localization/<lang>/cards.json`（`RE_ROCKET_PUNCH.description`）与图标 `mod_image.png`（仅缺失时生成空白占位图） | 1.1.0 | 6.0 KB | 本项目自写（复用「回调同步」系列脚本，改键前缀与文案） | 无需安装；Python 3 标准库（`json` / `struct` / `zlib` / `pathlib`），在项目根目录执行 |

## 说明

- `scripts/` 存放单独使用的自写脚本，明细见 `scripts/scripts.md`。
- 未引入第三方工具或便携版软件；构建依赖（.NET 9 SDK、Godot 4.5.1 mono）安装在本机全局环境，不收纳在本目录。
- 脚本生成的本地化文件与图标直接写入 `9.SRC/RevertRocketPunch/`，不产生额外出物。
- 版本门禁 `8.TEST/CI-CD/verify-version.ps1` 按 AGENTS.md 归入 `8.TEST/CI-CD/`，不重复放入本目录。
