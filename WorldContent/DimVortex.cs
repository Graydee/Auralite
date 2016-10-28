using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Auralite.WorldContent
{
	public class DimVortex : ModWorld
	{
		 public void GenerateVortexDimension(Rectangle rect){
            //Note about rectangle:
            //Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
            //Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
            //Height of the rectangle means nothing that I am aware of. It's probably just the world height.
            //DimLib.InitDimension(rect);

            Action<int, int> activate = (x, y) => Main.tile[x, y].active(true);
            Action<int, int> deactivate = (x, y) => Main.tile[x, y].active(false);
            Action<int, int> deactivateDirt = (x, y) => {
                if(Main.tile[x, y].type == TileID.Dirt)
                    deactivate(x, y);
            };

            //activate all tiles

            //place pillars of nebula stone
            //pillars spawn no closer than 100 tiles from edges of world
            for(int X = rect.X + 25; X < rect.Right - 25; X++) {
                //1 in 40 chance of pillar per tile
                    //pillar starting height is 20% to 30% of world height
                    int Height = 15;
                //pillar goes to bottom of the world
                for (int Y = Height; Y < rect.Height; Y++) {
                    if (Main.rand.Next(20000) == 0 && Y > Height + 50 && Y < rect.Height - 70 && X > rect.X + 100 && X < rect.Right - 100)
                    {
                        for (int xAxis = X; xAxis < X + 100; xAxis++)
                        {
                            int Slope2 = Math.Abs(Main.rand.Next(45, 55) - Math.Abs((xAxis - X) - Main.rand.Next(45, 55))) / 2;
                            string SlopeText = Slope2.ToString();
                            //Main.NewText(SlopeText, Color.Orange.R, Color.Orange.G, Color.Orange.B);
                            for (int I = 0; I < Slope2; I++)
                            {
                                DimLib.TileRunner(xAxis, Y + I, (double)WorldGen.genRand.Next(12, 12), 1, mod.TileType("VortexIslandRock"), true, 0f, 0f, true, true);
                            }
                            DimLib.TileRunner(xAxis, Y, (double)WorldGen.genRand.Next(12, 12), 1, mod.TileType("VortexIslandRock"), true, 0f, 0f, true, true);
                            if (Main.rand.Next(13) == 0)
                            {
                                WorldMethods.RoundHill(xAxis, Y, 11, 5, 8, true, (ushort)mod.TileType("VortexIslandRock"));

                            }
                            if (Main.rand.Next(20) == 0)
                            {
                                WorldMethods.RoundHill(xAxis, Y - 3, 9, 6, 6, true, (ushort)mod.TileType("VortexIslandRock"));

                            }
                        }
                    }
                    if (Main.rand.Next(400) == 0)
                    {
                        DimLib.TileRunner(X, Y, Main.rand.Next(10, 16), 1, mod.TileType("VortexRock"), true, 0f, 0f, false, false);
                    }
                }
            }




            //remove all the dirt
			}
	}
}
