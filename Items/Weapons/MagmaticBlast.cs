using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
    public class MagmaticBlast : ModItem
    {
        public override void SetDefaults()
        {
            item.knockBack = 6.5f;
            item.useStyle = 5;
            item.useAnimation = 20;
            item.useTime = 4;
            item.name = "Magmatic Blast";
            item.width = 50;
            item.height = 14;
            item.shoot = mod.ProjectileType("FireParticle");
            item.damage = 33;
            item.shootSpeed = 5f;
            item.noMelee = true;
            item.value = 250000;
            item.rare = 9;
            item.magic = true;
            item.autoReuse = false;
            item.toolTip = "Fires a spread of fire";
        }
        // KAPPA
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            var angle = 25;
            var num = Main.rand.Next(1, 3);
            var speeds = randomSpread(speedX, speedY, angle, num);
            for (int i = 0; i < num; i++)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, mod.ProjectileType("FireParticle"), damage, knockBack, player.whoAmI);
            }
			Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
            return false;
        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = MathHelper.ToRadians(angle);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle;
            for (int i = 0; i < num; ++i)
            {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)Math.Sin(randomAngle), baseSpeed * (float)Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }
    }
}
