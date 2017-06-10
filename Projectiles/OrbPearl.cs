using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class OrbPearl : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.height = 20;
			projectile.width = 20;
            projectile.name = "Magic pearl";
            projectile.penetrate = 600;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 1400;
			projectile.damage = 13;
            projectile.extraUpdates = 1;
            projectile.light = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
		public override void AI()
		{
			projectile.rotation += 0.1f;
    		//Making player variable "p" set as the projectile's owner
    		Player player = Main.player[projectile.owner];

    		//Factors for calculations
    		double deg = (double) projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
    		double rad = deg * (Math.PI / 180); //Convert degrees to radians
    		double dist = 80; //Distance away from the player
 			
    		/*Position the projectile based on where the player is, the Sin/Cos of the angle times the /
    		/distance for the desired distance away from the player minus the projectile's width   /
    		/and height divided by two so the center of the projectile is at the right place.     */
    		projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width/2;
    		projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height/2;
 			
    		//Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
    		projectile.ai[1] += 2f;
		}
	}
}