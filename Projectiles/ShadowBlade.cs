using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Projectiles
{
	public class ShadowBlade : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Shadow Blade";
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 250;
			projectile.height = 62;
			projectile.width = 26;

        }

		public override void AI()
		{
            projectile.rotation += 0.2f;
		}
    }
}