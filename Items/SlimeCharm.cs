using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace Auralite.Items
{
	public class SlimeCharm : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Slime charm";
			item.toolTip = "Increases jump height and move speed";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.moveSpeed += 0.15f;
			 player.jumpSpeedBoost += 1.20f;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SlimeMushroom", 10);
           recipe.AddTile(Terraria.ID.TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
