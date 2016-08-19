using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System;

namespace Auralite.WorldContent
{
	public class FlowerForest : ModWorld
	{
		private int WillGenn = 0;
		public static int FlowerTiles = 0;
        public int Num;
		private int Meme;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)           
        {
            Random rand = new Random();
			int XTILE = WorldGen.genRand.Next(50, Main.maxTilesX - 300);
            int xAxis = XTILE;
			int xAxisMid = xAxis + 40;
			int xAxisEdge = xAxis + 160;
            int yAxis = 0;

            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            tasks.Insert(genIndex + 1, new PassLegacy("Growing flower forest", delegate (GenerationProgress progress)
               
            {

                for (int y = 0; y < Main.maxTilesY / 2; y++)
                {
                    yAxis++;
                    xAxis = XTILE;

                for (int i = 0; i < 300; i++)
                {
                    xAxis++;


                        if (Main.tile[xAxis, yAxis] != null)
                        {
                            if (Main.tile[xAxis, yAxis].active())
                            {
                                int[] TileArray = { 0, 1, 53, 112, 234, 116, 59, 147, 40};
                                for (int BiomeDirtReplace = 0; BiomeDirtReplace < 7; BiomeDirtReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray[BiomeDirtReplace])
                                    {

                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
												WillGenn = 0;
											if (xAxis < xAxisMid - 1)
											{
												Meme = xAxisMid - xAxis;
												WillGenn = Main.rand.Next(Meme);
											}
											if (xAxis > xAxisEdge + 1)
											{
												Meme = xAxis - xAxisEdge;
												WillGenn = Main.rand.Next(Meme);
											}
											if (WillGenn < 10)
											{
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("FlowerGrass");
											}
                                            }
                                        }
                                        else
                                        {
											WillGenn = 0;
											if (xAxis < xAxisMid - 1)
											{
												Meme = xAxisMid - xAxis;
												WillGenn = Main.rand.Next(Meme);
											}
											if (xAxis > xAxisEdge + 1)
											{
												Meme = xAxis - xAxisEdge;
												WillGenn = Main.rand.Next(Meme);
											}
											if (WillGenn < 10)
											{
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("FlowerGrass");
											}
                                        }

                                        
                                    }
                                }

                                int[] TileArray1 = { 2, 1, 23, 60, 199 };
                                for (int BiomeGrassReplace = 0; BiomeGrassReplace < 3; BiomeGrassReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray1[BiomeGrassReplace])
                                    {
                                        if (Main.tile[xAxis, yAxis + 1] == null)
                                        {
                                            if (rand.Next(0, 50) == 1)
                                            {
												WillGenn = 0;
											if (xAxis < xAxisMid - 1)
											{
												
												Meme = xAxisMid - xAxis;
												WillGenn = Main.rand.Next(Meme);
											}
											if (xAxis > xAxisEdge + 1)
											{
												Meme = xAxis - xAxisEdge;
												WillGenn = Main.rand.Next(Meme);
											}
											if (WillGenn < 12)
											{
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("FlowerGrass");
											}
                                            }
                                        }
                                        else
                                        {
											WillGenn = 0;
											if (xAxis < xAxisMid - 1)
											{
												Meme = xAxisMid - xAxis;
												WillGenn = Main.rand.Next(Meme);
											}
											if (xAxis > xAxisEdge + 1)
											{
												Meme = xAxis - xAxisEdge;
												WillGenn = Main.rand.Next(Meme);
											}
											if (WillGenn < 12)
											{
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("FlowerGrass");
											}
                                        }
                                    }

                                }

                                if (Main.tile[xAxis, yAxis].type == (ushort)mod.TileType("WaterGrassTile"));
                                        
                            }

                        }


                    }

                }

            }));

        }
        public override void PostWorldGen()
        {
        }
        public override void TileCountsAvailable(int[] tileCounts)
		{
			FlowerTiles = tileCounts[mod.TileType("FlowerGrass")];
		}
	}
}
