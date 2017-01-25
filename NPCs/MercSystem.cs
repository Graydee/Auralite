/*using System;
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
		public override void SetDefaults(NPC npc)
		{
			MercNPCInfo info = npc.GetModInfo<MercNPCInfo>(mod);
			info.town = npc.townNPC;
		}

		public override bool PreNPCLoot(NPC npc)
		{
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			mercData.Fire(npc);
			//mercData.CleanData();
			return base.PreNPCLoot(npc);
		}

		/*
		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			//Increase NPC damage by 20% while hired
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			if(mercData.Hired(npc.type, npc.displayName)) {
				damage = (int)(damage * 2.0);
			}
		}*/

		/*//Do stuff before the AI executes
		public override bool PreAI(NPC npc)
		{
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			MercNPCInfo info = npc.GetModInfo<MercNPCInfo>(mod);
			if(info.town) {
				if(mercData.Hired(npc.type, npc.displayName)) {
					npc.townNPC = false;
					//Save velocity
					//npc.ai[2] = npc.velocity.X;
					//npc.ai[3] = npc.velocity.Y;

					info.velX = npc.velocity.X;
					info.velY = npc.velocity.Y;

					//npc.aiStyle = 0;

					//Prevent talking with this NPC while hired
					if(Main.player[Main.myPlayer].talkNPC == npc.whoAmI) {
						Main.player[Main.myPlayer].talkNPC = -1; //Stop talking to NPC
						((Auralite)mod).DisplayCustomMessage(npc, Auralite.NoShop);
					}
				} else {
					//npc.aiStyle = 7;
					npc.townNPC = true;
				}
			}
			return true;
		}

		public override void AI(NPC npc)
		{
			//This applies town NPC buffs, even though the NPC no longer has aiStyle 7
			//float damageMult = 1;
			//NPCLoader.BuffTownNPC(ref damageMult, ref npc.defense);
			
			MercData mercData = (MercData)mod.GetModWorld("MercData");
			MercNPCInfo info = npc.GetModInfo<MercNPCInfo>(mod);
			if(info.town && mercData.Hired(npc.type, npc.displayName)) {
				npc.velocity.X = info.velX;
				npc.velocity.Y = info.velY;

				if(((Auralite)mod).aiStyle.ContainsKey(npc.type)) {
					((Auralite)mod).aiStyle[npc.type](npc);
				}
			}
		}
    }
}*/