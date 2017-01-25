using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
    public class Oyster : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Oyster";
            npc.displayName = "Oyster";
            npc.width = 42;
            npc.height = 36;
            npc.damage = 0;
            npc.defense = 0;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.lifeMax = 20;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 300f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 0;
            aiType = 0;
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
        }
        
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pearl"));
            }
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return spawnInfo.water && (x < 250 || x > Main.maxTilesX - 250) ? 10f : 0f;
        }
        public override void AI()
        {
            npc.ai[0]++;
            if (npc.ai[0] % 8 == 0)
            {
                npc.frame.Y = (int)(npc.height * npc.frameCounter);
                npc.frameCounter = (npc.frameCounter + 1) % 7;
            }
        }
    }
}
