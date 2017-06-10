using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace Auralite.Items
{
	public class MarbleBoots : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pegasus boots";
			item.toolTip = "Increases movespeed, but decreases defense.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.moveSpeed += 0.25f;
			 player.statDefense -= 8;
		}
	}
}
