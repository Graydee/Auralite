using System;
using Terraria;
using Terraria.ModLoader;

namespace Auralite.Buffs
{
	public class StolenTime : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Stolen time";
			Main.buffTip[Type] = "You almost broke time";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}