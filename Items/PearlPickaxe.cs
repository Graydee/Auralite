using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items
{
	public class PearlPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Pearl Pickaxe";
			item.damage = 10;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 45;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 20000;
			item.rare = 4;
			item.useSound = 1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Pearl", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}