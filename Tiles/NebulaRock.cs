using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Tiles
{
	public class NebulaRock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
            soundType = 27;
            soundStyle = 2;
			drop = mod.ItemType("SlimeMoss");
			AddMapEntry(new Color(142, 217, 63));
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
        public override bool KillSound(int i, int j)
        {
            Main.PlaySound(4, i * 16, j * 16, 1);
            return false;
        }
		public override void RandomUpdate(int i, int j)
		{
                if (Main.rand.Next(2) == 1)
                {
                    WorldGen.PlaceObject(i, j - 1, mod.TileType("SlimeMushroom"));
                }
		}
    }
}