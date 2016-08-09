using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Auralite.Items.Weapons
{
	public class PearlBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl Bow";
			item.damage = 11;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.toolTip = "A bow";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.useSound = 11;
			item.autoReuse = true;
            item.shoot = 1;
			item.shootSpeed = 20f;
			item.useAmmo = 40;
		}
       
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Pearl", 20);
			//recipe.AddTile(null, "");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}