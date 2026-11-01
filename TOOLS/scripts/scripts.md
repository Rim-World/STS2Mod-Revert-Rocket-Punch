# scripts 索引

| 时间 | 脚本 | 用途 | 依赖 | 使用方式 |
|---|---|---|---|---|
| 2026-08-20 | `gen-rocketpunch-localization.py` | 生成 15 语言卡面描述 JSON 与空白占位 mod 图标 | Python 3（标准库 `json` / `struct` / `zlib` / `pathlib`） | 在项目根目录执行 `python TOOLS/scripts/gen-rocketpunch-localization.py`；输出路径按脚本所在位置回推项目根（`parent.parent`），路径为原 `src/` 布局，当前源码已迁至 `9.SRC/`，如需重跑请先核对脚本内的 `LOC_DIR` / `ICON_PATH` |
