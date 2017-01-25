/*using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Auralite.NPCs;

namespace Auralite.WorldContent
{
	public class MercData : ModWorld
	{
		public const int maxPartySize = 4;

		//List of all currently hired NPCs.
		//Tuple is extra security, used to prevent adding of data to incorrect NPCs
		public Dictionary<Tuple<int, string>, int> data = new Dictionary<Tuple<int, string>, int>();

		public int GetOwner(int npcType, string npcName){
			Tuple<int, string> tup = new Tuple<int, string>(npcType, npcName);
			if(data.ContainsKey(tup)) {
				return data[tup];
			} else {
				return -1;
			}
		}

		public int GetOwner(NPC npc){
			return GetOwner(npc.type, npc.displayName);
		}

		public void Hire(int npcType, string npcName, int player){
			data.Add(new Tuple<int, string>(npcType, npcName), player);
		}

		public void Hire(NPC npc, int player){
			Hire(npc.type, npc.displayName, player);
		}

		public void Fire(int npcType, string npcName){
			Tuple<int, string> tup = new Tuple<int, string>(npcType, npcName);
			if(data.ContainsKey(tup)) {
				data.Remove(tup);
			}
		}

		public void Fire(NPC npc){
			Fire(npc.type, npc.displayName);
		}

		public bool Hired(int npcType, string npcName){
			Tuple<int, string> tup = new Tuple<int, string>(npcType, npcName);
			return data.ContainsKey(tup);
		}

		public bool Hired(NPC npc){
			return Hired(npc.type, npc.displayName);
		}

		public override void SaveCustomData(System.IO.BinaryWriter writer)
		{
			//Write the amount of things
			writer.Write((short)data.Count);

			//Write all the data
			foreach(KeyValuePair<Tuple<int, string>, int> pair in data) {
				WriteData(pair.Key.Item1, pair.Key.Item2, pair.Value, writer);
			}

			//Clear the dictionary
			data.Clear();
		}

		private void WriteData(int id, string name, int player, System.IO.BinaryWriter writer){
			writer.Write((short)id);
			writer.Write(name);
			writer.Write((short)player);
		}

		public override void LoadCustomData(System.IO.BinaryReader reader)
		{
			//Read in amount of NPC data to load
			int things = (int)reader.ReadInt16();
			for(int i = 0; i < things; i++){
				Hire((int)reader.ReadInt16(), reader.ReadString(), (int)reader.ReadInt16());
			}
		}

		public static MercData GetMercData(){
			return (MercData)(ModLoader.GetMod("Auralite").GetModWorld("MercData"));
		}

		//This removes all invalid dictionary members, so as to only track
		//NPCs that are actually in the world.
		public void CleanData(){
			foreach(KeyValuePair<Tuple<int, string>, int> pair in data) {
				bool keep = false;
				foreach(NPC npc in Main.npc) {
					if(npc.active && npc.type == pair.Key.Item1 && npc.displayName == pair.Key.Item2) {
						keep = true;
						break;
					}
				}
				if(!keep) {
					data.Remove(pair.Key);
				}
			}
		}
	}
}*/

