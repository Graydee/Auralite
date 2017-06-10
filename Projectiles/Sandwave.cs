using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
    public class Sandwave : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Sandwave";
            projectile.width = 10;
            projectile.height = 10;
			projectile.damage = 3;// Main.rand.Next(1);
            projectile.scale = 1.1f;
            projectile.aiStyle = 24;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.ownerHitCheck = false;
            projectile.melee = true;
            projectile.timeLeft = 25;
            projectile.hide = false;	
            projectile.whoAmI = Main.myPlayer;
        
        }
    }
}