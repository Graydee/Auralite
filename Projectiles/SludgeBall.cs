using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Auralite.Projectiles
{
	public class SludgeBall : ModProjectile
	{
		private int DontLookInTheCode = 0;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodYoyo);
			projectile.name = "Sludge ball";
			projectile.penetrate = 2;
			projectile.timeLeft = 500;
		}
		public override void AI()
	{
		DontLookInTheCode++;
		if (DontLookInTheCode % 20 == 0)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("ToxicShroom"), projectile.damage, projectile.knockBack, projectile.owner);
		}
    }
	}
}