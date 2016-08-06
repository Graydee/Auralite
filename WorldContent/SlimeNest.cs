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
	public class SlimeNest : ModWorld
	{
		public static int SlimeTiles = 0;
        public int Num;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				return;
			}
			tasks.Insert(ShiniesIndex +  3, new PassLegacy("SlimeBiomeGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Growing slime nests";
               
                for (int i = 0; i < (int)Main.maxTilesX / 250; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer - 50, Main.maxTilesY - 500);
					int XvalueHigh = Xvalue + 240;
					int YvalueHigh = Yvalue + 160;
					int XvalueMid = Xvalue + 240;
					int YvalueMid = Yvalue + 160;
					 if (Main.tile[XvalueMid,YvalueMid] != null)
                    {
                    if (Main.tile[XvalueMid,YvalueMid].type ==  1) // A = x, B = y.
                    { 
					
					WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(120,120), 1, mod.TileType("SlimeMoss"), false, 0f, 0f, true, true); 

                    WorldGen.digTunnel(XvalueMid, YvalueMid, WorldGen.genRand.Next(0, 360),WorldGen.genRand.Next(0, 360), 14, 14, false);
					}
					}
				}
			}));
				int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Pots"));
			if (LivingTreesIndex != -1)
			{
				tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress)
				{
					progress.Message = "spoilering spoilers";
					MakeWells();
			}));
			}
			
	}
		private void MakeWells()
		{
			float widthScale = (Main.maxTilesX / 4200f);
			int numberToGenerate = (WorldGen.genRand.Next(1, (int)(2f * widthScale))) * 5;
			for (int k = 0; k < numberToGenerate; k++)
			{
				bool success = false;
				int attempts = 0;
				while (!success)
				{
					attempts++;
					if (attempts > 1000)
					{
						success = true;
						continue;
					}
					int i = WorldGen.genRand.Next(600, Main.maxTilesX - 600);
					if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50)
					{
						int j = 0;
						while (!Main.tile[i, j].active() && (double)j < Main.worldSurface)
						{
							j++;
						}
						if (Main.tile[i, j].type == TileID.Dirt)
						{
							j--;
							if (j > 150)
							{
								bool placementOK = true;
								for (int l = i - 4; l < i + 4; l++)
								{
									for (int m = j - 6; m < j + 20; m++)
									{
										if (Main.tile[l, m].active())
										{
											int type = (int)Main.tile[l, m].type;
											if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud)
											{
												placementOK = false;
											}
										}
									}
								}
								if (placementOK)
								{
									success = PlaceWell(i, j);
								}
							}
						}
					}
				}
			}
		}

		int[,] wellshape = new int[,]
		{
			{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
			{1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,1},
			{0,4,0,0,3,0,0,0,0,0,4,0,0,0,0,0,4,0,0,0,0,0,3,0,0},
			{0,0,0,0,3,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,3,0,0},
			{0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0},
			{0,0,0,0,6,0,9,7,0,0,0,0,9,7,0,0,0,0,0,8,0,0,3,0,0},
			{1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0}
		};

		int[,] wellshapeWall = new int[,]
		{
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,1,1,1,3,3,3,1,1,1,3,3,3,1,1,1,1,0,0,0},
			{0,0,0,0,0,1,1,1,1,1,3,1,1,1,1,1,3,1,1,1,1,1,0,0,0},
			{0,0,0,0,0,1,1,1,1,1,3,1,1,1,1,1,3,1,1,1,1,1,0,0,0},
			{0,0,0,0,0,1,1,1,1,1,3,1,1,1,1,1,3,1,1,1,1,1,0,0,0},
			{0,0,0,0,0,1,1,1,1,1,3,1,1,1,1,1,3,1,1,1,1,1,0,0,0},
			{0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};


		public bool PlaceWell(int i, int j)
		{
			if (!WorldGen.SolidTile(i, j + 1))
			{
				return false;
			}
			if (Main.tile[i, j].active())
			{
				return false;
			}
			if (j < 150)
			{
				return false;
			}

			for (int y = 0; y < wellshape.GetLength(0); y++)
			{
				for (int x = 0; x < wellshape.GetLength(1); x++)
				{
					int k = i - 3 + x;
					int l = j - 6 + y;
					if (WorldGen.InWorld(k, l, 30))
					{
						Tile tile = Framing.GetTileSafely(k, l);
						switch (wellshape[y, x])
						{
							
							case 0:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								break;
							case 1:
								tile.type = TileID.GrayBrick;
								tile.active(true);
								break;
							case 2:
								tile.type = 30;
								tile.active(true);
								break;
							case 3:
								WorldGen.KillTile (k, l);
								WorldGen.PlaceTile (k, l, mod.TileType("TavernWood"));
								tile.active(true);
								break;
							case 4:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								WorldGen.PlaceObject(k, l, 42, false, 0, -1, 2);
								tile.active(true);
								break;
							case 5:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								tile.type = 19;
								tile.active(false);
								WorldGen.PlaceObject(k, l - 1, 13, false, 0, -1, 3);
								break;
							case 6:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								WorldGen.PlaceObject(k, l, 10);
								break;
							case 7:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								WorldGen.PlaceObject(k, l, 14);
								WorldGen.PlaceObject(k, l - 2, 13, false, 0, -1, 3);
								Main.tile[k + 1,l - 2].type = 33;
								WorldGen.PlaceObject(k + 2, l - 2, 13, false, 0, -1, 3);							
								break;
							case 8:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								WorldGen.PlaceObject(k, l, 14, false, 0, -1, 18);
								WorldGen.PlaceObject(k, l - 2, 13, false, 0, -1, 3);
								WorldGen.PlaceObject(k + 1, l - 2, 13, false, 0, -1, 3);
								WorldGen.PlaceObject(k + 2, l - 2, 13, false, 0, -1, 3);						
								break;
							case 9:
							if (Main.tile[k,l] != null)
                               {
                                if (Main.tile[k,l].type != 14 && Main.tile[k,l].type != 42) // A = x, B = y.
                                { 
									WorldGen.KillTile (k, l);
								}
							   }
								WorldGen.PlaceObject(k, l, 15);
								break;
						}
						switch (wellshapeWall[y, x])
						{
							case 1:
								tile.wall = 4;
								break;
							case 2:
								tile.wall = 5;
								break;
							case 3:
								tile.wall = 27;
								break;
						}
					}
				}
			}
			return true;
		}
        public override void PostWorldGen()
        {
        }
        public override void TileCountsAvailable(int[] tileCounts)
		{
			SlimeTiles = tileCounts[mod.TileType("SlimeMoss")];
		}
	}
}
