using Cysharp.Threading.Tasks;
using Rocket.API;
using RocketExtensions.Models;
using RocketExtensions.Plugins;
using SDG.Unturned;

namespace SherbetHome.Commands
{
    [AllowedCaller(AllowedCaller.Player), CommandInfo(Help: "Teleports you to your bed")]
    public class HomeCommand : RocketCommand
    {
        public new SherbetHomes Plugin => base.Plugin as SherbetHomes;

        public override async UniTask Execute(CommandContext context)
        {
            if (!BarricadeManager.tryGetBed(context.UnturnedPlayer.CSteamID, out _, out _))
            {
                await context.ReplyKeyAsync("Home_Fail_NoBed");
                await context.CancelCooldownAsync();
                return;
            }

            if (Plugin.HomeManager.IsHomePending(context.PlayerID))
            {
                await context.ReplyKeyAsync("Home_Fail_AlreadyPending");
                await context.CancelCooldownAsync();
                return;
            }

            Plugin.HomeManager.StartRequest(context);
            await context.ReplyKeyAsync("Home_Wait", Plugin.Config.HomeDelay);
        }
    }
}