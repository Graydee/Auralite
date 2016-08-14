using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Placeable
{
	public class VortexRock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Vortex rock";
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("VortexRock");
		}
	}
}