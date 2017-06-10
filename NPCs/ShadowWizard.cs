using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs
{
    public class ShadowWizard : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shadow Wizard";
            npc.width = 22;
            npc.height = 40;

            npc.lifeMax = 65;
            npc.defense = 9;
            npc.damage = 45;

            npc.soundHit = 1;
            npc.soundKilled = 1;

            npc.value = 0;
            npc.knockBackResist = 0;

            npc.netAlways = true;
            npc.chaseable = false;
            npc.lavaImmune = true;

            Main.npcFrameCount[npc.type] = 3;
        }

        public override bool PreAI()
        {
            npc.TargetClosest(true);
            npc.velocity.X = npc.velocity.X * 0.93f;
            if (npc.velocity.X > -0.1F && npc.velocity.X < 0.1F)
                npc.velocity.X = 0;
            if (npc.ai[0] == 0)
                npc.ai[0] = 500f;

            if (npc.ai[2] != 0 && npc.ai[3] != 0)
            {
                // Teleport effects: away.
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (int index1 = 0; index1 < 50; ++index1)
                {
                    int newDust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 172, 0.0f, 0.0f, 100, new Color(), 1.5f);
                    Main.dust[newDust].velocity *= 3f;
                    Main.dust[newDust].noGravity = true;
                }
                npc.position.X = (float)((double)npc.ai[2] * 16.0 - (double)(npc.width / 2) + 8.0);
                npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
                npc.velocity.X = 0.0f;
                npc.velocity.Y = 0.0f;
                npc.ai[2] = 0.0f;
                npc.ai[3] = 0.0f;
                // Teleport effects: arrived.
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (int index1 = 0; index1 < 50; ++index1)
                {
                    int newDust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 172, 0.0f, 0.0f, 100, new Color(), 1.5f);
                    Main.dust[newDust].velocity *= 3f;
                    Main.dust[newDust].noGravity = true;
                }
            }

            ++npc.ai[0];

            if (npc.ai[0] == 150 || npc.ai[0] == 300)
            {
                npc.ai[1] = 30f;
                npc.netUpdate = true;
            }

            bool teleport = false;
            for (int i = 0; i < 255; ++i)
            {
                if(Main.player[i].active && !Main.player[i].dead && (npc.position - Main.player[i].position).Length() < 160)
                {
                    teleport = true; break;
                }
            }

            // Teleport
            if (npc.ai[0] >= 500 && Main.netMode != 1)
            {
                teleport = true;
            }

            if(teleport)
                Teleport();

            if (npc.ai[1] > 0)
            {
                --npc.ai[1];
                if (npc.ai[1] == 20)
                {
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                    if (Main.netMode != 1)
                    {
                   Player player = Main.player[npc.target];
Vector2 direction = player.Center - npc.Center;
direction.Normalize();
direction *= 5;
Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("ShadowBall"), npc.damage, 11f);
                }
            }
			}

            if (Main.rand.Next(3) == 0)
                return false;
            Dust dust = Main.dust[Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 172, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, new Color(), 0.9f)];
            dust.noGravity = true;
            dust.velocity.X = dust.velocity.X * 0.3f;
            dust.velocity.Y = (dust.velocity.Y * 0.2f) - 1;

            return false;
        }

        public void Teleport()
        {
            npc.ai[0] = 1f;
            int num1 = (int)Main.player[npc.target].position.X / 16;
            int num2 = (int)Main.player[npc.target].position.Y / 16;
            int num3 = (int)npc.position.X / 16;
            int num4 = (int)npc.position.Y / 16;
            int num5 = 20;
            int num6 = 0;
            bool flag1 = false;
            if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000.0)
            {
                num6 = 100;
                flag1 = true;
            }
            while (!flag1 && num6 < 100)
            {
                ++num6;
                int index1 = Main.rand.Next(num1 - num5, num1 + num5);
                for (int index2 = Main.rand.Next(num2 - num5, num2 + num5); index2 < num2 + num5; ++index2)
                {
                    if ((index2 < num2 - 4 || index2 > num2 + 4 || (index1 < num1 - 4 || index1 > num1 + 4)) && (index2 < num4 - 1 || index2 > num4 + 1 || (index1 < num3 - 1 || index1 > num3 + 1)) && Main.tile[index1, index2].nactive())
                    {
                        bool flag2 = true;
                        if (Main.tile[index1, index2 - 1].lava())
                            flag2 = false;
                        if (flag2 && Main.tileSolid[(int)Main.tile[index1, index2].type] && !Collision.SolidTiles(index1 - 1, index1 + 1, index2 - 4, index2 - 1))
                        {
                            npc.ai[1] = 20f;
                            npc.ai[2] = (float)index1;
                            npc.ai[3] = (float)index2;
                            flag1 = true;
                            break;
                        }
                    }
                }
            }
            npc.netUpdate = true;
        }

        public override void FindFrame(int frameHeight)
        {
            int currShootFrame = (int)npc.ai[1];
            if (currShootFrame >= 25)
                npc.frame.Y = frameHeight;
            else if (currShootFrame >= 20)
                npc.frame.Y = frameHeight * 2;
            else if (currShootFrame >= 15)
                npc.frame.Y = frameHeight * 3;
            else if (currShootFrame >= 10)
                npc.frame.Y = frameHeight * 2;
            else if (currShootFrame >= 5)
                npc.frame.Y = frameHeight;
            else
                npc.frame.Y = 0;            

            npc.spriteDirection = npc.direction;
        }
    }
}
