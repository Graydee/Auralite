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
	public class DimNebula : ModWorld
	{
		public void GenerateNebulaDimension(Rectangle rect){
			//Note about rectangle:
			//Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
			//Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
			//Height of the rectangle means nothing that I am aware of. It's probably just the world height.

			//Places a dirt by activating the tile. Default tile type is 0 (dirt) but is inactive (air)
			DimLib.InitDimension(rect);
			for(int i = rect.X; i < rect.Right; i++) {
                for(int j = 0; j < rect.Height; j++) {
                    Main.tile[i, j].active(true);
				}
			}
			for (int X = rect.X + 100; X < rect.Width + rect.X - 100; X++ )
			if (Main.rand.Next(40) == 0)
			{
				int Hight = Main.rand.Next(400,500);
				for (int Y = Hight; X < rect.Height - 1000; Y++ )
				{
					WorldGen.TileRunner(X, Y, (double)WorldGen.genRand.Next(80,80), 1, mod.TileType("NebulaRock"), false, 0f, 0f, true, true); 
				}
				
			}
			for(int i = rect.X; i < rect.Right; i++) {
                for(int j = 0; j < rect.Height; j++) {
					if (Main.tile[i, j].type == TileID.Dirt)
					{
						Main.tile[i, j].active(false);
					}
				}
			}
			Main.tile[rect.Width / 2 + rect.X, rect.Height / 2].active(true);
		}
	}
}
