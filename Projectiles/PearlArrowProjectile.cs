using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class PearlArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.name = "PearlArrowProjectile";
            projectile.width = 10;
            projectile.height = 28;
            projectile.penetrate = 2;
            
        }

        public override void Kill(int timeLeft)  //Main.rand.Next(-350, 350)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), mod.ProjectileType("PearlArrowProjectile2"), projectile.damage / 4, projectile.knockBack, Main.myPlayer);

            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), mod.ProjectileType("PearlArrowProjectile2"), projectile.damage / 4, projectile.knockBack, Main.myPlayer);
        }
    }
}