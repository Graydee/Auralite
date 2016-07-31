using Terraria;
using Terraria.ModLoader;

namespace Auralite.Backgrounds
{
	public class SlimeUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.player[Main.myPlayer].GetModPlayer<AuralitePlayer>(mod).ZoneSlime;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/SlimeBiomeUG3");
		}
	}
}