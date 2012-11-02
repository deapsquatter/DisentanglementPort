using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WindowsPuzzleVisualizer;

namespace MyGamerDroid
{
	[Activity (Label = "MyGamerDroid", MainLauncher = true)]
	public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			//base.OnCreate (bundle);
			//Microsoft.Xna.Framework.Game.Activity = this;
			//Game = new WindowsPuzzleVisualizer.Game1(); 
			//WindowsPuzzleVisualizer.Game1 game = new WindowsPuzzleVisualizer.Game1();
			//game.Run();

			base.OnCreate(bundle);
			Game1.Activity = this;
			var g = new Game1(Assets);
			SetContentView(g.Window);
			g.Run();

		}
	}
}


