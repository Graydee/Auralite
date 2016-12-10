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
	public class DimNebula : ModWorld
	{
		 public void GenerateNebulaDimension(Rectangle rect){
            //Note about rectangle:
            //Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
            //Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
            //Height of the rectangle means nothing that I am aware of. It's probably just the world height.
            //DimLib.InitDimension(rect);

            Action<int, int> activate = (x, y) => Main.tile[x, y].active(true);
            Action<int, int> deactivate = (x, y) => Main.tile[x, y].active(false);
            Action<int, int> deactivateDirt = (x, y) => {
                if(Main.tile[x, y].type == TileID.Dirt && Main.tile[x, y].active())
                    deactivate(x, y);
            };

            //activate all tiles
            DimLib.DoXInRect(rect, activate);
            //place pillars of nebula stone
            //pillars spawn no closer than 100 tiles from edges of world
            for (int X = rect.X + 25; X < rect.Right - 25; X++) {
                //1 in 40 chance of pillar per tile
                if(Main.rand.Next(20) == 0) {
                    //pillar starting height is 20% to 30% of world height
                    int Height = Main.rand.Next((int)(Main.maxTilesY*.24), (int)(Main.maxTilesY*.44));
                    //pillar goes to bottom of the world
                    for(int Y = Height; Y < rect.Height; Y++) {
                        DimLib.TileRunner(X, Y, Main.rand.Next(10,16), 1, mod.TileType("NebulaRock"), false, 0f, 0f, true); 
                    }
                }
            }
            for (int EX = rect.X + 25; EX < rect.Right - 25; EX++)
            {
                for (int Why = 25; Why < Main.maxTilesY * .2; Why++)
                {
                    if (Main.rand.Next(5000) == 0)
                    {
                        int size = Main.rand.Next(3, 25);
                        WorldMethods.RoundHill(EX, Why, size, size, (int)(size * 1.5), true, (ushort)mod.TileType("StarfireBlock"));
                    }
                }
                
            }

                //remove all the dirt
                DimLib.DestroyDirt(rect, deactivateDirt);
        }
	}
	}
