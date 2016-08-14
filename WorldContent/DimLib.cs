using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

//This is a class which stores any random utility methods for dimension generation.
//For now it just contains one. Eh.
namespace Auralite.WorldContent
{
	public class DimLib
	{
		public static void InitDimension(Rectangle rect){
			System.Action<int, int> initTile = (x, y) => Main.tile[x, y] = new Tile();
			DoXInRect(rect, initTile);
		}

		public static void DoXInRect(Rectangle rect, params System.Action<int, int>[] stuff){
			for(int i = rect.X; i < rect.Right; i++) {
				for(int j = 0; j < rect.Height; j++) {
					Main.tile[i, j] = new Tile();
					foreach(System.Action<int, int> action in stuff) {
						action(i, j);
					}
				}
			}
		}
		public static void DestroyDirt(Rectangle rect, params System.Action<int, int>[] stuff){
			for(int i = rect.X; i < rect.Right; i++) {
				for(int j = 0; j < rect.Height; j++) {
					if (Main.tile[i, j].type == TileID.Dirt)
					{
					Main.tile[i, j] = new Tile();
					}
					foreach(System.Action<int, int> action in stuff) {
						action(i, j);
					}
				}
			}
		}
		public static void TileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            double num = strength;
            float num2 = (float)steps;
            Vector2 vector;
            vector.X = (float)i;
            vector.Y = (float)j;
            Vector2 vector2;
            vector2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                vector2.X = speedX;
                vector2.Y = speedY;
            }
            bool flag = type == 368;
            bool flag2 = type == 367;
            while (num > 0.0 && num2 > 0f)
            {
                if (vector.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)vector.X - num * 0.5);
                int num4 = (int)((double)vector.X + num * 0.5);
                int num5 = (int)((double)vector.Y - num * 0.5);
                int num6 = (int)((double)vector.Y + num * 0.5);
                if (num3 < 1)
                {
                    num3 = 1;
                }
                if (num5 < 1)
                {
                    num5 = 1;
                }
                if (num6 > Main.maxTilesY - 1)
                {
                    num6 = Main.maxTilesY - 1;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                        
                            if (type < 0)
                            {
                                if (type == -2 && Main.tile[k, l].active() && (l < WorldGen.waterLine || l > WorldGen.lavaLine))
                                {
                                    Main.tile[k, l].liquid = 255;
                                    if (l > WorldGen.lavaLine)
                                    {
                                        Main.tile[k, l].lava(true);
                                    }
                                }
                                Main.tile[k, l].active(false);
                            }
                            else
                            {
                                if (flag && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                                {
                                    WorldGen.PlaceWall(k, l, 180, true);
                                }
                                if (flag2 && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                                {
                                    WorldGen.PlaceWall(k, l, 178, true);
                                }
                                if (overRide || !Main.tile[k, l].active())
                                {
                                    Tile tile = Main.tile[k, l];
                                    bool flag3 = Main.tileStone[type] && tile.type != 1;
                                    if (!TileID.Sets.CanBeClearedDuringGeneration[(int)tile.type])
                                    {
                                        flag3 = true;
                                    }
                                    ushort type2 = tile.type;
                                    if (type2 <= 147)
                                    {
                                        if (type2 <= 45)
                                        {
                                            if (type2 != 1)
                                            {
                                                if (type2 == 45)
                                                {
                                                    goto IL_575;
                                                }
                                            }
                                            else if (type == 59 && (double)l < Main.worldSurface + (double)WorldGen.genRand.Next(-50, 50))
                                            {
                                                flag3 = true;
                                            }
                                        }
                                        else if (type2 != 53)
                                        {
                                            if (type2 == 147)
                                            {
                                                goto IL_575;
                                            }
                                        }
                                        else
                                        {
                                            if (type == 40)
                                            {
                                                flag3 = true;
                                            }
                                            if ((double)l < Main.worldSurface && type != 59)
                                            {
                                                flag3 = true;
                                            }
                                        }
                                    }
                                    else if (type2 <= 196)
                                    {
                                        switch (type2)
                                        {
                                        case 189:
                                        case 190:
                                            goto IL_575;
                                        default:
                                            if (type2 == 196)
                                            {
                                                goto IL_575;
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        switch (type2)
                                        {
                                        case 367:
                                        case 368:
                                            if (type == 59)
                                            {
                                                flag3 = true;
                                            }
                                            break;
                                        default:
                                            switch (type2)
                                            {
                                            case 396:
                                            case 397:
                                                flag3 = !TileID.Sets.Ore[type];
                                                break;
                                            }
                                            break;
                                        }
                                    }
                                    IL_5B7:
                                    if (!flag3)
                                    {
                                        tile.type = (ushort)type;
                                        goto IL_5C5;
                                    }
                                    goto IL_5C5;
                                    IL_575:
                                    flag3 = true;
                                    goto IL_5B7;
                                }
                                IL_5C5:
                                if (addTile)
                                {
                                    Main.tile[k, l].active(true);
                                    Main.tile[k, l].liquid = 0;
                                    Main.tile[k, l].lava(false);
                                }
                                if (noYChange && (double)l < Main.worldSurface && type != 59)
                                {
                                    Main.tile[k, l].wall = 2;
                                }
                                if (type == 59 && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                                {
                                    Main.tile[k, l].lava(false);
                                    Main.tile[k, l].liquid = 0;
                                }
                            }
                        }
                    }
                }
                vector += vector2;
                if (num > 50.0)
                {
                    vector += vector2;
                    num2 -= 1f;
                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num > 100.0)
                    {
                        vector += vector2;
                        num2 -= 1f;
                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 150.0)
                        {
                            vector += vector2;
                            num2 -= 1f;
                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 200.0)
                            {
                                vector += vector2;
                                num2 -= 1f;
                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 250.0)
                                {
                                    vector += vector2;
                                    num2 -= 1f;
                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 300.0)
                                    {
                                        vector += vector2;
                                        num2 -= 1f;
                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 400.0)
                                        {
                                            vector += vector2;
                                            num2 -= 1f;
                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 500.0)
                                            {
                                                vector += vector2;
                                                num2 -= 1f;
                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 600.0)
                                                {
                                                    vector += vector2;
                                                    num2 -= 1f;
                                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 700.0)
                                                    {
                                                        vector += vector2;
                                                        num2 -= 1f;
                                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 800.0)
                                                        {
                                                            vector += vector2;
                                                            num2 -= 1f;
                                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 900.0)
                                                            {
                                                                vector += vector2;
                                                                num2 -= 1f;
                                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (!noYChange)
                {
                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                else if (type != 59 && num < 3.0)
                {
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                if (type == 59 && !noYChange)
                {
                    if ((double)vector2.Y > 0.5)
                    {
                        vector2.Y = 0.5f;
                    }
                    if ((double)vector2.Y < -0.5)
                    {
                        vector2.Y = -0.5f;
                    }
                    if ((double)vector.Y < Main.rockLayer + 100.0)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector.Y > (float)(Main.maxTilesY - 300))
                    {
                        vector2.Y = -1f;
                    }
                }
            }
        }
	}
}
