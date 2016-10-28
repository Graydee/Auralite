using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons.Guns
{
	public class StardustCannon : ModItem
	{
        private Vector2 newVect;
        public override void SetDefaults()
		{
			item.name = "Stardust Cannon";
			item.damage = 129;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Launches a spray of unpredictable stars, but only upwards";
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = 30000;
            item.rare = 3;
			item.autoReuse = true;
			item.shoot = 3; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 origVect = new Vector2(speedX, speedY);
                if (Main.rand.Next(2) == 1)
                {
                    newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                else
                {
                    newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, 538, damage, knockBack, player.whoAmI);
                Projectile newProj2 = Main.projectile[proj2];
            newProj2.friendly = true;
            newProj2.hostile = false;
            return false;
        }
	}
}