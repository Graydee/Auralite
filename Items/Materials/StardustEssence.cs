using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Materials
{
	public class StardustEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stardust Essence";
			item.width = 20;
			item.height = 30;
			item.maxStack = 999;
			AddTooltip("'The essense of Mind'");
			item.value = 100;
			item.rare = 3;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

		
	}
}