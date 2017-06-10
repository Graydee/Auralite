using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.Items.Weapons
{
	public class MarauderBlade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Marauder blade";
			item.damage = 13;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Launches sand particles";
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 80000;
			item.rare = 8;
			item.useSound = 1;
			item.shoot = mod.ProjectileType("SandParticle");
			item.shootSpeed = 4f;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//create velocity vectors for the projectiles
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / Main.rand.Next(18,22));
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(18,22));
			Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / Main.rand.Next(8,12));
			Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(8,12));

			//create projectiles
			Projectile.NewProjectile(position.X, position.Y - 20, speedX + ((float) Main.rand.Next(-200, 200) / 100), speedY + ((float) Main.rand.Next(-200, 200) / 100), mod.ProjectileType("SandParticle"), damage / 2, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect.X + ((float) Main.rand.Next(-200, 200) / 100), newVect.Y + ((float) Main.rand.Next(-200, 200) / 100), mod.ProjectileType("SandParticle"), damage / 2, knockBack, player.whoAmI, 0, 0);
			Projectile.NewProjectile(position.X, position.Y - 20, newVect2.X + ((float) Main.rand.Next(-200, 200) / 100), newVect2.Y + ((float) Main.rand.Next(-200, 200) / 100), mod.ProjectileType("SandParticle"), damage / 2, knockBack, player.whoAmI, 0, 0);
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int J = 1; J < 3; J++)
			{
				Vector2 vel = new Vector2(0, -1);   
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
		/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible, 8);
            recipe.AddIngredient(ItemID.Silk, 7);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
	}
}