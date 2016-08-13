using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Auralite.Items
{
	public class AuraWatch : ModItem
	{
		

		public override void SetDefaults()
		{
			item.name = "Aura Watch";
			item.width = 24;
			item.height = 28;
			item.toolTip = "On hurt, you have a chance to freeze enemies";
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            ((AuralitePlayer)player.GetModPlayer(mod, "AuralitePlayer")).auraWatch = true;
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