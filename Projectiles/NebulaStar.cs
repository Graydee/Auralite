using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class NebulaStar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "NebulaStar";
            projectile.width = 54;
            projectile.height = 54;
			projectile.damage = 3;// Main.rand.Next(1);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.ownerHitCheck = false;
            projectile.melee = true;
            projectile.timeLeft = 500;
            projectile.hide = false;	
            projectile.whoAmI = Main.myPlayer;
        
        }
		 public override void AI()
		{
            float rotationSpeed = (float)Math.PI / 15;
            projectile.rotation += rotationSpeed;
		}
    }
}