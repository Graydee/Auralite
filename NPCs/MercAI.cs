using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Auralite;
using Auralite.WorldContent;

namespace Auralite.NPCs
{
	/// <summary>
	/// This class contains the default AI functions and methods.
	/// It is intended to be a kind of structure for ease of AI creation.
	/// </summary>
	public class MercAI
	{
		/// <summary>
		/// Makes the NPC teleport to the player after
		/// the NPC is over the given distance (in pixels)
		/// from the player.
		/// NPCs will not teleport to a player that is too far off the ground (ideally).
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="maxDistance">Max distance from player before teleport, in pixels.</param>
		public void TeleportToPlayer(NPC npc, int maxDistance = 500){
			MercData mercData = MercData.GetMercData();
			Player player = Main.player[mercData.GetOwner(npc.type, npc.displayName)];
			if(npc.Distance(player.Center) > maxDistance){
				npc.position = player.position;
			}
		}

		/// <summary>
		/// Makes the NPC follow the player.
		/// The NPC will try to follow at least the given distance
		/// away from the player. This method includes jumping etc..
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="moveSpeed">Maximum movement speed.</param>
		/// <param name="minDistance">Minimum following distance.</param>
		public void FollowPlayer(NPC npc, float moveSpeed = 7, int minDistance = 50){
			//TODO: Add in this code
		}

		/// <summary>
		/// Makes the NPC follow the given NPC.
		/// Used for melee patterns to get close,
		/// and in the Nurse AI to follow allies.
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="target">The NPC to 'follow'.</param>
		/// <param name="moveSpeed">Maximum speed to follow NPC at.</param>
		/// <param name="minDistance">Minimum following distance, in pixels.</param> 
		/// <param name="buffer">How much distance this NPC should stay away from the target.</param> 
		public void FollowNPC(NPC npc, int target, float moveSpeed = 7, int minDistance = 50, int buffer = 50){
			//TODO: Add in this code
		}

		/// <summary>
		/// Gets whether the NPC has a clear line of sight to the target.
		/// "line of sight" is from the NPC's head to the target's hitbox.
		/// If any of the NPC's hitbox is "visible", this returns true.
		/// NOTE: This existing is probably overkill. It's intended to make AI not attack things it can't.
		/// </summary>
		/// <returns><c>true</c> if there is a clear line of sight to target, <c>false</c> otherwise.</returns>
		/// <param name="npc">The NPC.</param>
		/// <param name="target">The target NPC.</param>
		/// <param name="headOffset">Offset of the NPC's head from the center.</param>
		/// <param name="stepSize">Step size of the raytracing formula. Advanced users only.</param>
		public bool LineOfSight(NPC npc, int target, Vector2 headOffset = default(Vector2), int stepSize = 16){
			//TODO: Make better formula, calculate using hitbox & offset as opposed to centers?
			NPC targetNPC = Main.npc[target];
			//Vector2 offsetCenter = npc.Center + headOffset;
			Vector2 dir = npc.DirectionTo(targetNPC.Center);
			float dist = npc.Distance(targetNPC.Center);
			float i = 0;
			do{
				i += 16;
				if(dist - i < stepSize || i > dist) {
					i = dist;
				}

				Vector2 loc = npc.Center + dir*i;
				Tile tile = Main.tile[(int)loc.X/16, (int)loc.Y/16];

				//if there is a solid tile here
				if(tile.type != 0 && Main.tileSolid[tile.type]){
					//raytrace fail, LOS blocked
					return false;
				}
			}while(i < dist);
			return true;
		}

