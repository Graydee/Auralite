using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
	public class SolarCore : ModNPC
	{
        int Counter;
        public override void SetDefaults()
		{
			npc.name = "Solar Core";
			npc.displayName = "Solar Core";
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
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AuralitePlayer>(mod).ZoneSolar ? 35000f : 0f;
        }
		
		  public override bool PreAI()
        {
            npc.noGravity = true;
            npc.noTileCollide = true;
            if (npc.type == 83)
            {
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.2f, 0.05f, 0.3f);
            }
            else if (npc.type == 179)
            {
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.3f, 0.15f, 0.05f);
            }
            else
            {
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.2f, 0.3f);
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (npc.ai[0] == 0f)
            {
                float num727 = 18f;
                Vector2 vector73 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num728 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector73.X;
                float num729 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector73.Y;
                float num730 = (float)Math.Sqrt((double)(num728 * num728 + num729 * num729));
                num730 = num727 / num730;
                num728 *= num730;
                num729 *= num730;
               
                npc.velocity.X = num728;
                npc.velocity.Y = num729;
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
                npc.ai[0] = 1f;
                npc.ai[1] = 0f;
                npc.netUpdate = true;
                return false;
            }
            if (npc.ai[0] == 1f)
            {
                int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 5, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                npc.velocity *= 0.99f;
                npc.ai[1] += 1f;
                Counter++;
                if (Counter >= 15)
                {
                    Vector2 Fireball1 = npc.velocity.RotatedBy(2.35619);
                    Fireball1.Normalize();
                    Vector2 Fireball2 = npc.velocity.RotatedBy(3.92699);
                    Fireball2.Normalize();
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Fireball2.X * 8f, Fireball2.Y * 8f, 467, 102, 1, Main.myPlayer, 0, 0);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Fireball1.X * 8f, Fireball1.Y * 8f, 467, 102, 1, Main.myPlayer, 0, 0);
                    Counter = 0;
                }
                if (npc.ai[1] >= 100f)
                {
                    npc.netUpdate = true;
                    npc.ai[0] = 2f;
                    npc.ai[1] = 0f;
                    npc.velocity.X = 0f;
                    npc.velocity.Y = 0f;
                    return false;
                }
            }
            else
            {
                npc.velocity *= 0.96f;
                npc.ai[1] += 1f;
                float num731 = npc.ai[1] / 120f;
                num731 = 0.1f + num731 * 0.4f;
                npc.rotation += num731 * (float)npc.direction;
                if (npc.ai[1] >= 90f)
                {
                    npc.netUpdate = true;
                    npc.ai[0] = 0f;
                    npc.ai[1] = 0f;
                    return false;
                }
            }
            return false;
        } 
	}
}
