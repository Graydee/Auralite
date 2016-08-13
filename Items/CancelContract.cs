using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite.NPCs;
using Auralite.WorldContent;

namespace Auralite.Items
{
	public class CancelContract : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
		{
			texture = "Auralite/Items/HiringContract";
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Cancelling Contract";
			item.maxStack = 999;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Use this on an NPC to remove them from your party.";
			item.toolTip2 = "You can fire other's NPCs, but that's just plain rude.";
			item.value = 0;
			item.rare = 7;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
		}

		public override bool CanUseItem(Player player)
		{
			//Loop through all NPCs, checking if one is under the cursor
			foreach(NPC npc in Main.npc) {
				if(npc.townNPC && npc.Hitbox.Intersects(new Rectangle((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 1, 1))
					&& MercData.GetMercData().Hired(npc)) {
					return true;
				}
			}
			return false;
		}

		public override bool UseItem(Player player)
		{
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			//Loop through all NPCs, checking if one is under the cursor
			foreach(NPC npc in Main.npc) {
				if(npc.townNPC && npc.Hitbox.Intersects(new Rectangle((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 1, 1))) {
					if(mercData.Hired(npc)) {
						mercData.Fire(npc);
						((Auralite)mod).DisplayCustomMessage(npc, Auralite.Fire);
					}
					break;
				}
			}
			return true;
		}
	}
}