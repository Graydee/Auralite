using Terraria;
using Terraria.ModLoader;

namespace Auralite.Backgrounds
{
	public class SpringUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.player[Main.myPlayer].GetModPlayer<AuralitePlayer>(mod).ZoneSpring;
		}

	/*	public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG3");
		}*/
		static int SurfaceFrameCounter = 0;
		static int SurfaceFrame = 0;
		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG0");
			if (++SurfaceFrameCounter > 0)
			{
				SurfaceFrame = (SurfaceFrame + 1) % 3;
				SurfaceFrameCounter = 0;
			}
			if (SurfaceFrame == 0)
			{
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG1A");
			}
			if (SurfaceFrame == 1)
			{
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG1B");
			}
			if (SurfaceFrame == 2)
			{
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG1C");
			}
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG2");
			
			if (SurfaceFrame == 0)
			{
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG3A");
			}
			if (SurfaceFrame == 1)
			{
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG3B");
			}
			if (SurfaceFrame == 2)
			{
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/SpringBiomeUG3C");
			}
		}
	}
}