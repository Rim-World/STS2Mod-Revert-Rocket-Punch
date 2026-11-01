# TMP 索引

| 时间 | 文件/目录 | 用途 | 格式 | 大小 | 来源 |
|---|---|---|---|---|---|
| 2026-11-01 | `01-旧Git仓库/RevertRocketPunch.git/` | 整理前 `src/RevertRocketPunch/` 内的旧克隆仓库（远端 `Rim-World/STS2Mod-Revert-Rocket-Punch`，HEAD `06d99d2`）；仓库改为根目录单一 git 后归档保留 | git 裸/普通仓库目录 | 184 KB | 原 `src/RevertRocketPunch/.git`，整体 `mv` 而来 |
| 2026-11-01 | `02-缓存与临时/` | 缓存与中间产物分类目录，当前为空 | 目录 | 0 | 新建 |

## 分类说明

- `01-旧Git仓库/`：整理过程中移出的嵌套 git 目录。保留是为了不丢失历史证据，确认新仓库历史完整后可自行归档到别处。
- `02-缓存与临时/`：预留给 `%TEMP%` 类中间产物；本项目的构建缓存 `.godot/` 仍留在 `9.SRC/RevertRocketPunch/` 内（Godot 工程运行需要，且已被根 `.gitignore` 忽略）。

## 清理建议

- `01-旧Git仓库/RevertRocketPunch.git` 在确认远端历史完整（`git log` 含 726e54a / 199887f / 06d99d2）后可删除；目前建议保留。
- `9.SRC/RevertRocketPunch/.godot/` 是 Godot 导入缓存，体积会随构建增长；需要时可在 Godot 编辑器内删除后重新导入。
- 本目录除 `TMP.md` 外全部被 `.gitignore` 排除，不会入库。
