using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite.WorldContent;

namespace Auralite
{
	public class AuralitePlayer : ModPlayer
	{
        public bool ZoneMystic = false;
		public bool ZoneSlime = false;
		public bool ZoneSpring = false;
		public bool ZoneFlame = false;
		public int partySize = 0;
        public bool auraWatch = false;
        public int freezeTime = 0;
		public override void ResetEffects()
		{
			partySize = 0;

			//Keep current party size properly updated
			foreach(int val in ((MercData)mod.GetModWorld("MercData")).data.Values) {
				if(val == player.whoAmI) {
					partySize++;
				}
			}
            auraWatch = false;
        }

        public override void UpdateBiomes()
		{
			ZoneMystic = (MysticCaves.MysticTiles > 500);
			ZoneSpring = (Springs.SpringTiles > 300);
			ZoneSlime = (SlimeNest.SlimeTiles > 500);
			ZoneFlame = (VolcanicAshes.FlameTiles > 500);
		}
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if(auraWatch)
            {
                    if (Main.rand.Next(50) == 0)
                    {
                    player.AddBuff(mod.BuffType("StolenTime"), 120);
                    }
                
            }
        }
    }
}