		/// <summary>
		/// Returns the closest NPC within the given range.
		/// Set party to true to target only the closest party member.
		/// </summary>
		/// <returns>The closest NPC within the given range.</returns>
		/// <param name="npc">The NPC.</param>
		/// <param name="range">The maximum range in which targets can be found, in pixels.</param>
		/// <param name="party">Whether this function only searches party members. Defaults to false.</param>
		public int TargetClosest(NPC npc, int range = 200, bool party = false){
			float dist = float.MaxValue;
			int target = -1;
			if(party) {
				MercData mercData = MercData.GetMercData();
				foreach(NPC n in Main.npc) {
					//if NPC is active, not me, in same party, and within range
					if(n.active && n.whoAmI != npc.whoAmI && mercData.GetOwner(n) == mercData.GetOwner(npc)
					   && npc.Distance(n.Center) <= range) {
						if(npc.Distance(n.Center) < dist) {
							dist = npc.Distance(n.Center);
							target = n.whoAmI;
						}
					}
				}
			} else {
				foreach(NPC n in Main.npc) {
					//if npc is active, not me, not friendly, not a critter, and within range
					if(n.active && n.whoAmI != npc.whoAmI && !n.friendly && n.lifeMax > 5 && npc.Distance(n.Center) <= range) {
						if(npc.Distance(n.Center) < dist) {
							dist = npc.Distance(n.Center);
							target = n.whoAmI;
						}
					}
				}
			}
			return target;
		}

		/// <summary>
		/// This is the ranged AI. Used for:
		/// - Guns
		/// - Projectile magic weapons
		/// - Bows
		/// - etc.
		/// NPC will aim at target and shoot accordingly.
		/// NPCs will not shoot at targets which do not have Line of Sight (ideally).
		/// </summary>
		public Action<NPC> AttackAIRanged;

		/// <summary>
		/// This is the melee AI. Used for:
		/// - Swords
		/// - Any other kind of close-range whacking stick
		/// NPC will approach target, swinging weapon once in range.
		/// NPCs will not attack targets which do not have Line of Sight (ideally).
		/// </summary>
		public Action<NPC> AttackAIMelee;

		/// <summary>
		/// This is the support AI. Used for:
		/// - Dryad
		/// It's a rather special AI, intended to
		/// stick near to the player rather than chase enemies.
		/// Essentially, it's a follow AI with a special 'attack'.
		/// </summary>
		public Action<NPC> AttackAISupport;

		/// <summary>
		/// A specialized AI for the Nurse.
		/// The Nurse will, when in danger, follow
		/// the most heavily injured party member instead.
		/// This followed NPC is the target of healing, and
		/// can be healed regardless of LOS.
		/// </summary>
		public Action<NPC> AINurse;

		public void LoadAIMethods(){
			AttackAIRanged = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				int target = TargetClosest(npc);
				if(target > -1){
					FollowNPC(npc, target, 7, 300, 200);
					if(LineOfSight(npc, target)){
						AttackWithHooks(npc, target);
					}
				} else {
					FollowPlayer(npc);
				}
			});

			AttackAIMelee = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				int target = TargetClosest(npc);
				if(target > -1){
					FollowNPC(npc, target);
				}
				FollowPlayer(npc);
			});

			AttackAISupport = new Action<NPC>(delegate(NPC npc) {
				TeleportToPlayer(npc);
				FollowPlayer(npc);
				int target = TargetClosest(npc);
				if(target > -1){
					AttackWithHooks(npc);
				}
			});

			AINurse = new Action<NPC>(delegate(NPC npc) {
				TeleportToPlayer(npc);
				int target = -1;
				int greatest = 0;
				MercData data = MercData.GetMercData();

				//Gets the party member with the most life missing
				foreach(NPC n in Main.npc){
					if(n.active && data.GetOwner(n) == data.GetOwner(npc) && n.life < n.lifeMax
						&& (n.lifeMax - n.life) > greatest){
						greatest = n.lifeMax - n.life;
						target = n.whoAmI;
					}
				}

				//If there's nobody to heal, follow player. Otherwise, follow the dude to heal.
				if(target == -1){
					FollowPlayer(npc);
				} else {
					FollowNPC(npc, target, 7, 50, 0);
				}
			});
		}

		/// <summary>
		/// Used as a shortcut to allow easy application of town NPC attack hooks.
		/// The NPC must have an attack method for this to work properly.
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="target">The attack target, if there is one.</param>
		public void AttackWithHooks(NPC npc, int target = -1){
		}
    }
}