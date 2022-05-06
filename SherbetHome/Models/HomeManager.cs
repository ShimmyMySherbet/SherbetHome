using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketExtensions.Models;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace SherbetHome.Models
{
    public class HomeManager : MonoBehaviour
    {
        public SherbetHomes Plugin => GetComponent<SherbetHomes>();

        public List<HomeRequest> Requests = new List<HomeRequest>();

        public bool IsHomePending(ulong playerID) => Requests.Any(x => x.Player.PlayerID == playerID);

        public void StartRequest(CommandContext context)
        {
            var request = new HomeRequest(context, Plugin.Config.HomeDelay);

            lock (Requests)
                Requests.Add(request);

            Task.Run(() => HomeWaiter(request));
        }

        private async Task HomeWaiter(HomeRequest request)
        {
            try
            {
                while (DateTime.Now < request.Finishes)
                {
                    await Task.Delay(200);

                    if (Vector3.Distance(request.Player.Position, request.StartPosition) > 1f)
                    {
                        lock (Requests)
                            Requests.Remove(request);

                        await request.Context.ReplyKeyAsync("Home_Failed_Move");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lock (Requests)
                    Requests.Remove(request);
                Logger.LogError(ex.Message);
                return;
            }

            lock (Requests)
                Requests.Remove(request);

            if (BarricadeManager.tryGetBed(request.Player.CSteamID, out var pos, out var byt))
            {
                if (await request.Player.TeleportAsync(pos + new Vector3(0f, 1f, 0f), byt))
                {
                    await request.Context.ReplyKeyAsync("Home_Teleported");
                }
                else
                {
                    await request.Context.ReplyKeyAsync("Home_Failed_Blocked");
                }
            }
            else
            {
                await request.Context.ReplyKeyAsync("Home_Failed_Blocked");
            }
        }
    }
}