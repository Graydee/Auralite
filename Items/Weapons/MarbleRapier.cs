using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class MarbleRapier:ModItem
	{
		public override void SetDefaults()
		{
			item.name="Marble Rapier";
			item.toolTip="Has a 33% chance to reflecting projectiles with 50% damage";
			item.melee=true;
			item.noMelee=true;
			item.noUseGraphic=true;
			item.useTurn=true;
			item.width=40;
			item.height=40;
			item.scale=1.1f;
			item.maxStack=1;
			item.useTime=15;
			item.useAnimation=30;
			item.useStyle=5;
			item.knockBack=6;
			item.value=Item.sellPrice(0,0,0,0);
			item.rare=1;
			item.useSound=1;
			item.shoot=mod.ProjectileType("MarbleRapier");
			item.shootSpeed=6f;
			item.autoReuse=false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe=new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient("MarbleShard",10);
			recipe.AddRecipe();
		}
	}
}
