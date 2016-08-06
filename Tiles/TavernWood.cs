using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Tiles
{
	public class TavernWood : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			AddMapEntry(new Color(162, 222, 184));
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