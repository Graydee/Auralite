using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace Auralite.Items.Weapons
{
	public class GemRune : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gem rune";
			item.damage = 11;
			item.magic = true;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.toolTip = "'Combined with 1, they dominate'";
			item.useTime = 66;
			item.useAnimation = 66;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
            item.value = 100000;
            item.rare = 8;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AmberFire");
			item.shootSpeed = 10f;
		}
    /*    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TrueRubyStaff"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 origVect = new Vector2(speedX, speedY);
            Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(20) + 8));

			//create the first two projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AmethystFire"), damage, knockBack, player.whoAmI, 0f, 1f);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("TopazFire"), damage, knockBack, player.whoAmI, 0f, 2f);

			//generate the remaining projectiles
				Vector2 randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType("EmeraldFire"), damage, knockBack, player.whoAmI, 0f, 3f);
				randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType("SapphireFire"), damage, knockBack, player.whoAmI, 0f, 4f);
				randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType("RubyFire"), damage, knockBack, player.whoAmI, 0f, 5f);
				randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType("DiamondFire"), damage, knockBack, player.whoAmI, 0f, 6f);
				randVect2 = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(20) + 8));
				Projectile.NewProjectile(position.X, position.Y, randVect2.X, randVect2.Y, mod.ProjectileType("AmberFire"), damage, knockBack, player.whoAmI, 0f, 7f);
            return false;
        }
	}
}