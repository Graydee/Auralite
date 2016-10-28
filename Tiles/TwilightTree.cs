using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Auralite.Tiles
{
	public class TwilightTree : ModTree
	{
        public override int DropWood()
        {
            return 1;
        }
        private Mod mod
		{
			get
			{
				return ModLoader.GetMod("Auralite");
			}
		}

		public override int CreateDust()
		{
			return 2;
		}

		public override int GrowthFXGore()
		{
			return 1;
		}


		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/TwilightTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/TwilightTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/TwilightTree_Branches");
		}
	}
}