using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;
using Auralite.WorldContent;

namespace Auralite.NPCs
{
	public class MercSystem : GlobalNPC
	{
		public override bool PreNPCLoot(NPC npc)
		{
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			mercData.Fire(npc.type, npc.displayName);
			return base.PreNPCLoot(npc);
		}

		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			//Increase NPC damage by 20% while hired;
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(mercData.Hired(npc.type, npc.displayName)) {
				damage = (int)(damage * 1.2);
			}
		}

		//Do stuff before the AI executes
		public override bool PreAI(NPC npc)
		{
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(npc.townNPC && mercData.Hired(npc.type, npc.displayName)) {
				//Save velocity
				npc.ai[2] = npc.velocity.X;
				npc.ai[3] = npc.velocity.Y;

				//Prevent talking with this NPC while hired
				if(Main.player[Main.myPlayer].talkNPC == npc.whoAmI) {
					Main.player[Main.myPlayer].talkNPC = -1; //Stop talking to NPC
					((Auralite)mod).DisplayCustomMessage(npc, Auralite.NoShop);
				}
			}
			return true;
		}

		public override void AI(NPC npc)
		{
			npc.VanillaAI();

			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(npc.townNPC && mercData.Hired(npc.type, npc.displayName)) {
				//Restore velocity, preventing any changes from original AI
				npc.velocity.X = npc.ai[2];
				npc.velocity.Y = npc.ai[3];
			}
		}
    }
}