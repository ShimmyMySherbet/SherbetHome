using System;
using RocketExtensions.Models;
using UnityEngine;

namespace SherbetHome.Models
{
    public class HomeRequest
    {
        public LDMPlayer Player => Context.LDMPlayer;
        public DateTime Started { get; }
        public Vector3 StartPosition { get;  }
        public DateTime Finishes { get; }
        public CommandContext Context { get; }

        public HomeRequest(CommandContext context, int secDeley)
        {
            Context = context;
            Started = DateTime.Now;
            StartPosition = Player.Position;
            Finishes = Started.AddSeconds(secDeley);
        }
    }
}