using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class VolcanicBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Volcanic blade";
			item.damage = 45;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Hitting enemies shoots out sparks";
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Spark"), 4);
		}
	}
}