using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
	public class ManaStarProjectile : ModProjectile
	{
        public float lastNPCHittime = 0;
		public override void SetDefaults()
		{
			projectile.name = "Nebula Shard";
			projectile.width = 14;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.magic = true;
            projectile.light = 0.75f;
            projectile.penetrate = 5;
		}

        public override void AI()
        {
            float rotationSpeed = (float)Math.PI / 15;
            projectile.rotation += rotationSpeed;
            //Only do thing on the controller's client perspective
            if (Main.myPlayer == projectile.owner)
            {
                //Do net updatey thing. Syncs this projectile.
                projectile.netUpdate = true;

                float maxVelocity = 5; //maximum velocity projectile can approach cursor
                                       //only do this stuff if player is actively channeling
                if (Main.player[projectile.owner].channel)
                {
                    maxVelocity = maxVelocity - lastNPCHittime;
                        Main.player[projectile.owner].itemTime = 2;
                        Main.player[projectile.owner].itemAnimation = 2;

                        //move towards cursor
                        projectile.velocity = projectile.DirectionTo(Main.MouseWorld) * maxVelocity;
                        float distToMouse = projectile.Distance(Main.MouseWorld);

                        //slows down projectile when getting close to cursor
                        if (distToMouse <= maxVelocity * 3)
                        {
                            projectile.velocity *= distToMouse / (distToMouse + maxVelocity / 2);
                        }
                    if (lastNPCHittime > 0)
                    {
                        lastNPCHittime -= 0.1f;
                    }
                }
                else
                {
                    projectile.Kill(); //kill projectile if no longer channeling
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            lastNPCHittime = 5f;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 20; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("LightDust"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}