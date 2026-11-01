# TOOLS 索引

| 时间 | 工具/脚本 | 用途 | 版本 | 大小 | 来源 | 安装方式/依赖 |
|---|---|---|---|---|---|---|
| 2026-08-20 | `scripts/gen-rocketpunch-localization.py` | 生成 15 语言 `RevertRocketPunch/localization/<lang>/cards.json`（`RE_ROCKET_PUNCH.description`）与空白占位图标 `mod_image.png` | 未记录 | 5.7 KB | 本项目自写（复用「回调同步」系列脚本，改键前缀与文案） | 无需安装；Python 3 标准库（`json` / `struct` / `zlib` / `pathlib`），在项目根目录执行 |

## 说明

- `scripts/` 存放单独使用的自写脚本，明细见 `scripts/scripts.md`。
- 未引入第三方工具或便携版软件；构建依赖（.NET 9 SDK、Godot 4.5.1 mono）安装在本机全局环境，不收纳在本目录。
- 脚本生成的本地化文件与图标直接写入 `9.SRC/RevertRocketPunch/`，不产生额外出物。
