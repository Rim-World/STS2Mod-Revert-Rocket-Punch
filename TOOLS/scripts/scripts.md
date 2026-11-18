# scripts 索引

| 时间 | 脚本 | 用途 | 依赖 | 使用方式 |
|---|---|---|---|---|
| 2026-08-20（2026-11-19 更新） | `gen-rocketpunch-localization.py` | 生成 16 语言卡面描述 JSON；图标缺失时生成空白占位图；`fra`/`spa` 使用 NBSP | Python 3（标准库 `json` / `struct` / `zlib` / `pathlib`） | 在项目根目录执行 `python TOOLS/scripts/gen-rocketpunch-localization.py`；输出到 `9.SRC/RevertRocketPunch/RevertRocketPunch/localization/` 与同名图标 |

- 脚本内的 `ROOT` 为项目根（脚本路径向上三级），不再使用已废弃的 `src/` 布局。
- 重跑会覆盖 `cards.json`；已有的 `mod_image.png` 会保留。`fra`/`spa` 的 NBSP 已在源码中写成 `\u00a0`，不会丢失。
