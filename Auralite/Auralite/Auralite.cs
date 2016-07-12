using Terraria.ModLoader;

namespace Auralite
{
	class Auralite : Mod
	{
		public Auralite()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
