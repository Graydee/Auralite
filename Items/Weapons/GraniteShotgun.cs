using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class GraniteShotgun : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite shotgun";
			item.damage = 21;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Rain lead on the enemy";
			item.useTime = 58;
			item.useAnimation = 58;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = 100000;
            item.rare = 7;
            item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = ProjectileID.Bullet;
		}
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int I = 0; I < 3; I++)
			{
			Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float) Main.rand.Next(-300, 300) / 100), speedY + ((float) Main.rand.Next(-300, 300) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}