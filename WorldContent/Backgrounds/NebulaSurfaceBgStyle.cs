using Terraria;
using Terraria.ModLoader;

namespace Auralite.WorldContent.Backgrounds
{
	public class NebulaSurfaceBgStyle : ModSurfaceBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return !Main.gameMenu && Main.player[Main.myPlayer].GetModPlayer<AuralitePlayer>(mod).ZoneNebula;
		}

		// Use this to keep far Backgrounds like the mountains.
		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseFarTexture()
		{
			return mod.GetBackgroundSlot("Backgrounds/NebulaBiomeSurfaceFar");
		}

		static int SurfaceFrameCounter = 0;
		static int SurfaceFrame = 0;
		public override int ChooseMiddleTexture()
		{
				return mod.GetBackgroundSlot("Backgrounds/NebulaBiomeSurfaceMid");
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
			return mod.GetBackgroundSlot("Backgrounds/NebulaBiomeSurfaceClose");
		}
	}
}