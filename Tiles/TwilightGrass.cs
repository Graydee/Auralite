using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Tiles
{
	public class TwilightGrass : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			AddMapEntry(new Color(162, 222, 184));
            SetModTree(new TwilightTree());
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("TwilightSapling");
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.00f;
			g = 1.75f;
			b = 0.35f;
		}
    }
}