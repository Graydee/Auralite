using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class Pearl : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl";
			item.width = 40;
			item.height = 40;
			item.toolTip = "Shiny and sphereical";
			item.value = 10000;
			item.rare = 2;
			item.useSound = 1;
			item.autoReuse = true;
		}
	}
}
