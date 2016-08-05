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
		public int maxPartySize = 4;
		public int partySize = 0;

		public override void ResetEffects()
		{
			partySize = 0;

			//Keep current party size properly updated
			foreach(int val in ((MercData)mod.GetModWorld("MercData")).data.Values) {
				if(val == player.whoAmI) {
					partySize++;
				}
			}
		}

        public override void UpdateBiomes()
		{
			ZoneMystic = (MysticCaves.MysticTiles > 500);
			ZoneSpring = (Springs.SpringTiles > 300);
			ZoneSlime = (SlimeNest.SlimeTiles > 500);
		}
    }
}
