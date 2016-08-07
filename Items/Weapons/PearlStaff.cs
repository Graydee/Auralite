using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Auralite.Items.Weapons
{
	public class PearlStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl staff";
			item.damage = 11;
			item.summon = true;
			item.mana = 17;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Summons a magic pearl to orbit you.";
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = 1;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 7;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("OrbPearl");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//Remove all previous Cryst projectiles - creates "reset" behavior
			for(int i = 0; i < Main.projectile.Length; i++) {
				Projectile p = Main.projectile[i];
				if(p.active && p.type == item.shoot && p.owner == player.whoAmI) {
					p.active = false;
				}
			}

			//get degrees from direction vector
			int dir = (int)(new Vector2(speedX, speedY).ToRotation() / (Math.PI / 180));

			//spawn the new projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, damage, knockBack, player.whoAmI, 0, dir);
			return false;
		}
	}
}