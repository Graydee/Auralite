using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
    public class SludgeBall : ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Sludge ball";
			item.damage = 16;
            item.value = 30000;
            item.rare = 3;
            item.toolTip = "Disgusting";
			item.knockBack = 0;
			item.channel = true;
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("SludgeBall");
           
        }
	}
}