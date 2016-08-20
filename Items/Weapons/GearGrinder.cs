using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
    public class GearGrinder : ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Gear grinder";
			item.damage = 43;
            item.value = 30000;
            item.rare = 3;
            item.toolTip = "Shoots out cogs";
			item.knockBack = 0;
			item.channel = true;
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("GearGrinder");
           
        }
	}
}