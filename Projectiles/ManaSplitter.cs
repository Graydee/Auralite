using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
	public class ManaSplitter : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Mana Bolt"; //Name of the projectile, only shows this if you get killed by it
            projectile.timeLeft = 60; //The amount of time the projectile is alive for
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.light = 0.75f;
            projectile.alpha = 255;

        }

        public override bool PreAI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 227, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 227, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;

            return true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 4.94974746831f, 4.94974746831f, mod.ProjectileType("ManaShard"), projectile.damage, 0f, projectile.owner, 0f, 0f); //45
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -4.94974746831f, 4.94974746831f, mod.ProjectileType("ManaShard"), projectile.damage, 0f, projectile.owner, 0f, 0f); //135
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 4.94974746831f, -4.94974746831f, mod.ProjectileType("ManaShard"), projectile.damage, 0f, projectile.owner, 0f, 0f);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -4.94974746831f, -4.94974746831f, mod.ProjectileType("ManaShard"), projectile.damage, 0f, projectile.owner, 0f, 0f);
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