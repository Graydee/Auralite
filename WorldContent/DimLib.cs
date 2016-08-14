using System.IO;
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
	}
}
