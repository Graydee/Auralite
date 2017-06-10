using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;

namespace Auralite.NPCs
{
	public class SpecialDrops : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.GraniteFlyer || npc.type == NPCID.GraniteGolem)
            {
                if(Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteShard"));
                }
                if (npc.type == NPCID.Medusa || npc.type == 481)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MarbleShard"));
                    }
                }
            }
        }
    }
}