using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Auralite.Tiles
{
	public class FlowerTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("Auralite");
			}
		}

		public override bool CanDropAcorn()
		{
			return false;
		}

		public override int CreateDust()
		{
			return 16;
		}

		//public override int GrowthFXGore()
		//{
		//	return mod.GetGoreSlot("Gores/ExampleTreeFX");
		//}

		public override int DropWood()
		{
			return mod.ItemType("SlimeMoss");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/FlowerTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/FlowerTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/FlowerTree_Branches");
		}
	}
}