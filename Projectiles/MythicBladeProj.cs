using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
	public class MythicBladeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Mythic Blade";
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 90;
			projectile.height = 62;
			projectile.width = 26;

        }

		public override void AI()
		{
            projectile.rotation += 0.2f;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                Player player = Main.player[projectile.owner];
                player.HealEffect(12);
                player.statMana += 12;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            for (int k = 0; k < 15; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 227, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}