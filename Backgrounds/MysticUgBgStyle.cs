using Terraria;
using Terraria.ModLoader;

namespace Auralite.Backgrounds
{
	public class MysticUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.player[Main.myPlayer].GetModPlayer<AuralitePlayer>(mod).ZoneMystic;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/MysticBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/MysticBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/MysticBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/MysticBiomeUG3");
		}
	}
}