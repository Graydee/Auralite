using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
	public class ManaShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Grenade);
            projectile.penetrate = 1;
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 255;
            aiType = ProjectileID.Grenade;
            projectile.light = 0.5f;

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
        public override bool PreAI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 227, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;

            return true;
        }

        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
        //    for (int k = 0; k < projectile.oldPos.Length; k++)
        //    {
        //        Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
        //        Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
        //        spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
        //    }
        //    return true;
        //}
    }
}