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
	public class DimStardust : ModWorld
	{
		public void GenerateStardustDimension(Rectangle rect){
			//Note about rectangle:
			//Position of rectangle is the top-right corner of the dimension. So it'll be (X, 0).
			//Width of the rectangle is always 500 for now, unless we get custom sizes in the future.
			//Height of the rectangle means nothing that I am aware of. It's probably just the world height.
			DimLib.InitDimension(rect);

			//Places a dirt by activating the tile. Default tile type is 0 (dirt) but is inactive (air)
			Main.tile[rect.Width / 2 + rect.X, rect.Height / 2].active(true);
		}
	}
}
