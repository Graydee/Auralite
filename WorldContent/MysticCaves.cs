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
	public class MysticCaves : ModWorld
	{
		public static int MysticTiles = 0;
        public int Num;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				return;
			}
			tasks.Insert(ShiniesIndex +  2, new PassLegacy("MysticBiomeGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Enchanting caves";
               
                for (int i = 0; i < (int)Main.maxTilesX / 250; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 300);
					int XvalueHigh = Xvalue + 240;
					int YvalueHigh = Yvalue + 160;
					int XvalueMid = Xvalue + 120;
					int YvalueMid = Yvalue + 80;
					 if (Main.tile[XvalueMid,YvalueMid] != null)
                    {
                    if (Main.tile[XvalueMid,YvalueMid].type ==  1) // A = x, B = y.
                    { 
					WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(80,80), 1, mod.TileType("MysticStone"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 20, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("MysticStone"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 40, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("MysticStone"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 60, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("MysticStone"), false, 0f, 0f, true, true);
                    WorldGen.TileRunner(XvalueMid + 80, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("MysticStone"), false, 0f, 0f, true, true);//c = x, d = y                                                                                                                                                              
                    WorldGen.digTunnel(XvalueMid, YvalueMid, WorldGen.genRand.Next(0, 360),WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(8, 11), WorldGen.genRand.Next(8, 10), false);
                    WorldGen.digTunnel(XvalueMid + 50, YvalueMid, WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(8, 11), WorldGen.genRand.Next(8, 10), false);
                    for (int C = 0; C < 200; C++)
                    {
                        int PlacementY = YvalueMid + WorldGen.genRand.Next(-30, 30);
                        int PlacementX = XvalueMid + WorldGen.genRand.Next(120);
                        if (Main.tile[PlacementX, PlacementY - 1].type == mod.TileType("MysticStone") || Main.tile[PlacementX, PlacementY - 2].type == mod.TileType("MysticStone"))
                        {
                            WorldGen.PlaceObject(PlacementX, PlacementY, 271);
                        }
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
			MysticTiles = tileCounts[mod.TileType("MysticStone")];
		}
	}
}
