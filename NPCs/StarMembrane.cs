using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
	public class StarMembrane : ModNPC
	{
        public override void SetDefaults()
		{
			npc.name = "Star Membrane";
			npc.displayName = "Star Membrane";
			npc.damage = 120;
			npc.defense = 5;
            npc.width = npc.height = 90;
			npc.lifeMax = 3000;
            npc.soundHit = 5;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.soundKilled = 6;
            npc.value = 200f;
			npc.knockBackResist = 0f;
		}

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AuralitePlayer>(mod).ZoneStardust ? 35000f : 0f;
        }
		
		  public override bool PreAI()
		  {
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();
            direction.Normalize();
            npc.velocity *= 0.98f;
            int dust2 = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[dust2].noGravity = true;
            if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) >= 7f)
                {
                int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
                dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
            }
            if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 2f)
            {
                if (Main.rand.Next(25) == 1)
                {
                    direction.X = direction.X * Main.rand.Next(20,24);
                    direction.Y = direction.Y * Main.rand.Next(20,24);
                    npc.velocity.X = direction.X;
                    npc.velocity.Y = direction.Y;
                }
            }
            return false;

        } 
	}
}
