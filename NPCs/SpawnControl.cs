using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;

namespace Auralite.NPCs
{
	public class SpawnControl : GlobalNPC
	{
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.GetModPlayer<AuralitePlayer>(mod).ZoneSlime)
			{
				spawnRate = (int)(spawnRate * 0.38f);
				maxSpawns = (int)(maxSpawns * 1.5f);
			}
			if (player.GetModPlayer<AuralitePlayer>(mod).ZoneVortex)
			{
				spawnRate = (int)(spawnRate * 0.18f);
				maxSpawns = (int)(maxSpawns * 2.5f);
			}
        }
    }
}