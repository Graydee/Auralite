using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite.NPCs;

namespace Auralite.Items
{
	public class HiringContract : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Hiring Contract";
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
					&& modPlayer.partySize < modPlayer.maxPartySize) {
					return true;
				}
			}
			return false;
		}

		public override bool UseItem(Player player)
		{
			//Loop through all NPCs, checking if one is under the cursor
			foreach(NPC npc in Main.npc) {
				AuraNPCInfo info = npc.GetModInfo<AuraNPCInfo>(mod);
				if(npc.townNPC && npc.Hitbox.Intersects(new Rectangle((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 1, 1))) {
					if(!info.hired) {
						info.hired = true;  //Hire this NPC

						//Display successful hiring message
						string[] messages = { "At your service!", "Let's go!" };
						Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 0, 255, 0);
					} else {
						//Display failed hiring message in red
						string[] messages = { "What's the big idea?", "I'm already under contract." };
						Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 255, 0, 0);
						return false; //Don't consume the item, hopefully?
					}
				}
			}
			return true;
		}
	}
}
