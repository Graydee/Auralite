using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class MysticSword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Mystic sword";
			item.damage = 16;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "'A dark aura surrounds it'";
			item.useTime = 15;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = 80000;
            item.rare = 8;
            item.useSound = 1;
			item.shoot = mod.ProjectileType("MysticBolt");
			item.shootSpeed = 6f;
			item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("MysticBolt"), damage, knockBack, item.owner, 0, 0);
			return false;
		}
	}
}
