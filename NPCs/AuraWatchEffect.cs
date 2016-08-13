using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;

namespace Auralite.NPCs
{
    public class AuraWatchEffect : GlobalNPC
    {
        public override bool PreAI(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            AuralitePlayer modPlayer = player.GetModPlayer<AuralitePlayer>(mod);
            if (modPlayer.auraWatch)
            {
                if (player.HasBuff(mod.BuffType("StolenTime")) >= 0)
                    {
                    if (!npc.boss)
                    {
                        npc.velocity *= 0;
                        return false;
                    }
                }
            }
                return base.PreAI(npc);
            }
        }
    
}