using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Auralite.WorldContent
{
	public class TwilightIsles : ModWorld
	{
		public static int TwilightTiles = 0;
        public int Num;
		public static bool TwilightBiome = false;

		 public override void Initialize()
        {
            if (NPC.downedMechBoss1 == true)
            {
                TwilightBiome = true;
            }
            else
            {
                TwilightBiome = false;
            }
        }
	public override void PostUpdate() 
	{
            if (NPC.downedMechBoss1 == true)
            {
			if (TwilightBiome == false)
			{
			TwilightBiome = true;
			Main.NewText("The once fantastic elements hang over your skies", Color.Orange.R, Color.Orange.G, Color.Orange.B);
			int XTILE = WorldGen.genRand.Next(125, Main.maxTilesX - 600);
            int yAxis = Main.maxTilesY / 7;
			for (int xAxis = XTILE; xAxis < XTILE + 250; xAxis++)
			{
				DimLib.TileRunner(xAxis, yAxis, (double)WorldGen.genRand.Next(30,30), 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
			}
			// biome gen itself

		}
			}
	}
        public override void PostWorldGen()
        {
        }
        public override void TileCountsAvailable(int[] tileCounts)
		{
			TwilightTiles = tileCounts[mod.TileType("TwilightGrass")];
		}
	}
}
