using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
		/// NPCs will not teleport to a player that is too far off the ground.
		/// A player too far off the ground is one which is higher than the max teleport distance above it.
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="maxDistance">Max distance from player before teleport, in pixels.</param>
		public static void TeleportToPlayer(NPC npc, int maxDistance = 500){
			//TODO: Make dust on teleport
			MercData mercData = MercData.GetMercData();
			Player player = Main.player[mercData.GetOwner(npc.type, npc.displayName)];
			if(npc.Distance(player.Center) > maxDistance){
				bool onGround = false;
				for(int i = (int)(player.Center.Y / 16); i < (int)((player.Center.Y + maxDistance) / 16); i++) {
					Tile t = Main.tile[(int)(player.Center.X / 16), i];
					if(Main.tileSolid[t.type] || Main.tileSolidTop[t.type]) {
						onGround = true;
					}
				}
				if(onGround) {
					npc.position = player.position;
				}
			}
		}

		//This method is used to allow zombie-style auto-jumping and slab stepping.
		public static void HandleJumping(NPC npc){
			bool noXVelocity = false;
			if(npc.velocity.X == 0f) noXVelocity = true;
			if(npc.justHit) noXVelocity = false;
			bool tryJumping = false;
			if(npc.velocity.Y == 0f) {
				int lowY = (int)(npc.position.Y + (float)npc.height + 7f) / 16;
				int tileXLeft = (int)npc.position.X / 16;
				int tileXRight = (int)(npc.position.X + (float)npc.width) / 16;
				int num;
				for(int num204 = tileXLeft; num204 <= tileXRight; num204 = num + 1) {
					if(Main.tile[num204, lowY] == null) {
						return;
					}
					if(Main.tile[num204, lowY].nactive() && Main.tileSolid[(int)Main.tile[num204, lowY].type]) {
						tryJumping = true;
						break;
					}
					num = num204;
				}
			}
			if(npc.velocity.Y >= 0f) {
				int direction = 0;
				if(npc.velocity.X < 0f) {
					direction = -1;
				}
				if(npc.velocity.X > 0f) {
					direction = 1;
				}
				Vector2 position2 = npc.position;
				position2.X += npc.velocity.X;
				int tileX = (int)((position2.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 1) * direction)) / 16f);
				int tileY = (int)((position2.Y + (float)npc.height - 1f) / 16f);
				if(Main.tile[tileX, tileY] == null) {
					Main.tile[tileX, tileY] = new Tile();
				}
				if(Main.tile[tileX, tileY - 1] == null) {
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX, tileY - 2] == null) {
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if(Main.tile[tileX, tileY - 3] == null) {
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if(Main.tile[tileX, tileY + 1] == null) {
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX - direction, tileY - 3] == null) {
					Main.tile[tileX - direction, tileY - 3] = new Tile();
				}
				if((float)(tileX * 16) < position2.X + (float)npc.width && (float)(tileX * 16 + 16) > position2.X && ((Main.tile[tileX, tileY].nactive() && !Main.tile[tileX, tileY].topSlope() && !Main.tile[tileX, tileY - 1].topSlope() && Main.tileSolid[(int)Main.tile[tileX, tileY].type] && !Main.tileSolidTop[(int)Main.tile[tileX, tileY].type]) || (Main.tile[tileX, tileY - 1].halfBrick() && Main.tile[tileX, tileY - 1].nactive())) && (!Main.tile[tileX, tileY - 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 1].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 1].type] || (Main.tile[tileX, tileY - 1].halfBrick() && (!Main.tile[tileX, tileY - 4].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 4].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 4].type]))) && (!Main.tile[tileX, tileY - 2].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 2].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 2].type]) && (!Main.tile[tileX, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 3].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 3].type]) && (!Main.tile[tileX - direction, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX - direction, tileY - 3].type])) {
					float num208 = (float)(tileY * 16);
					if(Main.tile[tileX, tileY].halfBrick()) {
						num208 += 8f;
					}
					if(Main.tile[tileX, tileY - 1].halfBrick()) {
						num208 -= 8f;
					}
					if(num208 < position2.Y + (float)npc.height) {
						float num209 = position2.Y + (float)npc.height - num208;
						float num210 = 16.1f;
						if(num209 <= num210) {
							npc.gfxOffY += npc.position.Y + (float)npc.height - num208;
							npc.position.Y = num208 - (float)npc.height;
							if(num209 < 9f) {
								npc.stepSpeed = 1f;
							} else {
								npc.stepSpeed = 2f;
							}
						}
					}
				}
			}
			if(tryJumping) {
				int tileX = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
				int tileY = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
				if(Main.tile[tileX, tileY] == null) {
					Main.tile[tileX, tileY] = new Tile();
				}
				if(Main.tile[tileX, tileY - 1] == null) {
					Main.tile[tileX, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX, tileY - 2] == null) {
					Main.tile[tileX, tileY - 2] = new Tile();
				}
				if(Main.tile[tileX, tileY - 3] == null) {
					Main.tile[tileX, tileY - 3] = new Tile();
				}
				if(Main.tile[tileX, tileY + 1] == null) {
					Main.tile[tileX, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX + npc.direction, tileY - 1] == null) {
					Main.tile[tileX + npc.direction, tileY - 1] = new Tile();
				}
				if(Main.tile[tileX + npc.direction, tileY + 1] == null) {
					Main.tile[tileX + npc.direction, tileY + 1] = new Tile();
				}
				if(Main.tile[tileX - npc.direction, tileY + 1] == null) {
					Main.tile[tileX - npc.direction, tileY + 1] = new Tile();
				}
				Main.tile[tileX, tileY + 1].halfBrick();
				int spriteDirection = npc.spriteDirection;
				if((npc.velocity.X < 0f && spriteDirection == -1) || (npc.velocity.X > 0f && spriteDirection == 1)) {
					if(npc.height >= 32 && Main.tile[tileX, tileY - 2].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 2].type]) {
						if(Main.tile[tileX, tileY - 3].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 3].type]) {
							npc.velocity.Y = -8f;
							npc.netUpdate = true;
						} else {
							npc.velocity.Y = -7f;
							npc.netUpdate = true;
						}
					} else if(Main.tile[tileX, tileY - 1].nactive() && Main.tileSolid[(int)Main.tile[tileX, tileY - 1].type]) {
						npc.velocity.Y = -6f;
						npc.netUpdate = true;
					} else if(npc.position.Y + (float)npc.height - (float)(tileY * 16) > 20f && Main.tile[tileX, tileY].nactive() && !Main.tile[tileX, tileY].topSlope() && Main.tileSolid[(int)Main.tile[tileX, tileY].type]) {
						npc.velocity.Y = -5f;
						npc.netUpdate = true;
					} else if(npc.directionY < 0 && (!Main.tile[tileX, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY + 1].type]) && (!Main.tile[tileX + npc.direction, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX + npc.direction, tileY + 1].type])) {
						npc.velocity.Y = -8f;
						npc.velocity.X = npc.velocity.X * 1.5f;
						npc.netUpdate = true;
					}
					if((npc.velocity.Y == 0f & noXVelocity) && npc.ai[3] == 1f) {
						npc.velocity.Y = -5f;
					}
				}
			}
		}

		/// <summary>
		/// Makes the NPC follow the player.
		/// The NPC will try to follow at least the given distance away from the player.
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="moveSpeed">Maximum movement speed.</param>
		/// <param name="minDistance">Minimum following distance.</param>
		public static void FollowPlayer(NPC npc, float moveSpeed = 4, int minDistance = 50){
			Player player = Main.player[MercData.GetMercData().GetOwner(npc)];

			if(npc.Distance(player.Center) > minDistance) {
				/*
				if(npc.Center.X >= player.Center.X && npc.velocity.X >= -4 && Main.rand.Next(2) == 1) { // flies to players x position
					npc.velocity.X = npc.velocity.X - 0.2f;
				}
				if(npc.Center.X >= player.Center.X && npc.velocity.X >= -4 && npc.velocity.X <= -2 && Main.rand.Next(2) == 1) { // flies to players x position
					npc.velocity.X = npc.velocity.X - 0.2f;
				}*/

				//Bam. That should do the trick. The old method didn't face the target; now it does!
				int dir = 1 * Math.Sign(Math.Cos(npc.DirectionTo(player.Center).ToRotation()));
				npc.spriteDirection = dir;
				npc.direction = dir;

				//And this should do for the previous if-statement mess.
				npc.velocity.X += 0.2f * Math.Sign(player.Center.X - npc.Center.X);

				/*
				if(npc.Center.X <= player.Center.X && npc.velocity.X <= 4 && Main.rand.Next(2) == 1) {
					npc.velocity.X = npc.velocity.X + 0.2f;
				}
				if(npc.Center.X <= player.Center.X && npc.velocity.X <= 4 && npc.velocity.X >= 2 && Main.rand.Next(2) == 1) {
					npc.velocity.X = npc.velocity.X + 0.2f;
				}*/
				//Limits the velocity to moveSpeed
				if(Math.Abs(npc.velocity.X) >= moveSpeed) {
					//Note the use of Math.Sign. It removes the requirement for a second if statement for negative case.
					npc.velocity.X = Math.Sign(npc.velocity.X) * moveSpeed;
				}
			} else {
				npc.velocity.X -= Math.Sign(npc.velocity.X) * 0.2f;
				if(Math.Abs(npc.velocity.X) < 0.2) {
					npc.velocity.X = 0;
				}
			}
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
		public static void FollowNPC(NPC npc, int target, float moveSpeed = 4, int minDistance = 50, int buffer = 50){
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
		public static bool LineOfSight(NPC npc, int target, Vector2 headOffset = default(Vector2), int stepSize = 16){
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
		public static int TargetClosest(NPC npc, int range = 200, bool party = false){
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
		//public Action<NPC> AttackAIRanged;
		public Action<NPC> AttackAIGuide;
		public Action<NPC> AttackAIArmsDealer;
		public Action<NPC> AttackAICyborg;
		public Action<NPC> AttackAIWizard;
		public Action<NPC> AttackAITruffle;

		/// <summary>
		/// This is the melee AI. Used for:
		/// - Swords
		/// - Any other kind of close-range whacking stick
		/// NPC will approach target, swinging weapon once in range.
		/// NPCs will not attack targets which do not have Line of Sight (ideally).
		/// </summary>
		//public Action<NPC> AttackAIMelee;
		public Action<NPC> AttackAIDyeTrader;
		public Action<NPC> AttackAIStylist;
		public Action<NPC> AttackAITaxCollector;

		/// <summary>
		/// This is the support AI. Used for:
		/// - Dryad
		/// It's a rather special AI, intended to
		/// stick near to the player rather than chase enemies.
		/// Essentially, it's a follow AI with a special 'attack'.
		/// </summary>
		//public Action<NPC> AttackAISupport;
		public Action<NPC> AttackAIDryad;

		/// <summary>
		/// A specialized AI for the Nurse.
		/// The Nurse will, when in danger, follow
		/// the most heavily injured party member instead.
		/// This followed NPC is the target of healing, and
		/// can be healed regardless of LOS.
		/// </summary>
		public Action<NPC> AINurse;

		public void LoadAIMethods(){
			//TODO: Add functional attacks for all NPCs
			//Notes about the AI array:
			// 0 - Unused. | 1 - Cooldown timer. | 2 - Unused. | 3 - Unused.
			AttackAIGuide = new Action<NPC>(delegate(NPC npc){
				//npc.ai[0]++;
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target, 4, 100, 80);

					//Projectile stat vars
					/*int damage = 8;
					int projType = ProjectileID.WoodenArrowFriendly;
					float shootSpeed = 10f;
					float gravCorrect = 4f;
					float knockBack = 2.75f;

					//Cooldown vars
					int coolDown = 15;
					int randExtraCooldown = 10;
					int attackDelay = 0;

					//Drawing vars
					int item = ItemID.WoodenBow;
					int closeness = 5;
					float scale = 1f;

					if(Main.hardMode){
						projType = 2;
						damage += 6;
						coolDown = 10;
						randExtraCooldown = 5;
					}
					NPCLoader.TownNPCAttackStrength(npc, ref damage, ref knockBack);
					NPCLoader.TownNPCAttackProj(npc, ref projType, ref attackDelay);
					NPCLoader.TownNPCAttackCooldown(npc, ref coolDown, ref randExtraCooldown);
					NPCLoader.DrawTownAttackGun(npc, ref scale, ref item, ref closeness);
					randExtraCooldown = Main.rand.Next(randExtraCooldown);
					if(npc.ai[0] >= coolDown + randExtraCooldown){
						Vector2 shootVect = npc.DirectionTo(Main.npc[target].Center) + new Vector2(0f, (float)(-(float)gravCorrect));
						shootVect *= shootSpeed;
						Projectile.NewProjectile(npc.Center.X + (npc.spriteDirection * 16), npc.Center.Y - 2f, shootVect.X, shootVect.Y, projType, damage, knockBack, Main.myPlayer);
						npc.ai[0] = 0;
					}*/
				} else {
					FollowPlayer(npc);
				}
			});
			AttackAIArmsDealer = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target, 7, 300, 200);
					//AttackWithHooks(npc, target);
				} else {
					FollowPlayer(npc);
				}
			});
			AttackAICyborg = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target, 7, 300, 200);
					//AttackWithHooks(npc, target);
				} else {
					FollowPlayer(npc);
				}
			});
			AttackAIWizard = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target, 7, 300, 200);
					//AttackWithHooks(npc, target);
				} else {
					FollowPlayer(npc);
				}
			});
			AttackAITruffle = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target, 7, 300, 200);
					//AttackWithHooks(npc, target);
				} else {
					FollowPlayer(npc);
				}
			});

			AttackAIDyeTrader = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target);
					//AttackWithHooks(npc, target);
				}
				FollowPlayer(npc);
			});
			AttackAIStylist = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target);
					//AttackWithHooks(npc, target);
				}
				FollowPlayer(npc);
			});
			AttackAITaxCollector = new Action<NPC>(delegate(NPC npc){
				TeleportToPlayer(npc);
				HandleJumping(npc);
				int target = TargetClosest(npc);
				if(target > -1 && LineOfSight(npc, target)){
					FollowNPC(npc, target);
					//AttackWithHooks(npc, target);
				}
				FollowPlayer(npc);
			});

			AttackAIDryad = new Action<NPC>(delegate(NPC npc) {
				TeleportToPlayer(npc);
				HandleJumping(npc);
				FollowPlayer(npc);
				int target = TargetClosest(npc);
				if(target > -1){
					//AttackWithHooks(npc, 180);
				}
			});

			AINurse = new Action<NPC>(delegate(NPC npc) {
				TeleportToPlayer(npc);
				HandleJumping(npc);
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
					FollowNPC(npc, target, 4, 50, 0);
				}
			});
		}
    }
}