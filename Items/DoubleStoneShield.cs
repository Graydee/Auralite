using System;
//using System.Collections.Generic;
//using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class DoubleStoneShield:ModItem
	{
		public override void SetDefaults()
		{
			item.name="Double-Edged Sheild";
			item.toolTip="+8% crit chance";
			item.width=15;
			item.height=15;
			item.accessory=true;
			item.defense=4;
			item.value=Item.sellPrice(0,0,0,0);
			item.rare=1;
		}

		public override void UpdateAccessory(Player player,bool hideVisual)
		{
			 player.meleeCrit+=8;
			 player.rangedCrit+=8;
			 player.magicCrit+=8;
			 player.thrownCrit+=8;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe=new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient("GraniteShard",5);
			recipe.AddIngredient("MarbleShard",5);
			recipe.AddRecipe();
		}
	}
}
