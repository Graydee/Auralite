using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace Auralite.Items
{
	public class BubblyCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Bubbly Crystal";
			item.toolTip = "Increases stats slightly underwater.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.wet)
			{
			 player.moveSpeed += 0.15f;
			 player.statDefense += 1;
			 					player.magicCrit += 2;
				player.meleeCrit += 2;
				player.thrownCrit += 2;
				player.rangedCrit += 2;
				player.magicDamage += 0.09f;
			player.meleeDamage += 0.09f;
			player.rangedDamage += 0.09f;
			player.minionDamage += 0.09f;
			player.thrownDamage += 0.1f;
			player.lifeRegen += 1;
			player.jumpSpeedBoost += 0.9f;			
			}
		}
	}
}
