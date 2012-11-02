using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;

namespace MyGamer
{
	public class MyGamer : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SpriteFont font;
		Texture2D photo;
		Vector2 textSize;
		Vector2 photoVelocity;
		Rectangle photoRect;
		float rotation;
		float scale = 1;
		
		public MyGamer (): base()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			
			graphics.IsFullScreen = true;
		}

		protected override void Initialize ()
		{
			base.Initialize ();
			TouchPanel.EnabledGestures = GestureType.Tap;
		}
		
		protected override void LoadContent ()
		{
			base.LoadContent ();
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
			
			// TODO: use this.Content to load your game content here
			font = Content.Load<SpriteFont>("retroMedium");
			photo = Content.Load<Texture2D>("photo");
			textSize = font.MeasureString("Hello Kevin!");
			textSize = new Vector2(textSize.X/2,textSize.Y/2);
			photoVelocity.X = 3;
			photoVelocity.Y = 3;
			photoRect = new Rectangle(100, 100, 150, 170);
		}
		
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();
			spriteBatch.DrawString(font, new StringBuilder("Emma Knoop!"), new Vector2(photoRect.X, photoRect.Y + photoRect.Height), Color.Black, rotation, textSize,
			                       scale, SpriteEffects.None, 1);

//			spriteBatch.DrawString(font,"[Battery Status]\n" + PowerStatus.BatteryChargeStatus,new Vector2(10,100),Color.Black);
//			
//			spriteBatch.DrawString(font,"[PowerLine Status]\n" + PowerStatus.PowerLineStatus,new Vector2(10,200),Color.Black);
//			
//			spriteBatch.DrawString(font,"Charge: " + PowerStatus.BatteryLifePercent+"%",new Vector2(10,300),Color.Black);

			spriteBatch.Draw(photo, photoRect, new Rectangle(0,0, photo.Width , photo.Height), Color.White, rotation,
			                 new Vector2(photo.Width / 2, photo.Height / 2), SpriteEffects.None, 1);

			spriteBatch.End();
			base.Draw (gameTime);
		}
	
		void HandleInput ()
		{
			while (TouchPanel.IsGestureAvailable)
			{
				var gesture = TouchPanel.ReadGesture();
				if (gesture.GestureType == GestureType.Tap)
				{
					photoVelocity.X = -photoVelocity.X;
					photoVelocity.Y = -photoVelocity.Y;
				}
			}
		}

		protected override void Update (GameTime gameTime)
		{
			photoRect.X += (int)photoVelocity.X;
			photoRect.Y += (int)photoVelocity.Y;

			if (photoRect.X <= 0 || photoRect.X + photoRect.Width >= graphics.GraphicsDevice.Viewport.Width)
				photoVelocity.X = -photoVelocity.X;

			if (photoRect.Y <= 0 || photoRect.Y + photoRect.Height >= graphics.GraphicsDevice.Viewport.Height)
				photoVelocity.Y = -photoVelocity.Y;

			rotation += 0.05f;
			if (rotation > MathHelper.TwoPi) {
				rotation = 0.0f;
			}

			HandleInput();
			base.Update(gameTime);
		}
	}
}

