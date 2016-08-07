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
			mercData.CleanData();
			return base.PreNPCLoot(npc);
		}

		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			//Increase NPC damage by 20% while hired
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(mercData.Hired(npc.type, npc.displayName)) {
				damage = (int)(damage * 2.0);
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

				npc.aiStyle = 0;

				//Prevent talking with this NPC while hired
				if(Main.player[Main.myPlayer].talkNPC == npc.whoAmI) {
					Main.player[Main.myPlayer].talkNPC = -1; //Stop talking to NPC
					((Auralite)mod).DisplayCustomMessage(npc, Auralite.NoShop);
				}
			} else if(npc.townNPC) {
				npc.aiStyle = 7;
			}
			return true;
		}

		public override void AI(NPC npc)
		{
			//This applies town NPC buffs, even though the NPC no longer has aiStyle 7
			float damageMult = 1;
			NPCLoader.BuffTownNPC(ref damageMult, ref npc.defense);
			
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(npc.townNPC && mercData.Hired(npc.type, npc.displayName)) {
				//Restore velocity, preventing any changes from original AI
				Player player = Main.player[Main.myPlayer];
				npc.velocity.X = npc.ai[2];
				//npc.velocity.Y = npc.ai[3];
				if (npc.Center.X >= player.Center.X && npc.velocity.X >= -4 && Main.rand.Next(2) == 1) // flies to players x position
				{
					npc.velocity.X = npc.velocity.X - 0.2f;
				}
				if (npc.Center.X >= player.Center.X && npc.velocity.X >= -4 && npc.velocity.X <= -2 && Main.rand.Next(2) == 1) // flies to players x position
				{
					npc.velocity.X = npc.velocity.X - 0.2f;
				}
				if (npc.velocity.X >= 0)	
				{
					npc.spriteDirection = 1;
				}
				if (npc.velocity.X < 0)	
				{
					npc.spriteDirection = -1;
				}
				if (npc.Center.X <= player.Center.X && npc.velocity.X <= 4 && Main.rand.Next(2) == 1)
				{
					npc.velocity.X = npc.velocity.X + 0.2f;
				}
				if (npc.Center.X <= player.Center.X && npc.velocity.X <= 4 && npc.velocity.X >= 2 && Main.rand.Next(2) == 1)
				{
					npc.velocity.X = npc.velocity.X + 0.2f;
				}					
			}
		}
    }
}