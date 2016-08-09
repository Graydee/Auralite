using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class PearlPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl Pickaxe";
			item.damage = 8;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "It's shiny";
			item.useTime = 17;
			item.useAnimation = 17;
			item.pick = 55;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Pearl", 14);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		
	}
}