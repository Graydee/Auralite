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
		//Returns whether the given x-coordinate is within the given dimension.
		public static bool InDimension(int x, string modName, string dimName){
			Rectangle rect = AlternateDimensions.AlternateDimensionInterface.DimensionRectangle(modName, dimName);
			return rect.Contains(x/16, 1);
		}

		public static void InitDimension(Rectangle rect){
			System.Action<int, int> initTile = (x, y) => Main.tile[x, y] = new Tile();
			DoXInRect(rect, initTile);
		}

		public static void DoXInRect(Rectangle rect, params System.Action<int, int>[] stuff){
			for(int i = rect.X; i < rect.Right; i++) {
				for(int j = 0; j < rect.Height; j++) {
					foreach(System.Action<int, int> action in stuff) {
						action(i, j);
					}
				}
			}
		}

		public static void DestroyDirt(Rectangle rect, params System.Action<int, int>[] stuff){
			for(int i = rect.X; i < rect.Right; i++) {
				for(int j = 0; j < rect.Height; j++) {
					if (Main.tile[i, j].type == TileID.Dirt && Main.tile[i, j].active())
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
            Vector2 pos;
			pos.X = (float)i;
            pos.Y = (float)j;
            Vector2 randVect;
			randVect.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            randVect.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                randVect.X = speedX;
                randVect.Y = speedY;
			}

            while (num > 0.0 && num2 > 0f)
            {
                if (pos.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)pos.X - num * 0.5);
                int num4 = (int)((double)pos.X + num * 0.5);
                int num5 = (int)((double)pos.Y - num * 0.5);
                int num6 = (int)((double)pos.Y + num * 0.5);
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
                        if ((double)(Math.Abs((float)k - pos.X) + Math.Abs((float)l - pos.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
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
                                if (type == 59 && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                                {
                                    Main.tile[k, l].lava(false);
                                    Main.tile[k, l].liquid = 0;
                                }
                            }
                        }
                    }
                }
                pos += randVect;
                if (num > 50.0)
                {
                    pos += randVect;
                    num2 -= 1f;
                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num > 100.0)
                    {
                        pos += randVect;
                        num2 -= 1f;
                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 150.0)
                        {
                            pos += randVect;
                            num2 -= 1f;
                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 200.0)
                            {
                                pos += randVect;
                                num2 -= 1f;
                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 250.0)
                                {
                                    pos += randVect;
                                    num2 -= 1f;
                                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 300.0)
                                    {
                                        pos += randVect;
                                        num2 -= 1f;
                                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 400.0)
                                        {
                                            pos += randVect;
                                            num2 -= 1f;
                                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 500.0)
                                            {
                                                pos += randVect;
                                                num2 -= 1f;
                                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 600.0)
                                                {
                                                    pos += randVect;
                                                    num2 -= 1f;
                                                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 700.0)
                                                    {
                                                        pos += randVect;
                                                        num2 -= 1f;
                                                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 800.0)
                                                        {
                                                            pos += randVect;
                                                            num2 -= 1f;
                                                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 900.0)
                                                            {
                                                                pos += randVect;
                                                                num2 -= 1f;
                                                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
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
                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (randVect.X > 1f)
                {
                    randVect.X = 1f;
                }
                if (randVect.X < -1f)
                {
                    randVect.X = -1f;
                }
                if (!noYChange)
                {
                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (randVect.Y > 1f)
                    {
                        randVect.Y = 1f;
                    }
                    if (randVect.Y < -1f)
                    {
                        randVect.Y = -1f;
                    }
                }
                else if (type != 59 && num < 3.0)
                {
                    if (randVect.Y > 1f)
                    {
                        randVect.Y = 1f;
                    }
                    if (randVect.Y < -1f)
                    {
                        randVect.Y = -1f;
                    }
                }
                if (type == 59 && !noYChange)
                {
                    if ((double)randVect.Y > 0.5)
                    {
                        randVect.Y = 0.5f;
                    }
                    if ((double)randVect.Y < -0.5)
                    {
                        randVect.Y = -0.5f;
                    }
                    if ((double)pos.Y < Main.rockLayer + 100.0)
                    {
                        randVect.Y = 1f;
                    }
                    if (pos.Y > (float)(Main.maxTilesY - 300))
                    {
                        randVect.Y = -1f;
                    }
                }
            }
        }
	}
}
