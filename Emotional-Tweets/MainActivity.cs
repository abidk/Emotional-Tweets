using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using service.EmotionalTweetsCore;

namespace EmotionalTweets
{
	[Activity (Label = "Test", MainLauncher = true)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var submit = FindViewById<Button> (Resource.Id.search_tweets);
			submit.Click += delegate {
				StartActivity(typeof(TweetsActivity));
			};

			TwitterSearchAPI a = new DefaultTwitterSearchAPI();
		}
	}
}


