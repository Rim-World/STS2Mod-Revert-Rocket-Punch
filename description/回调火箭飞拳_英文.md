English | [中文](README.zh.md)

# If you like this mod, welcome to check out my other mods. They might be helpful to you.

## 1\. Effects

Reverts the effect of the "Rocket Punch" card from the v0.111 version's "Whenever you create a Status, reduce this card's cost by 1" back to the pre-v0.110 version's "Whenever you create a Status, reduce this card's cost to 0".

All other effects remain unchanged: 2 cost Attack, deals 13 damage (14 on upgrade), draws 1 card (2 on upgrade); the card text is restored to the old wording, and the card art is unchanged.

This mod works by modifying the original "Rocket Punch" card directly, rather than creating a new card and disabling the old one.

## 2\. Impact (Based on My Understanding of the Game)

Before version v0.110.0, Rocket Punch was a strong transitional/final engine piece that you could practically take one of without a second thought. As long as you had a card that generated a Status card, there was a more than 50% chance that you could play it for 0 Energy, and starting from the second reshuffle, you could almost consistently play it for 0 Energy.

However, the changes in version v0.110.0 significantly weakened it. Not only was its role as an early-game transitional card greatly diminished, but even when used as a core engine piece later in a run, you now have to pay considerably more attention to the order in which you play your cards, which feels rather awkward.

Save File Impact:While this mod is enabled, the "Rocket Punch" card description in the History will be displayed using the reverted wording. Disabling the mod will restore the original description.

## 3\. Environment & Version

This mod does not depend on any base mod.

This mod takes effect on 0.110.0 or later (it is active on the current 0.111.0);

it disables itself automatically on 0.099.x–0.109.x, because Rocket Punch in the version range already has the target effect and needs no modification.

At runtime, the mod checks the current game version and whether the Rocket Punch card exists in the game package: if the version is below 0.110 or the card has been removed, the mod simply does not take effect, without errors or crashes.

In theory, as long as there are no major API updates or card changes, this mod should automatically adapt to new versions without any modification.

## 4\. Language Support

The card text provided by this mod covers 15 languages: deu / eng / esp / fra / ita / jpn / kor / pol / ptb / rus / spa / tha / tur / zhs / zht.

14 of these languages match the official v0.107.1 text exactly; zht (Traditional Chinese) is based on the official v0.111.0 Traditional Chinese text with modifications, since v0.107 did not provide Traditional Chinese.

For languages not provided by v0.107 (i.e., ind), the description is not replaced and the official v0.111 text is kept, but the card effect is still replaced; no errors are raised.

## 5\. Implementation & Compatibility

This mod is written with minimal dependencies, so under normal circumstances it is compatible with most mods and unlikely to break as the game version changes.

This mod uses external patches to hard-code the card text (description) and the cost-reduction trigger of Rocket Punch to their pre-v0.110 versions; the card name remains official, and nothing else is hard-coded.

The mod works in the same way across all supported game versions.

However, compatibility is not guaranteed with pirated copies, modified versions, mobile versions, outdated versions, niche mods, or secondary mods.

## 6\. Credits

This mod was made with Opencode + DeepSeek V4 Flash (0731 GA). Thanks to Saint Liang.

Thanks to the Slay the Spire 2 team for their efforts to make modding easier for players.

Thanks to the Baselib developers for their documentation.

## 7\. Open-Source Repository & Contact

Open-source repository: https://github.com/Rim-World/STS2Mod-Revert-Rocket-Punch

Feel free to leave your comments and feedback in the comment section.