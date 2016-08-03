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
				// Shinies pass removed by some other mod.
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
                                                                                                                                                                     /*		for (int A = Xvalue; A < XvalueHigh; A++)
                                                                                                                                                                             {
                                                                                                                                                                                 for (int B = Yvalue; B < YvalueHigh; B++)
                                                                                                                                                                                 {
                                                                                                                                                                                     if (Main.tile[A,B] != null)
                                                                                                                                                                                     {
                                                                                                                                                                                         if (Main.tile[A,B].type ==  mod.TileType("CrystalBlock")) // A = x, B = y.
                                                                                                                                                                                         { 
                                                                                                                                                                                             WorldGen.KillWall(A, B);
                                                                                                                                                                                             WorldGen.PlaceWall(A, B, mod.WallType("CrystalWall"));
                                                                                                                                                                                         }
                                                                                                                                                                                     }
                                                                                                                                                                                 }
                                                                                                                                                                             }*/

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
                        WorldGen.PlaceObject(Xvalue + WorldGen.genRand.Next(370, 430), Yvalue + WorldGen.genRand.Next(340, 430), (ushort)mod.TileType("CrystalChest"), false, 2);
                    }
					}
					}
                    /*      for (int C = 0; C < 200; C++)
					{
						WorldGen.PlaceChest(Xvalue + WorldGen.genRand.Next(370, 430), Yvalue + WorldGen.genRand.Next(340, 430), (ushort)mod.TileType("CrystalChest"), false, 2);
					}
					for (int C = 0; C < 40; C++)
					{
						int E = Xvalue + WorldGen.genRand.Next(340, 460);
						int F = Yvalue + WorldGen.genRand.Next(340, 460);
						WorldGen.PlaceTile(E, F, mod.TileType("GlowingCrystal2"));
					}
					for (int C = 0; C < 35; C++)
					{
						int E = Xvalue + WorldGen.genRand.Next(340, 460);
						int F = Yvalue + WorldGen.genRand.Next(340, 460);
						if (Main.tile[E,F] != null)
						{
							WorldGen.PlaceTile(E, F, mod.TileType("GlowingCrystal"));
						}
					}
                    for (int Ore = 0; Ore < 650; Ore++)
                    {
                        int Xore = XvalueMid + Main.rand.Next(-300, 300);
                        int Yore = YvalueMid + Main.rand.Next(-300, 300);
                        if (Main.tile[Xore, Yore].type == mod.TileType("CrystalBlock")) // A = x, B = y.
                        {
                            WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), mod.TileType("RadiantOre"), false, 0f, 0f, false, true);
                        }
                    }
                    for (int X1 = -4; X1 < 10; X1++)
					{
						for (int Y1 = 0; Y1 < 7; Y1++)
						{
							WorldGen.KillTile (XvalueMid + X1,YvalueMid - Y1);
							WorldGen.PlaceTile (XvalueMid + X1,YvalueMid, mod.TileType("FountainBlock"));
						}
					}
					for (int X1 = -2; X1 < 8; X1++)
					{
							WorldGen.PlaceTile (XvalueMid + X1,YvalueMid + 1, mod.TileType("CrystalBlock"));
					}
					for (int X1 = -1; X1 < 7; X1++)
					{
							WorldGen.PlaceTile (XvalueMid + X1,YvalueMid + 2, mod.TileType("CrystalBlock"));
					}
					WorldGen.PlaceObject(XvalueMid, YvalueMid - 1, mod.TileType("Fountain"));
					WorldGen.PlaceObject(XvalueMid, YvalueMid - 6, mod.TileType("Fountain"));
					WorldGen.PlaceObject(XvalueMid + 1, YvalueMid - 6, mod.TileType("Fountain"));
					WorldGen.PlaceObject(XvalueMid - 1, YvalueMid - 1, 93, false, 5);
					WorldGen.PlaceObject(XvalueMid - 4, YvalueMid - 1, mod.TileType("Crystal"));
					WorldGen.PlaceObject(XvalueMid + 7, YvalueMid - 1, mod.TileType("Crystal"));
					WorldGen.PlaceObject(XvalueMid + 6, YvalueMid - 1, 93, false, 5);
					*/
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
