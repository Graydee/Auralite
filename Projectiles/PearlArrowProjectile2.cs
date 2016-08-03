using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class PearlArrowProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            	projectile.CloneDefaults(ProjectileID.Grenade);
				aiType = ProjectileID.Grenade;
            projectile.name = "PearlArrowProjectile";
            projectile.width = 8;
            projectile.height = 8;
            projectile.penetrate = 2;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			}
			return false;
		}
    }
}