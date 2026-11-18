using System;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Context;
using MegaCrit.Sts2.Core.DevConsole;
using MegaCrit.Sts2.Core.DevConsole.ConsoleCommands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Nodes;

namespace RocketPunchProbe;

[ModInitializer(nameof(Initialize))]
public static class ProbeMod
{
    public static void Initialize()
    {
        try
        {
            new Harmony("RocketPunchProbe").PatchAll(typeof(ProbeMod).Assembly);
            Log.Info("[rp-probe] installed");
        }
        catch (Exception ex)
        {
            Log.Error("[rp-probe] install failed: " + ex);
        }
    }
}

[HarmonyPatch(typeof(NGame), "IsReleaseGame")]
public static class ReleaseGatePatch
{
    public static void Postfix(ref bool __result)
    {
        __result = false;
    }
}

public sealed class RocketPunchProbeCmd : AbstractConsoleCmd
{
    public override string CmdName => "rpprobe";

    public override string Args => "";

    public override string Description => "E2E probe for RevertRocketPunch: create RocketPunch and generate a Status.";

    public override bool IsNetworked => false;

    public override CmdResult Process(Player? issuingPlayer, string[] args)
    {
        if (!CombatManager.Instance.IsInProgress)
        {
            return new CmdResult(false, "combat is not in progress");
        }

        CombatState? state = CombatManager.Instance.DebugOnlyGetState();
        if (state == null)
        {
            return new CmdResult(false, "combat state is null");
        }

        Player? player = issuingPlayer ?? LocalContext.GetMe(state);
        if (player == null)
        {
            return new CmdResult(false, "local player not found");
        }

        CardModel rocket = state.CreateCard(ModelDb.Card<RocketPunch>(), player);
        CardModel status1 = state.CreateCard(ModelDb.Card<Wound>(), player);
        CardModel status2 = state.CreateCard(ModelDb.Card<Wound>(), player);
        Task task = RunProbe(rocket, status1, status2, player);
        return new CmdResult(task, true, "probe running");
    }

    private static async Task RunProbe(CardModel rocket, CardModel status1, CardModel status2, Player player)
    {
        try
        {
            await CardPileCmd.Add(rocket, PileType.Hand, CardPilePosition.Bottom, null, true);

            var desc = rocket.Description;
            string descKey = desc.LocEntryKey;
            string descRaw = desc.GetRawText();
            Log.Info($"[rp-probe] desc key={descKey} raw={descRaw}");
            Log.Info($"[rp-probe] before={rocket.EnergyCost.GetResolved()}");

            await CardPileCmd.AddGeneratedCardToCombat(status1, PileType.Hand, player);
            int afterFirst = rocket.EnergyCost.GetResolved();
            Log.Info($"[rp-probe] after_first={afterFirst}");

            await CardPileCmd.AddGeneratedCardToCombat(status2, PileType.Hand, player);
            int afterSecond = rocket.EnergyCost.GetResolved();
            Log.Info($"[rp-probe] after_second={afterSecond}");

            bool effectPass = afterFirst == 0 && afterSecond == 0;
            bool textPass = descKey == "RE_ROCKET_PUNCH.description" && !string.IsNullOrWhiteSpace(descRaw);
            Log.Info(effectPass && textPass
                ? "[rp-probe] PASS"
                : $"[rp-probe] FAIL effect={effectPass} text={textPass}");
        }
        catch (Exception ex)
        {
            Log.Error("[rp-probe] ERROR " + ex);
        }
    }
}
