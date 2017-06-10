using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Auralite.Projectiles
{
	public class GearGrinder : ModProjectile
	{
		private int DontLookInTheCode = 0;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodYoyo);
			projectile.name = "Gear Grinder";
			projectile.penetrate = 6;
			projectile.timeLeft = 500;
		}
		public override void AI()
	{
		DontLookInTheCode++;
		if (DontLookInTheCode % 26 == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-350,350) / 100, Main.rand.Next(-350,350) / 100, mod.ProjectileType("GearGrinderProj"), projectile.damage, projectile.knockBack, projectile.owner);
		}
    }
	}
}