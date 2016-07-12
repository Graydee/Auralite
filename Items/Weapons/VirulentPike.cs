using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
    public class VirulentPike : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Virulent Pike";
            item.damage = 9;
            item.toolTip = "Spreads an ancient plague that wreaks havoc on large groups.";
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 4f;
            item.useSound = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("VirulentPikeProj");  //put your Spear projectile name
            item.shootSpeed = 5f;
        }
    }
}