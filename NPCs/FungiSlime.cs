using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
	public class FungiSlime : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Fungus Slime";
			npc.displayName = "Fungus Slime";
			npc.damage = 24;
			npc.defense = 5;
			npc.lifeMax = 60;
            npc.soundHit = 5;
            npc.soundKilled = 6;
            npc.value = 200f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			Main.npcFrameCount[npc.type] = 2;
			aiType = 1;
			animationType = NPCID.BlueSlime;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.tile[(int)(spawnInfo.spawnTileX),(int)(spawnInfo.spawnTileY)].type == mod.TileType("SlimeMoss")/* || Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<CrystalPlayer>(mod).ZoneCrystal*/ ? 1020f : 0f;
		}

		public override void NPCLoot()
		{

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FungiGel"), Main.rand.Next(1, 5));
			
		}
		
		  public override void AI()
		  {
			  Vector3 RGB = new Vector3(0f,1.75f,0.5f);
			float multiplier = 1;
			float max = 2.25f;
			float min = 1.0f;
			RGB *= multiplier;
			if (RGB.X > max)
			{
			multiplier = 0.5f;
			}
			if (RGB.X < min)
			{
			multiplier = 1.5f;
			}
			Lighting.AddLight(npc.position,RGB.X,RGB.Y,RGB.Z);
        } 
	}
}
