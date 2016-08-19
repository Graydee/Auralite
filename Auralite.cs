using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Auralite.Tiles;
using Auralite.NPCs;
using Auralite.WorldContent;
using Auralite.WorldContent.Skies;
using AlternateDimensions;

namespace Auralite
{
	class Auralite : Mod
	{
		public override string Name {
			get {
				return "Auralite";
			}
		}

		public const int Hire = 0;
		public const int Fail = 1;
		public const int Fire = 2;
		public const int AltFail = 3;
		public const int NoShop = 4;

		//Dictionaries for all the unique messages
		//hire: when NPC is hired by a player
		//fail: when NPC is already hired, and is given a contract by the same player
		//fire: when NPC is dismissed by release contract
		//altFail: when NPC is already hired, and is given a contract by a different player
		//noShop: when NPC is interacted with while hired
		public Dictionary<int, string[]> hireMessages = new Dictionary<int, string[]>();
		public Dictionary<int, string[]> failMessages = new Dictionary<int, string[]>();
		public Dictionary<int, string[]> fireMessages = new Dictionary<int, string[]>();
		public Dictionary<int, string[]> altFailMessages = new Dictionary<int, string[]>();
		public Dictionary<int, string[]> noShopMessages = new Dictionary<int, string[]>();

		//AI related objects
		public Dictionary<int, Action<NPC>> attackStyles = new Dictionary<int, Action<NPC>>();
		public Dictionary<int, Action<NPC>> aiStyle = new Dictionary<int, Action<NPC>>();
		public MercAI mercAI = new MercAI();

		public Auralite()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
		}

		public override void Load()
		{
			//party system info loading
			string[] defHireMessages = { "At your service!", "Let's go!" };
			string[] defFailMessages = { "What's the big idea?", "I'm already under contract." };
			string[] defFireMessages = { "Thanks for the cash!", "What an adventure!" };
			string[] defAltFailMessages = { "Bugger off.", "Sorry, but my current contract includes loyalty." };
			string[] defNoShopMessages = { "Sorry, I'm busy right now.", "Talk to me when my contract's up.", "Would you prefer shopping, or monsters off your back?" };
			string[] dryadHireMessages = { "You could've just asked." };
			string[] dryadFailMessages = { "I'm still following you. Just admiring nature." };
			string[] dryadFireMessages = { "Just don't LITERALLY fire me, k?" };
			string[] dryadAltFailMessages = { "Apples don't fall far from the tree. You are the wrong tree." };
			string[] dryadNoShopMessages = { "You can get that purification powder when I'm home, mister." };

			AddCustomMessages(-1, defHireMessages, defFailMessages, defFireMessages, defAltFailMessages, defNoShopMessages);
			AddCustomMessages(NPCID.Dryad, dryadHireMessages, dryadFailMessages, dryadFireMessages, dryadAltFailMessages, dryadNoShopMessages); 

			mercAI.LoadAIMethods();
			aiStyle.Add(NPCID.Guide, mercAI.AttackAIGuide);
			aiStyle.Add(NPCID.DyeTrader, mercAI.AttackAIDyeTrader);
			aiStyle.Add(NPCID.Dryad, mercAI.AttackAIDryad);
			aiStyle.Add(NPCID.Nurse, mercAI.AINurse);

			//custom sky loading
			Filters.Scene["Auralite:NebulaSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(1f, 0f, 0.9f).UseOpacity(0.5f), EffectPriority.High);
			Filters.Scene["Auralite:SolarSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(1f, 0.7f, 0f).UseOpacity(0.3f), EffectPriority.High);
			Filters.Scene["Auralite:StardustSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0f, 0.5f, 1f).UseOpacity(0.5f), EffectPriority.High);
			Filters.Scene["Auralite:VortexSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0f, 0.7f, 0.7f).UseOpacity(0.5f), EffectPriority.High);
			SkyManager.Instance["Auralite:NebulaSky"] = new DimNebulaSky();
			SkyManager.Instance["Auralite:SolarSky"] = new DimSolarSky();
			SkyManager.Instance["Auralite:StardustSky"] = new DimStardustSky();
			SkyManager.Instance["Auralite:VortexSky"] = new DimVortexSky();
		}

		public void AddCustomMessages(int npcID, string[] hire, string[] fail, string[] fire, string[] altFail, string[] noShop){
			hireMessages.Add(npcID, hire);
			failMessages.Add(npcID, fail);
			fireMessages.Add(npcID, fire);
			altFailMessages.Add(npcID, altFail);
			noShopMessages.Add(npcID, noShop);
		}

		public void DisplayCustomMessage(NPC npc, int mode){
			//modes: 0 = hire, 1 = fail, 2 = fire, 3 = alt fail, 4 = shop refusal
			//hiring is green, firing is blue, and failed hires are red
			string[] messages;

			//handling for if an NPC does not have any set messages
			int type;
			if(!hireMessages.ContainsKey(npc.type)) type = -1; //-1 is default messages key
			else type = npc.type;

			//display the message on the screen
			switch(mode){
			case(Hire):
				messages = hireMessages[type];
				Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 0, 255, 0);
				break;
			case(Fail):
				messages = failMessages[type];
				Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 255, 0, 0);
				break;
			case(Fire):
				messages = fireMessages[type];
				Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 0, 0, 255);
				break;
			case(AltFail):
				messages = altFailMessages[type];
				Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 255, 0, 0);
				break;
			case(NoShop):
				messages = noShopMessages[type];
				Main.NewText(npc.displayName + ": " + messages[Main.rand.Next(0, messages.Length)], 255, 0, 0);
				break;
			}
		}

		public override void UpdateMusic(ref int music)
		{
			Player player = Main.player[Main.myPlayer];

			//Don't override the songs in this list!
			int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
				MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
				MusicID.PirateInvasion};

			bool playMusic = true;
			foreach(int n in NoOverride) {
				if(music == n) playMusic = false;
			}

			if(player.active && !Main.gameMenu && playMusic) {
				AuralitePlayer modPlayer = player.GetModPlayer<AuralitePlayer>(this);
				if(modPlayer.ZoneSlime) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SlimeDen");
				}
				if(modPlayer.ZoneMystic) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/MysticCaves");
				}
				if(modPlayer.ZoneFlower) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/FlowerForest");
				}
				if(modPlayer.ZoneSpring) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/UndergroundSprings");
				}
				if(modPlayer.ZoneStardust) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Stardust");
				}
				if(modPlayer.ZoneNebula) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Nebula1");
				}
				if(modPlayer.ZoneVortex) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Vortex1");
				}
			}
		}

		public override void PostSetupContent()
		{
			Mod altDimensions = ModLoader.GetMod("AlternateDimensions");
			DimNebula nebula = (DimNebula)GetModWorld("DimNebula");
			DimSolar solar = (DimSolar)GetModWorld("DimSolar");
			DimStardust stardust = (DimStardust)GetModWorld("DimStardust");
			DimVortex vortex = (DimVortex)GetModWorld("DimVortex");
			if(altDimensions != null) {
				AlternateDimensionInterface.RegisterDimension(this.Name, "Nebula", nebula.GenerateNebulaDimension);
				AlternateDimensionInterface.RegisterDimension(this.Name, "Solar", solar.GenerateSolarDimension);
				AlternateDimensionInterface.RegisterDimension(this.Name, "Stardust", stardust.GenerateStardustDimension);
				AlternateDimensionInterface.RegisterDimension(this.Name, "Vortex", vortex.GenerateVortexDimension);
			}
		}
	}
}
