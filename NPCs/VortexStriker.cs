using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
	public class VortexStriker : ModNPC
	{
				int moveSpeed = 0;
		int moveSpeedY = 0;
		public override void SetDefaults()
		{
			npc.name = "Vortex Striker";
			npc.displayName = "Vortex Striker";
			npc.width = 42;
			npc.height = 70;
			npc.damage = 141;
			npc.defense = 72;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.lifeMax = 5500;
            npc.soundHit = 5;
            npc.soundKilled = 6;
            npc.value = 300f;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 7;
		}
		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AuralitePlayer>(mod).ZoneVortex ? 45000f : 0f;
		}
        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 1)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexEssence"));
        }
        public override void AI()
		{
			npc.ai[0]++;
            if (npc.ai[0] % 3 == 0)
            {
                npc.frame.Y = (int)(npc.height * npc.frameCounter);
                npc.frameCounter = (npc.frameCounter + 1) % 7;
            }
			if (Main.rand.Next(150) == 0)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
            float ai = Main.rand.Next(100);
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, 580, 95, 1, Main.myPlayer, direction.ToRotation(), ai);
			}
			npc.spriteDirection = npc.direction;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
				if (npc.Center.X >= player.Center.X && moveSpeed >= -60) // flies to players x position
				{
					moveSpeed--;
				}
					
				if (npc.Center.X <= player.Center.X && moveSpeed <= 60)
				{
					moveSpeed++;
				}
				
				npc.velocity.X = moveSpeed * 0.1f;
				
				if (npc.Center.Y >= player.Center.Y - 130f && moveSpeedY >= -15) //Flies to players Y position
				{
					moveSpeedY--;
				}
					
				if (npc.Center.Y <= player.Center.Y - 130f && moveSpeedY <= 15)
				{
					moveSpeedY++;
				}
				
				npc.velocity.Y = moveSpeedY * 0.1f;
		} 
	}
}
