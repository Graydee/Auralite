using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class GraniteShard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite Shard";
			item.width = 20;
			item.height = 30;
			item.maxStack = 999;
			AddTooltip("Used to craft granite stuff");
			item.value = 100;
			item.rare = 3;
		}

		
	}
}