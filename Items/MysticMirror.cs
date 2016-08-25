using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Auralite.Items
{
	public class MysticMirror : ModItem
	{
		

		public override void SetDefaults()
		{
			item.name = "Mystic Mirror";
			item.width = 24;
			item.height = 28;
			item.toolTip = "On hurt, a shadow blade appears at your location";
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            ((AuralitePlayer)player.GetModPlayer(mod, "AuralitePlayer")).mysticMirror = true;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}