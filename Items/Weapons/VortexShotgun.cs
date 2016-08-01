using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Auralite.Items.Weapons
{
    public class VortexShotgun : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Vortex lightning blaster";
            item.damage = 61; //The damage
            item.ranged = true; //Whether or not it is a magic weapon
            item.width = 54; //Item width
            item.height = 54; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.toolTip = "'Weild the thunder of a galaxy'"; //The item’s tooltip
            item.useTime = 18; //How long it takes for the item to be used
            item.useAnimation = 18; //How long the animation of the item takes
            item.knockBack = 7f; //How much knockback the item produces
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 120000; //How much the item is worth
			item.shoot = 10;
            item.rare = 8; //The rarity of the item
            item.shoot = 580; //What the item shoots, retains an int value | *
            item.shootSpeed = 7f; //How fast the projectile fires   
            item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 18);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		  public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
            Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
            float ai = Main.rand.Next(100);
            Vector2 vector83 = Vector2.Normalize(vector82) * item.shootSpeed;
            Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, .5f, player.whoAmI, vector82.ToRotation(), ai);
            return false;
        }
    }
}