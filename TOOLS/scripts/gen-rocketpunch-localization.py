#!/usr/bin/env python3
"""生成 RevertRocketPunch 15 语言本地化文件与空白占位 mod 图标。

描述文本 = 107 语义（生成状态牌 → 费用降为 0，直至打出），模板与 111 官方逐字同构
（仅「减少 1 / by 1 / 降低 1」→「降为 0 / to 0 / 降為 0」）：
- 14 语言取自 CustomCardBalance.RocketPunchDescription（该 mod 目标即 107 效果，已实战验证）；
- zht 按 111 官方繁中句式改写（「每當你創造一張狀態牌時，使此牌耗能降為 0，直到打出為止」）；
- ind 按用户决策不提供（ind 玩家不切键，见 RocketPunchTextPatch.IsSupportedLanguage）。

用法: python gen-rocketpunch-localization.py
"""
import json
import struct
import zlib
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
LOC_DIR = ROOT / "src" / "RevertRocketPunch" / "RevertRocketPunch" / "localization"
ICON_PATH = ROOT / "src" / "RevertRocketPunch" / "RevertRocketPunch" / "mod_image.png"

DESC = {
    "deu": "Füge {Damage:diff()} Schaden zu.\nZiehe {Cards:diff()} {Cards:plural:Karte|Karten}.\nImmer wenn du einen Status erzeugst, senke die Kosten dieser Karte auf 0 {energyPrefix:energyIcons(1)}, bis du sie spielst.",
    "eng": "Deal {Damage:diff()} damage.\nDraw {Cards:diff()} {Cards:plural:card|cards}.\nWhenever you create a Status, reduce this card's cost to 0 {energyPrefix:energyIcons(1)} until played.",
    "esp": "Infliges {Damage:diff()} de daño.\nRobas {Cards:diff()} {Cards:plural:carta|cartas}.\nAl crear una carta de estado, se reduce el costo de esta carta a 0 {energyPrefix:energyIcons(1)} hasta que se juegue.",
    "fra": "Infligez {Damage:diff()} dégâts.\nPiochez {Cards:diff()} {Cards:plural:carte|cartes}.\nLorsque vous créez une carte Statut, réduisez le coût de cette carte à 0 {energyPrefix:energyIcons(1)} jusqu'à ce qu'elle soit jouée.",
    "ita": "Infliggi {Damage:diff()} di danno.\nPeschi {Cards:diff()} {Cards:plural:carta|carte}.\nOgni volta che crei una carta Stato, riduci il costo di questa carta a 0 {energyPrefix:energyIcons(1)} finché non viene giocata.",
    "jpn": "{Damage:diff()}ダメージを与える。\nカードを{Cards:diff()}枚引く。\n状態異常を作成するたび、プレイするまでこのカードのコストは0{energyPrefix:energyIcons(1)}。",
    "kor": "피해를 {Damage:diff()} 줍니다.\n카드를 {Cards:diff()}장 뽑습니다.\n상태이상 카드를 생성 시,\n이 카드의 비용이 사용하기\n전까지 0 {energyPrefix:energyIcons(1)}으로 감소합니다.",
    "pol": "Zadaj {Damage:diff()} pkt. obrażeń.\nDobierz {Cards:diff()} {Cards:plural:kartę|karty|kart}.\nKiedykolwiek stworzysz kartę Stanu, zredukuj koszt tej karty do 0 {energyPrefix:energyIcons(1)} aż do zagrania.",
    "ptb": "Cause {Damage:diff()} de dano.\nCompre {Cards:diff()} {Cards:plural:carta|cartas}.\nQuando você criar uma carta de Condição, reduza o custo desta carta para 0 {energyPrefix:energyIcons(1)} até que seja jogada.",
    "rus": "Наносит {Damage:diff()} урона.\nВы добираете {Cards:diff()} {Cards:plural(ru):карту|карты|карт}.\nСтоимость понижается до 0 {energyPrefix:energyIcons(1)} на одно разыгрывание, когда вы создаете Статус.",
    "spa": "Inflige {Damage:diff()} de daño.\nRoba {Cards:diff()} {Cards:plural:carta|cartas}.\nCuando crees una carta de Estado, reduce el coste de esta carta a 0 {energyPrefix:energyIcons(1)} hasta que se juegue.",
    "tha": "สร\u0e49างความเส\u0e35ยหาย {Damage:diff()}\nจ\u0e31\u0e48วการ\u0e4cด {Cards:diff()} ใบ\nท\u0e38กคร\u0e31\u0e49งท\u0e35\u0e48ค\u0e38ณสร\u0e49างการ\u0e4cดสถานะ ลดค\u0e48าร\u0e48ายการ\u0e4cดน\u0e35\u0e49เหล\u0e37อ 0 {energyPrefix:energyIcons(1)} จนกว\u0e48าจะถ\u0e39กเล\u0e48น",
    "tur": "{Damage:diff()} hasar ver.\n{Cards:diff()} {Cards:plural:kart|kart} çek.\nHer Durum kartı oluşturduğunda bu kartın maliyeti, oynanana kadar 0 {energyPrefix:energyIcons(1)} olur.",
    "zhs": "造成{Damage:diff()}点伤害。\n抽{Cards:diff()}张牌。\n每当你生成状态牌时，此牌的耗能将在下一次打出前降为0{energyPrefix:energyIcons(1)}。",
    "zht": "造成 {Damage:diff()} 點傷害。\n抽 {Cards:diff()} 張牌。\n每當你創造一張狀態牌時，使此牌耗能降為 0 {energyPrefix:energyIcons(1)}，直到打出為止。",
}

# 111 官方 zht 句式对照（供复核）：
# "造成 {Damage:diff()} 點傷害。\n抽 {Cards:diff()} 張牌。\n每當你創造一張狀態牌時，使此牌耗能降低 1 {energyPrefix:energyIcons(1)}，直到打出為止。"


def gen_localization() -> None:
    for lang, desc in DESC.items():
        data = {"RE_ROCKET_PUNCH.description": desc}
        path = LOC_DIR / lang / "cards.json"
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(json.dumps(data, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
        print(f"wrote {lang}")


def gen_icon() -> None:
    W = H = 420

    def chunk(tag: bytes, data: bytes) -> bytes:
        return (struct.pack(">I", len(data)) + tag + data
                + struct.pack(">I", zlib.crc32(tag + data) & 0xFFFFFFFF))

    raw = b"".join(b"\x00" + b"\x00\x00\x00\x00" * W for _ in range(H))
    png = (b"\x89PNG\r\n\x1a\n"
           + chunk(b"IHDR", struct.pack(">IIBBBBB", W, H, 8, 6, 0, 0, 0))
           + chunk(b"IDAT", zlib.compress(raw, 9))
           + chunk(b"IEND", b""))
    ICON_PATH.parent.mkdir(parents=True, exist_ok=True)
    ICON_PATH.write_bytes(png)
    print(f"wrote {ICON_PATH} ({len(png)} bytes, {W}x{H} RGBA transparent)")


if __name__ == "__main__":
    gen_localization()
    gen_icon()