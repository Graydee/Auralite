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
            item.name = "Mystic staff";
            item.damage = 15; //The damage
            item.magic = true; //Whether or not it is a magic weapon
            item.width = 54; //Item width
            item.height = 54; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.toolTip = "Launches stars from the edge of the screen"; //The item’s tooltip
            item.useTime = 6; //How long it takes for the item to be used
            item.useAnimation = 6; //How long the animation of the item takes
            Item.staff[item.type] = true;
            item.knockBack = 0f; //How much knockback the item produces
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 120000; //How much the item is worth
            item.rare = 8; //The rarity of the item
            item.shoot = mod.ProjectileType("ManaStarProjectile");
            item.shootSpeed = 15f; //How fast the projectile fires   
            item.mana = 5;
            item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
        Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            if (position.Y <= mouse.Y)
            {
                float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
                float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
                float Angle = (float)Math.Atan(Xdis / Ydis);
                DistXT = (float)(Math.Sin(Angle) * 700);
                DistYT = (float)(Math.Cos(Angle) * 700);
				DistX = (position.X + (0 - DistXT));
                DistY = (position.Y + (0 - DistYT));      
            }
            if (position.Y > mouse.Y)
            {
                float Xdis = position.X - mouse.X;  // change myplayer to nearest player in full version
                float Ydis = position.Y - mouse.Y; // change myplayer to nearest player in full version
                float Angle = (float)Math.Atan(Xdis / Ydis);
                DistXT = (float)(Math.Sin(Angle) * 700);
                DistYT = (float)(Math.Cos(Angle) * 700);
                DistX = (position.X + DistXT);
                DistY = (position.Y + DistYT);
            }
           // Projectile.NewProjectile(DistX, DistY, (0 - DistX) / 50, (0 - DistY) / 50, mod.ProjectileType("ManaStarProjectile"), damage, knockBack, player.whoAmI, 0f, 0f);
            //return false;
			 Projectile.NewProjectile(DistX, DistY, speedX + ((float)Main.rand.Next(-150, 150) / 100), speedY + ((float)Main.rand.Next(-150, 150) / 100), mod.ProjectileType("ManaStarProjectile"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;


        }

    }
}