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
	public class DimSolar : ModWorld
	{
		public void GenerateSolarDimension(Rectangle rect){
            //Note about rectangle:
            //Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
            //Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
            //Height of the rectangle means nothing that I am aware of. It's probably just the world height.
            DimLib.InitDimension(rect);

            Action<int, int> activate = (x, y) => Main.tile[x, y].active(true);
            Action<int, int> deactivate = (x, y) => Main.tile[x, y].active(false);
            Action<int, int> deactivateDirt = (x, y) => {
                if(Main.tile[x, y].type == TileID.Dirt)
                    deactivate(x, y);
            };

            //activate all tiles
            DimLib.DoXInRect(rect, activate);

            //place pillars of nebula stone
            //pillars spawn no closer than 100 tiles from edges of world
            for(int Y = 0; Y < rect.Height; Y++) {
                //1 in 40 chance of pillar per tile
                if(Main.rand.Next(36) == 0) {
                    //pillar starting height is 20% to 30% of world height
                    //pillar goes to bottom of the world
                    for(int X = rect.X + 25; X < rect.Right - 25; X++) {
                        DimLib.TileRunner(X, Y, Main.rand.Next(14,17), 1, mod.TileType("SolarRock"), false, 0f, 0f, true); 
						if(Main.rand.Next(80) == 0) {
							DimLib.TileRunner(X, Y -12, 25, 1, mod.TileType("SolarRock"), false, 0f, 0f, true); 
						}
						if(Main.rand.Next(80) == 0) {
							DimLib.TileRunner(X, Y + 12, 25, 1, mod.TileType("SolarRock"), false, 0f, 0f, true); 
						}
                    }
                }
            }

            //remove all the dirt
            DimLib.DestroyDirt(rect, deactivateDirt);
        }
	}
}
