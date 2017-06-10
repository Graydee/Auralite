using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Buffs
{
	public class Sandstorm : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Sandstorm";
			Main.buffTip[Type] = "The wind destros those near you.";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		
		public override void Update(NPC npc, ref int buffIndex)
		{
			int Rando = Main.rand.Next(1000);
			if (Rando == 13);
			{
				int proj = Projectile.NewProjectile((npc.Center.X - 125) + Main.rand.Next(250), (npc.Center.Y - 125) + Main.rand.Next(250), 0f, 0f, mod.ProjectileType("Sandwave"), 4/* this is damage */, 0, Main.myPlayer);
			}
		}	
	}
}
