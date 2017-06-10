using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite.NPCs;
using Auralite.WorldContent;

namespace Auralite.Items
{
	public class HiringContract : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Hiring Contract";
			item.maxStack = 999;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Use this on an NPC to hire them!";
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 7;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			AuralitePlayer modPlayer = player.GetModPlayer<AuralitePlayer>(mod);

			//Loop through all NPCs, checking if one is under the cursor
			foreach(NPC npc in Main.npc) {
				if(npc.townNPC && npc.Hitbox.Intersects(new Rectangle((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 1, 1))
					&& modPlayer.partySize < MercData.maxPartySize) {
					return true;
				}
			}
			return false;
		}

		public override bool UseItem(Player player)
		{
			AuralitePlayer modPlayer = player.GetModPlayer<AuralitePlayer>(mod);
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			//Loop through all NPCs, checking if one is under the cursor
			foreach(NPC npc in Main.npc) {
				if(npc.townNPC && npc.Hitbox.Intersects(new Rectangle((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 1, 1)) && modPlayer.partySize < MercData.maxPartySize) {
					if(!mercData.Hired(npc)) {
						mercData.Hire(npc, player.whoAmI);
						((Auralite)mod).DisplayCustomMessage(npc, Auralite.Hire);
					} else if(player.whoAmI != mercData.GetOwner(npc.type, npc.displayName)) {
						((Auralite)mod).DisplayCustomMessage(npc, Auralite.AltFail);
						item.stack++; //Stops item from being consumed
					} else {
						((Auralite)mod).DisplayCustomMessage(npc, Auralite.Fail);
						item.stack++; //Stops item from being consumed
					}
					break;
				}
			}
			return true;
		}
	}
}