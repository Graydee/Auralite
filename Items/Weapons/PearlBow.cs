using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class PearlBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl bow";
			item.damage = 10;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = 30000;
            item.rare = 3;
            item.useSound = 5;
			item.autoReuse = false;
			item.shoot = 3; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = 1;
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