using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons.Swung
{
	public class MysticBlade: ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Mystic blade";
			item.damage = 29;
			item.melee = true;
            item.magic = true;
            item.mana = 10;
            item.width = 40;
			item.height = 40;
			item.toolTip = "Consumes magic energy";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = 80000;
            item.rare = 8;
            item.useSound = 1;
			item.shoot = mod.ProjectileType("MysticBolt");
			item.shootSpeed = 9f;
			item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("MythicBladeProj"), damage, knockBack, item.owner, 0, 0);
			return false;
		}
	}
}
