using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;

namespace Auralite.NPCs
{
	public class MercSystem : GlobalNPC
	{
		public override void SetDefaults(NPC npc)
		{
			base.SetDefaults(npc);
			npc.GetModInfo<AuraNPCInfo>(mod).town = npc.townNPC;
		}

		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			//Increase NPC damage by 20% while hired
			AuraNPCInfo info = npc.GetModInfo<AuraNPCInfo>(mod);
			if(info.hired) {
				damage = (int)(damage * 1.2);
			}
		}

		//Do stuff before the AI executes
		public override bool PreAI(NPC npc)
		{
			AuraNPCInfo info = npc.GetModInfo<AuraNPCInfo>(mod);
			if(npc.townNPC && info.hired) {
				//Save velocity
				npc.ai[2] = npc.velocity.X;
				npc.ai[3] = npc.velocity.Y;

				//Prevent talking with this NPC while hired
				if(Main.player[Main.myPlayer].talkNPC == npc.type) {
					Main.player[Main.myPlayer].talkNPC = -1; //Stop talking to NPC

					//Display one of these messages in red, indicating why you can't access the NPC's shop.
					string[] messages = { "Sorry, I'm busy right now.", "Talk to me when my contract's up.",
										  "Would you prefer shopping, or monsters off your back?" };
					Main.NewText(npc.displayName+": "+messages[Main.rand.Next(0, messages.Length)], 255, 0, 0);
				}
			}
			return true;
		}

		//Do stuff after the AI executes
		public override void PostAI(NPC npc)
		{
			AuraNPCInfo info = npc.GetModInfo<AuraNPCInfo>(mod);
			if(npc.townNPC && info.hired) {
				//Restore velocity, preventing any changes from original AI
				npc.velocity.X = npc.ai[2];
				npc.velocity.Y = npc.ai[3];
			}
		}
    }
}