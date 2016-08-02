using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Auralite.Items.Arrow
{
    public class PearlArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodenArrow);
            item.name = "Pearl Arrow";
            item.damage = 5;
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.toolTip = "These Arrow dont gets Consumed on use";
            item.rare = 1;
            item.consumable = true;
            item.shoot = mod.ProjectileType("PearlArrowProjectile");
            item.ammo = ProjectileID.WoodenArrowFriendly;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Pearl", 1);
            recipe.AddIngredient(ItemID.WoodenArrow, 10);
            recipe.SetResult("PearlArrow", 10);
            recipe.AddRecipe();
        }
    }
}