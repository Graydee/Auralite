using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
    public class MysticStaff : ModItem
    {
		float DistYT = 0f;
        float DistXT = 0f;
        float DistY = 0f;
        float DistX = 0f;
        public override void SetDefaults()
        {
            item.name = "Mystic Staff";
            item.damage = 20; //The damage
            item.magic = true; //Whether or not it is a magic weapon
            item.width = 56; //Item width
            item.height = 56; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.toolTip = "Launches a mana star"; //The item’s tooltip
            item.useTime = 6; //How long it takes for the item to be used
            item.useAnimation = 6; //How long the animation of the item takes
            Item.staff[item.type] = true;
            item.knockBack = 0f; //How much knockback the item produces
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 120000; //How much the item is worth
            item.rare = 8; //The rarity of the item
            item.shoot = mod.ProjectileType("ManaStarProjectile");
            item.shootSpeed = 6f; //How fast the projectile fires 
            item.channel = true;  
            item.mana = 5;
            item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
        }

    }
}