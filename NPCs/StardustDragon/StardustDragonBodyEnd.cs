using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Auralite.NPCs.StardustDragon
{
    public class StardustDragonBodyEnd: ModNPC
    {
        public override void SetDefaults()
        {
            npc.displayName = "Stardust Dragon";
            npc.noTileCollide = true;
            npc.name = "Stardust Dragon Body End";
            npc.width = 16;
            npc.height = 16;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 40;
            npc.defense = 20;
            npc.lifeMax = 20000;
            npc.soundHit = 7;
            npc.soundKilled = 8;
            npc.noGravity = true;
            npc.knockBackResist = 0f;
            npc.value = 10000f;
            npc.scale = 1f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.dontCountMe = true;
        }

        public override bool PreAI()
        {
            if (npc.life <= 1)
            {
                npc.life = 0;
                npc.checkDead();
            }
            npc.checkDead();
            bool flag34 = false;
            float num316 = 0.2f;
            int num75 = npc.type;
            if (num75 <= 95)
            {
                if (num75 != 10 && num75 != 39 && num75 != 95)
                {
                    goto IL_14788;
                }
            }
            else if (num75 != 117 && num75 != 510)
            {
                goto IL_14788;
            }
            flag34 = true;
        IL_14788:
                
                if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || flag34)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead || (flag34 && (double)Main.player[npc.target].position.Y < Main.worldSurface * 16.0))
            {
                if (npc.timeLeft > 300)
                {
                    npc.timeLeft = 300;
                }
                if (flag34)
                {
                    npc.velocity.Y = npc.velocity.Y + num316;
                }
            }
            if (Main.netMode != 1)
            {
                



                num75 = mod.NPCType("StardustDragonBodyEnd");
                switch (num75)
                {
                    case 8:
                    case 9:
                    case 11:
                    case 12:
                        break;
                    case 10:
                        goto IL_155CD;
                    default:
                        switch (num75)
                        {
                            case 40:
                            case 41:
                                break;
                            default:
                                switch (num75)
                                {
                                    case 88:
                                    case 89:
                                    case 90:
                                    case 91:
                                    case 92:
                                    case 96:
                                    case 97:
                                    case 99:
                                    case 100:
                                        break;
                                    case 93:
                                    case 94:
                                    case 95:
                                    case 98:
                                        goto IL_155CD;
                                    default:
                                        goto IL_155CD;
                                }
                                break;
                        }
                        break;
                }




                if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            IL_155CD:
                num75 = npc.type;
                if (num75 <= 99)
                {
                    switch (num75)
                    {
                        case 7:
                        case 8:
                        case 10:
                        case 11:
                            break;
                        case 9:
                            goto IL_15750;
                        default:
                            switch (num75)
                            {
                                case 39:
                                case 40:
                                    break;
                                default:
                                    switch (num75)
                                    {
                                        case 87:
                                        case 88:
                                        case 89:
                                        case 90:
                                        case 91:
                                        case 95:
                                        case 96:
                                        case 98:
                                        case 99:
                                            break;
                                        case 92:
                                        case 93:
                                        case 94:
                                        case 97:
                                            goto IL_15750;
                                        default:
                                            goto IL_15750;
                                    }
                                    break;
                            }
                            break;
                    }
                }
                else if (num75 <= 413)
                {
                    switch (num75)
                    {
                        case 117:
                        case 118:
                            break;
                        default:
                            switch (num75)
                            {
                                case 412:
                                case 413:
                                    break;
                                default:
                                    goto IL_15750;
                            }
                            break;
                    }
                }
                else
                {
                    switch (num75)
                    {
                        case 454:
                        case 455:
                        case 456:
                        case 457:
                        case 458:
                            break;
                        default:
                            switch (num75)
                            {
                                case 510:
                                case 511:
                                case 513:
                                case 514:
                                    break;
                                case 512:
                                    goto IL_15750;
                                default:
                                    goto IL_15750;
                            }
                            break;
                    }
                }
                if (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            IL_15750:

                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(28, -1, -1, "", npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            }
            int num344 = (int)(npc.position.X / 16f) - 1;
            int num345 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
            int num346 = (int)(npc.position.Y / 16f) - 1;
            int num347 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
            if (num344 < 0)
            {
                num344 = 0;
            }
            if (num345 > Main.maxTilesX)
            {
                num345 = Main.maxTilesX;
            }
            if (num346 < 0)
            {
                num346 = 0;
            }
            if (num347 > Main.maxTilesY)
            {
                num347 = Main.maxTilesY;
            }
            bool flag35 = true;



            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = 1;
            }
            else if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = -1;
            }


            float num352 = 8f;
            float num353 = 0.07f;

           

            Vector2 vector40 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num355 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num356 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);

            num355 = (float)((int)(num355 / 16f) * 16);
            num356 = (float)((int)(num356 / 16f) * 16);
            vector40.X = (float)((int)(vector40.X / 16f) * 16);
            vector40.Y = (float)((int)(vector40.Y / 16f) * 16);
            num355 -= vector40.X;
            num356 -= vector40.Y;

            float num368 = (float)Math.Sqrt((double)(num355 * num355 + num356 * num356));
            if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
            {
                try
                {
                    vector40 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    num355 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector40.X;
                    num356 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector40.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2((double)num356, (double)num355) + 1.57f;
                num368 = (float)Math.Sqrt((double)(num355 * num355 + num356 * num356));
                int num369 = npc.width;
                num369 = 42;

                num368 = (num368 - (float)num369) / num368;
                num355 *= num368;
                num356 *= num368;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num355;
                npc.position.Y = npc.position.Y + num356;
                if (num355 < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (num355 > 0f)
                {
                    npc.spriteDirection = -1;
                }

            }
            else
            {
                if (!flag35)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > num352)
                    {
                        npc.velocity.Y = num352;
                    }
                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num352 * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num353 * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + num353 * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == num352)
                    {
                        if (npc.velocity.X < num355)
                        {
                            npc.velocity.X = npc.velocity.X + num353;
                        }
                        else if (npc.velocity.X > num355)
                        {
                            npc.velocity.X = npc.velocity.X - num353;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num353 * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num353 * 0.9f;
                        }
                    }
                }
                else
                {
                    
                    num368 = (float)Math.Sqrt((double)(num355 * num355 + num356 * num356));
                    float num371 = Math.Abs(num355);
                    float num372 = Math.Abs(num356);
                    float num373 = num352 / num368;
                    num355 *= num373;
                    num356 *= num373;
                    bool flag37 = false;

                    if (flag37)
                    {
                        bool flag38 = true;

                        if (flag38)
                        {
                            if (Main.netMode != 1 && (double)(npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
                            {
                                npc.active = false;
                                int num375 = (int)npc.ai[0];
                                while (num375 > 0 && num375 < 200 && Main.npc[num375].active && Main.npc[num375].aiStyle == npc.aiStyle)
                                {
                                    int num376 = (int)Main.npc[num375].ai[0];
                                    Main.npc[num375].active = false;
                                    npc.life = 0;
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(23, -1, -1, "", num375, 0f, 0f, 0f, 0, 0, 0);
                                    }
                                    num375 = num376;
                                }
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                                }
                            }
                            num355 = 0f;
                            num356 = num352;
                        }
                    }
                    bool flag39 = false;
                   

                    if (!flag39)
                    {
                        if ((npc.velocity.X > 0f && num355 > 0f) || (npc.velocity.X < 0f && num355 < 0f) || (npc.velocity.Y > 0f && num356 > 0f) || (npc.velocity.Y < 0f && num356 < 0f))
                        {
                            if (npc.velocity.X < num355)
                            {
                                npc.velocity.X = npc.velocity.X + num353;
                            }
                            else if (npc.velocity.X > num355)
                            {
                                npc.velocity.X = npc.velocity.X - num353;
                            }
                            if (npc.velocity.Y < num356)
                            {
                                npc.velocity.Y = npc.velocity.Y + num353;
                            }
                            else if (npc.velocity.Y > num356)
                            {
                                npc.velocity.Y = npc.velocity.Y - num353;
                            }
                            if ((double)Math.Abs(num356) < (double)num352 * 0.2 && ((npc.velocity.X > 0f && num355 < 0f) || (npc.velocity.X < 0f && num355 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num353 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num353 * 2f;
                                }
                            }
                            if ((double)Math.Abs(num355) < (double)num352 * 0.2 && ((npc.velocity.Y > 0f && num356 < 0f) || (npc.velocity.Y < 0f && num356 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num353 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num353 * 2f;
                                }
                            }
                        }
                        else if (num371 > num372)
                        {
                            if (npc.velocity.X < num355)
                            {
                                npc.velocity.X = npc.velocity.X + num353 * 1.1f;
                            }
                            else if (npc.velocity.X > num355)
                            {
                                npc.velocity.X = npc.velocity.X - num353 * 1.1f;
                            }
                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num352 * 0.5)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num353;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num353;
                                }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < num356)
                            {
                                npc.velocity.Y = npc.velocity.Y + num353 * 1.1f;
                            }
                            else if (npc.velocity.Y > num356)
                            {
                                npc.velocity.Y = npc.velocity.Y - num353 * 1.1f;
                            }
                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num352 * 0.5)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num353;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num353;
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;

            }
            return false;
        }
    }
}
