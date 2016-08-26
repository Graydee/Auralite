using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class MagmaticBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magmatic bow";
			item.damage = 47;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = 30000;
            item.rare = 3;
            item.useSound = 5;
			item.autoReuse = false;
			item.shoot = 3; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 10f;
			item.useAmmo = 1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-50, 50) / 100), speedY + ((float) Main.rand.Next(-50, 50) / 100), mod.ProjectileType("FireParticle"), damage / 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-50, 50) / 100), speedY + ((float) Main.rand.Next(-50, 50) / 100), mod.ProjectileType("FireParticle"), damage / 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-50, 50) / 100), speedY + ((float) Main.rand.Next(-50, 50) / 100), mod.ProjectileType("FireParticle"), damage / 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-50, 50) / 100), speedY + ((float) Main.rand.Next(-50, 50) / 100), mod.ProjectileType("FireParticle"), damage / 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-50, 50) / 100), speedY + ((float) Main.rand.Next(-50, 50) / 100), mod.ProjectileType("FireParticle"), damage / 2, knockBack, player.whoAmI, 0f, 0f);
			return true;
		}
	}
}