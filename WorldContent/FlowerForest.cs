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
	public class FlowerForest : ModWorld
	{
		public static int FlowerTiles = 0;
        public int Num;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				return;
			}
			tasks.Insert(ShiniesIndex + 1, new PassLegacy("SpoilerGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Growing spoilers";
               
                for (int i = 0; i < (int)Main.maxTilesX / 250; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = (int)Main.worldSurface;
					int XvalueHigh = Xvalue + 40;
					int YvalueHigh = Yvalue + 40;
					int XvalueMid = Xvalue + 20;
					int YvalueMid = Yvalue + 20;
					
					WorldGen.TileRunner(XvalueMid, YvalueMid + 20, (double)WorldGen.genRand.Next(20,20), 1, mod.TileType("[spoiler tile]"), false, 0f, 0f, true, true); 

				}
			}));
	}
        public override void PostWorldGen()
        {
        }
      /*  public override void TileCountsAvailable(int[] tileCounts)
		{
			FlameTiles = tileCounts[mod.TileType("VolcanicAshes")];
		}*/
	}
}
