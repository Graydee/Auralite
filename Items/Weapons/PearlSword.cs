using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class PearlSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl blade";
			item.damage = 12;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Launches a pearl";
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 80000;
			item.rare = 8;
			item.useSound = 1;
			item.shoot = mod.ProjectileType("Pearl");
			item.shootSpeed = 5f;
			item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the projectiles
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / Main.rand.Next(23,28));

			//create projectiles
			Projectile.NewProjectile(position.X, position.Y, speedX + ((float) Main.rand.Next(-100, 200) / 100), speedY + ((float) Main.rand.Next(-300, 300) / 100), mod.ProjectileType("Pearl"), damage - 2, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y, newVect.X + ((float) Main.rand.Next(-100, 200) / 100), newVect.Y + ((float) Main.rand.Next(-300, 300) / 100), mod.ProjectileType("Pearl"), damage - 2, knockBack, player.whoAmI, 0, 0);
			return false;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			 recipe.AddIngredient(null, "Pearl", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}