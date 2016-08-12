using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class PutridSpike : ModProjectile
    {
		private int DontLookInTheCode = 0;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.name = "Putrid Spike";
            projectile.width = 10;
            projectile.height = 28;
            projectile.penetrate = 2;  
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