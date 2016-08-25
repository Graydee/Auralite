using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Auralite.WorldContent;

namespace Auralite
{
	public class AuralitePlayer : ModPlayer
	{
		public bool ZoneNebula { get{ return DimLib.InDimension((int)player.position.X, mod.Name, "Nebula"); } }
		public bool ZoneSolar { get{ return DimLib.InDimension((int)player.position.X, mod.Name, "Solar"); } }
		public bool ZoneStardust { get{ return DimLib.InDimension((int)player.position.X, mod.Name, "Stardust"); } }
		public bool ZoneVortex { get{ return DimLib.InDimension((int)player.position.X, mod.Name, "Vortex"); } }
        public bool ZoneMystic = false;
		public bool ZoneSlime = false;
		public bool ZoneSpring = false;
		public bool ZoneFlower = false;
		public bool ZoneFlame = false;
		public int partySize = 0;
        public bool auraWatch = false;
		public bool mysticMirror = false;
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
			mysticMirror = false;
        }

        public override void UpdateBiomes()
		{
			ZoneMystic = (MysticCaves.MysticTiles > 500);
			ZoneSpring = (Springs.SpringTiles > 300);
			ZoneSlime = (SlimeNest.SlimeTiles > 500);
			ZoneFlower = (FlowerForest.FlowerTiles > 500);
			ZoneFlame = (VolcanicAshes.FlameTiles > 500);
		}

		public override void UpdateBiomeVisuals()
		{
			if(ZoneNebula) {
				//Filters.Scene.Activate("Auralite:Nebula", player.position, new object[0]);
				//SkyManager.Instance.Activate("Auralite:Nebula", player.position, new object[0]);

			}
			player.ManageSpecialBiomeVisuals("Auralite:NebulaSky", ZoneNebula, player.Center);
			player.ManageSpecialBiomeVisuals("Auralite:SolarSky", ZoneSolar, player.Center);
			player.ManageSpecialBiomeVisuals("Auralite:StardustSky", ZoneStardust, player.Center);
			player.ManageSpecialBiomeVisuals("Auralite:VortexSky", ZoneVortex, player.Center);
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
			if(mysticMirror)
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("ShadowBlade"), 28, 0f, player.whoAmI, 0f, 0f);
			}
        }
    }
}
