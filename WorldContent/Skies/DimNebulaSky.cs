using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Auralite.WorldContent.Skies
{
	internal class DimNebulaSky : CustomSky
	{
		private struct LightPillar
		{
			public Vector2 Position;

			public float Depth;
		}

		private DimNebulaSky.LightPillar[] _pillars;

		private Random _random = new Random();

		private Texture2D _planetTexture;

		private Texture2D _bgTexture;

		private Texture2D _beamTexture;

		private Texture2D[] _rockTextures;

		private bool _isActive;

		private float _fadeOpacity;

		public override void OnLoad()
		{
			this._planetTexture = ModLoader.GetTexture("Terraria/Misc/NebulaSky/Planet");
			this._bgTexture = ModLoader.GetTexture("Terraria/Misc/NebulaSky/Background");
			this._beamTexture = ModLoader.GetTexture("Terraria/Misc/NebulaSky/Beam");
			this._rockTextures = new Texture2D[3];
			for (int i = 0; i < this._rockTextures.Length; i++)
			{
				this._rockTextures[i] = ModLoader.GetTexture("Terraria/Misc/NebulaSky/Rock_" + i);
			}
		}

		public override void Update(GameTime gametime)
		{
			if (this._isActive)
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
				return;
			}
			this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
		}

		public override Color OnTileColor(Color inColor)
		{
			Vector4 vector = inColor.ToVector4();
			return new Color(Vector4.Lerp(vector, Vector4.One, this._fadeOpacity * 0.5f));
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
			{
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
				spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f * this._fadeOpacity));
				Vector2 vector = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
				Vector2 vector2 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
				spriteBatch.Draw(this._planetTexture, vector + new Vector2(-200f, -200f) + vector2, null, Color.White * 0.9f * this._fadeOpacity, 0f, new Vector2((float)(this._planetTexture.Width >> 1), (float)(this._planetTexture.Height >> 1)), 1f, 0, 1f);
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._pillars.Length; i++)
			{
				float depth = this._pillars[i].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = i;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num2 = i;
			}
			if (num == -1)
			{
				return;
			}
			Vector2 vector3 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			float num3 = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			for (int j = num; j < num2; j++)
			{
				Vector2 vector4 = new Vector2(1f / this._pillars[j].Depth, 0.9f / this._pillars[j].Depth);
				Vector2 vector5 = this._pillars[j].Position;
				vector5 = (vector5 - vector3) * vector4 + vector3 - Main.screenPosition;
				if (rectangle.Contains((int)vector5.X, (int)vector5.Y))
				{
					float num4 = vector4.X * 450f;
					spriteBatch.Draw(this._beamTexture, vector5, null, Color.White * 0.2f * num3 * this._fadeOpacity, 0f, Vector2.Zero, new Vector2(num4 / 70f, num4 / 45f), 0, 0f);
					int num5 = 0;
					for (float num6 = 0f; num6 <= 1f; num6 += 0.03f)
					{
						float num7 = 1f - (num6 + Main.GlobalTime * 0.02f + (float)Math.Sin((double)((float)j))) % 1f;
						spriteBatch.Draw(this._rockTextures[num5], vector5 + new Vector2((float)Math.Sin((double)(num6 * 1582f)) * (num4 * 0.5f) + num4 * 0.5f, num7 * 2000f), null, Color.White * num7 * num3 * this._fadeOpacity, num7 * 20f, new Vector2((float)(this._rockTextures[num5].Width >> 1), (float)(this._rockTextures[num5].Height >> 1)), 0.9f, 0, 0f);
						num5 = (num5 + 1) % this._rockTextures.Length;
					}
				}
			}
		}

		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._pillars = new DimNebulaSky.LightPillar[40];
			for (int i = 0; i < this._pillars.Length; i++)
			{
				this._pillars[i].Position.X = (float)i / (float)this._pillars.Length * ((float)Main.maxTilesX * 16f + 20000f) + this._random.NextFloat() * 40f - 20f - 20000f;
				this._pillars[i].Position.Y = this._random.NextFloat() * 200f - 2000f;
				this._pillars[i].Depth = this._random.NextFloat() * 8f + 7f;
			}
			Array.Sort<DimNebulaSky.LightPillar>(this._pillars, new Comparison<DimNebulaSky.LightPillar>(this.SortMethod));
		}

		private int SortMethod(DimNebulaSky.LightPillar pillar1, DimNebulaSky.LightPillar pillar2)
		{
			return pillar2.Depth.CompareTo(pillar1.Depth);
		}

		public override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		public override void Reset()
		{
			this._isActive = false;
		}

		public override bool IsActive()
		{
			return this._isActive || this._fadeOpacity > 0.001f;
		}
	}
}

