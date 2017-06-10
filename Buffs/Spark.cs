using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Buffs
{
	public class Spark : ModBuff
	{
		private int DontLookInTheCode = 0;
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Spark";
			Main.buffTip[Type] = "The flame is spreading";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		
		public override void Update(NPC npc, ref int buffIndex)
		{
				int proj = Projectile.NewProjectile((npc.Center.X - 75) + Main.rand.Next(150), (npc.Center.Y - 75) + Main.rand.Next(150), Main.rand.Next(-350,350) / 100, Main.rand.Next(-350,350) / 100, mod.ProjectileType("FireParticle"), 24/* this is damage */, 0, Main.myPlayer);
				proj = Projectile.NewProjectile((npc.Center.X - 75) + Main.rand.Next(150), (npc.Center.Y - 75) + Main.rand.Next(150), Main.rand.Next(-350,350) / 100, Main.rand.Next(-350,350) / 100, mod.ProjectileType("FireParticle"), 22/* this is damage */, 0, Main.myPlayer);
				proj = Projectile.NewProjectile((npc.Center.X - 75) + Main.rand.Next(150), (npc.Center.Y - 75) + Main.rand.Next(150), Main.rand.Next(-350,350) / 100, Main.rand.Next(-350,350) / 100, mod.ProjectileType("FireParticle"), 26/* this is damage */, 0, Main.myPlayer);
				proj = Projectile.NewProjectile((npc.Center.X - 75) + Main.rand.Next(150), (npc.Center.Y - 75) + Main.rand.Next(150), Main.rand.Next(-350,350) / 100, Main.rand.Next(-350,350) / 100, mod.ProjectileType("FireParticle"), 25/* this is damage */, 0, Main.myPlayer);
		}
	}
}
