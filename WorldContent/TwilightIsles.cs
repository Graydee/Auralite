using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
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
			Main.NewText("The fantastic elements loom over you", Color.Orange.R, Color.Orange.G, Color.Orange.B);
			int XTILE = WorldGen.genRand.Next(125, Main.maxTilesX - 2500);
            int yAxis = Main.maxTilesY / 10;
			for (int xAxis = XTILE; xAxis < XTILE + 250; xAxis++)
			{
				int Slope2 = Math.Abs(Main.rand.Next(120,130) - Math.Abs((xAxis - XTILE) - Main.rand.Next(120,130))) / 3;
				string SlopeText = Slope2.ToString();
				//Main.NewText(SlopeText, Color.Orange.R, Color.Orange.G, Color.Orange.B);
				for (int I = 0; I < Slope2; I++)
				{
					DimLib.TileRunner(xAxis, yAxis + I, (double)WorldGen.genRand.Next(30,30), 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				}
				DimLib.TileRunner(xAxis, yAxis, (double)WorldGen.genRand.Next(30,30), 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				if (Main.rand.Next(30) == 0)
				{
                            WorldMethods.RoundHill(xAxis, yAxis, 26, 12, 16, true, (ushort)mod.TileType("TwilightGrass"));

                }
                        if (Main.rand.Next(55) == 0)
                        {
                            WorldMethods.RoundHill(xAxis, yAxis - 7, 22, 14, 15, true, (ushort)mod.TileType("TwilightGrass"));

                        }
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
