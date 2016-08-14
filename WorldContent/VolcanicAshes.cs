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
	public class VolcanicAshes : ModWorld
	{
		public static int FlameTiles = 0;
        public int Num;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				return;
			}
			tasks.Insert(ShiniesIndex +  4, new PassLegacy("VolcanicGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Exing amples";
               
                for (int i = 0; i < (int)Main.maxTilesX / 250; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer - 50, Main.maxTilesY - 500);
					int XvalueHigh = Xvalue + 240;
					int YvalueHigh = Yvalue + 160;
					int XvalueMid = Xvalue + 240;
					int YvalueMid = Yvalue + 160;
					 if (Main.tile[XvalueMid,YvalueMid] != null)
                    {
                    if (Main.tile[XvalueMid,YvalueMid].type ==  1) // A = x, B = y.
                    { 
					
					WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(120,120), 1, mod.TileType("VolcanicAshes"), false, 0f, 0f, true, true); 

                    WorldGen.digTunnel(XvalueMid, YvalueMid, 0, -5000, 1, 9, false);
					}
					}
				}
			}));
	}
        public override void PostWorldGen()
        {
        }
        public override void TileCountsAvailable(int[] tileCounts)
		{
			FlameTiles = tileCounts[mod.TileType("VolcanicAshes")];
		}
	}
}
