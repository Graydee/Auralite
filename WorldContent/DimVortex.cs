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
	public class DimVortex : ModWorld
	{
		public void GenerateVortexDimension(Rectangle rect){
			//Note about rectangle:
			//Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
			//Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
			//Height of the rectangle means nothing that I am aware of. It's probably just the world height.
			InitTilesInRect(rect);
		}

		public static void InitTilesInRect(Rectangle rect){
			for(int i = rect.X; i < rect.Right; i++) {
				for(int j = 0; j < rect.Height; j++) {
					Main.tile[i, j] = new Tile();
				}
			}
		}
	}
}
