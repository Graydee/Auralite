using Terraria;
using Terraria.ModLoader;

namespace Auralite.Backgrounds
{
	public class FlameUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.player[Main.myPlayer].GetModPlayer<AuralitePlayer>(mod).ZoneFlame;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/FlameBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/FlameBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/FlameBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/FlameBiomeUG3");
		}
	}
}