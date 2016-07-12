using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class DesertDagger : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Desert dagger";
            item.useStyle = 1;
            item.width = 9;
            item.height = 15;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("DesertDagger");
            item.useAnimation = 16;
            item.useTime = 16;
            item.shootSpeed = 9.5f;
            item.damage = 11;
            item.knockBack = 3.5f;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.crit = 20;
            item.rare = 4;
            item.autoReuse = true;
            //item.maxStack = 999;
            //item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(323, 1);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}