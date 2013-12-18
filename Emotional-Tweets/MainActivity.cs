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

			var searchText = FindViewById<EditText> (Resource.Id.search_text);

			var submit = FindViewById<Button> (Resource.Id.search_tweets);
			submit.Click += delegate {
				var activity = new Intent (this, typeof(TweetsActivity));
				activity.PutExtra (TweetsActivity.SEARCH_TEXT_KEY, searchText.Text);

				StartActivity(activity);
			};
		}
	}
}


