using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class FungiGel : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Fungi Gel";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Gross.");
			item.value = 100;
			item.rare = 1;
		}

		
	}
}